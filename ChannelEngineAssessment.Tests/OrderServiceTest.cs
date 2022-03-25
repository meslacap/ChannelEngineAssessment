using ChannelEngineAssessment.Controllers;
using ChannelEngineAssessment.Services.Interfaces;
using ChannelEngineAssessment.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void FetchAllOrderTest()
        {
            //Arrange
            List<Order> expectedResults = new();

            expectedResults.Add(new Order
            {
                Id = 1,
                ChannelName = "Unit Test Channel",
                Status = "IN_PROGRESS",
                Lines = new List<Lines>()
            });

            var serviceMock = new Mock<IOrderService>();
            serviceMock.Setup(o => o.FetchAllOrdersAsync())
                .Returns(Task.FromResult(expectedResults))
                .Verifiable();

            //Act
            var sut = new HomeController(serviceMock.Object);
            sut.Index();

            //Assert
            serviceMock.Verify();
            Assert.AreEqual(1, expectedResults.Count);
        }

        [TestMethod]
        public void GetProductTest()
        {
            //Arrange
            List<Product> expectedResult = new();
            List<Order> orders = new();
            Lines line = new();
            int orderId = 1;


            expectedResult.Add(new Product
            {
                IsActive = true,
                Name = "Test Product",
                MerchantProductNo = "00001"
            });

            var serviceMock = new Mock<IOrderService>();
            serviceMock.Setup(o => o.GetProduct(line))
                .Returns(Task.FromResult(expectedResult))
                .Verifiable();

            //Act
            var sut = new HomeController(serviceMock.Object);
            sut.GetProduct(orders, orderId);

            //Assert
            serviceMock.Verify();
            Assert.AreEqual(1, expectedResult.Count);
            Assert.IsNotNull(expectedResult);
        }
    }
}