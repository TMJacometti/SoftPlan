using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using SoftPlan.Domain.Entities;
using SoftPlan.Service.Services;
using Microsoft.Extensions.Logging;

namespace SoftPlan.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private UserService service = new UserService();
        private readonly ILogger _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody] User usuario,
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)
        {
            User usuarioBase = service.Login(usuario.Email, usuario.Password);

            if (usuarioBase != null && usuarioBase.Id > 0)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Email, "Login"),
                    new[] {
                        new Claim("Email",usuarioBase.Email),
                        new Claim("Nome",usuarioBase.Nome)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                _logger.LogInformation(string.Concat("Usuário, ", usuarioBase.Email, " efetuou  login no sistema !"));

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };


            }
            else
            {
                var msg = "Falha ao autenticar. Usuário: {0}";

                if (usuarioBase != null)
                {
                    msg = string.Format(msg, usuarioBase.Nome);
                }
                else
                {
                    msg = string.Format(msg, usuario.Email);
                }
                _logger.LogWarning(msg);
                return new
                {
                    authenticated = false,
                    message = msg
                };

            }
        }

    }
}