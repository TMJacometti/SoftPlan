using SoftPlan.API.Controllers;
using SoftPlan.Domain.Entities;
using SoftPlan.Domain.Enum;
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
    public class PedidoControllerTest
    {
        Mock<ILogger<PedidoController>> mockRepo = new Mock<ILogger<PedidoController>>();
        PedidoController controller;
        ModelTeste valor;

        [SetUp]
        public void Setup()
        {
            controller = new PedidoController(mockRepo.Object);
        }

        [Test, Order(1)]
        public void Add()
        {
            Pedido rev = new Pedido()
            {
                Data = DateTime.Now,
                IdProduto = 1,
                IdRevendedor = 1,
                IdStatus = 1,
                Quantidade = 10,
                Valor = 13.5m
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
            Assert.Greater(valor.Id, 0, "Id é nullo");
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test, Order(4)]
        public void Update()
        {
            Pedido rev = new Pedido()
            {
                Id = valor.Id,
                Data = DateTime.Now,
                IdProduto = 1,
                IdRevendedor = 1,
                IdStatus = (short)EStatus.Aprovado,
                Quantidade = 10,
                Valor = 13.5m
            };
            // Act
            var result = controller.Put(rev);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Greater(valor.Id, 0, "Id é nullo");
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
            Assert.Greater(valor.Id, 0, "Id é nullo");
            Assert.IsNotNull(okResult, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value.ToString());
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}