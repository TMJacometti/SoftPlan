using SoftPlan.API.Controllers;
using SoftPlan.Domain.Entities;
using SoftPlan.Service.Services;
using SoftPlan.Tests.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace SoftPlan.Tests
{
    [TestFixture]
    public class RevendedorControllerTest
    {
        Mock<ILogger<RevendedorController>> mockRepo = new Mock<ILogger<RevendedorController>>();
        RevendedorController controller;
        ModelTeste valor;

        [SetUp]
        public void Setup()
        {
            controller = new RevendedorController(mockRepo.Object);
        }

        [Test, Order(1)]
        public void Add()
        {
            Revendedor rev = new Revendedor()
            {
                Nome = "Usuario de Teste",
                Sobrenome = "Jacometti",
                CPF = "00011122233",
                Email = "thiago@tmjsistemas.com.br",
                Senha = "123456",
                DataCadastro = DateTime.Now,
                AprovAuto = false
            };
            // Act
            var result = controller.Post(rev);
            var okResult = result as OkObjectResult;

            valor = JsonConvert.DeserializeObject<ModelTeste>(okResult.Value.ToString().Replace("=", ":"));

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test, Order(2)]
        public void GetAll()
        {
            // Act
            var result = controller.Get();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test, Order(3)]
        public void GetUnique()
        {
            // Act
            var result = controller.Get(valor.Id);

            // Assert
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Greater(valor.Id, 0, "Id � nullo");
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test, Order(4)]
        public void Update()
        {
            Revendedor rev = new Revendedor()
            {
                Id = valor.Id,
                Nome = "Usuario de Teste",
                Sobrenome = "Jacometti",
                CPF = "00011122233",
                Email = "thiago@tmjsistemas.com.br",
                Senha = "123456",
                DataCadastro = DateTime.Now,
                AprovAuto = false
            };
            // Act
            var result = controller.Put(rev);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Greater(valor.Id, 0, "Id � nullo");
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test, Order(5)]
        public void Delete()
        {
            // Act
            var result = controller.Delete(valor.Id);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Greater(valor.Id, 0, "Id � nullo");
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value.ToString(),null);
        }
    }
}