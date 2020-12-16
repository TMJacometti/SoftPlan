using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftPlan.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftPlan.API.Core;

namespace SoftPlan.API.Controllers
{
    public class TaxController : BaseController
    {
        TaxService _service = new TaxService();

        private readonly ILogger _logger;
        public TaxController(ILogger<TaxController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _logger = logger;
        }
        [Route("taxaJuros")]
        [HttpGet]
        public IActionResult getTaxaJuros()
        {
            try
            {
                _logger.LogInformation(string.Concat("getTaxaJuros ", LoggedUserId));

                return Ok(_service.taxaJuros());
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "NotFound", null);
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BadRequest", null);
                return BadRequest(ex);
            }
        }

        [Route("/calculaJuros")]
        [HttpGet]
        public IActionResult getTaxaJuros(decimal ValorInicial, int Tempo)
        {
            try
            {
                _logger.LogInformation(string.Concat("getTaxaJuros ", LoggedUserId));

                return Ok(_service.calculaJuros(ValorInicial, Tempo).ToString().Mask("###,##"));
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "NotFound", null);
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BadRequest", null);
                return BadRequest(ex);
            }
        }
    }
}
