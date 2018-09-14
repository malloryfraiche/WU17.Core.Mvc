using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ToolShed.Web.Controllers;
using ToolShed.Web.Models;
using ToolShed.Web.Repositories;
using Xunit;

namespace ToolShed.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1() { }
    }

    public class ProductControllerTests
    {
        [Fact]
        public void Able_To_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { Id = 1, Name = "Såg" },
                new Product { Id = 2, Name = "Fil" },
                new Product { Id = 3, Name = "Kruvmejsel" },
                new Product { Id = 4, Name = "Måttstock" },
                new Product { Id = 5, Name = "Fogsvans" }
            });
            var pc = new ProductController(mock.Object);
            pc.PageLimit = 3;

            // Act
            var products = (pc.List(2) as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            var prodArray = products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("Måttstock", prodArray[0].Name);
            Assert.Equal("Fogsvans", prodArray[1].Name);
        }
    }
}
