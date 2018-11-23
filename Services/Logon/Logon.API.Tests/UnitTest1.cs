using Logon.API.Controllers;
using Logon.API.Service;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Logon.API.Tests
{
    public class UnitTest1
    {
        private LogonController _controller;
        private IDBService _service;
        public UnitTest1()
        {
            _service = new DBServiceFake();
            _controller = new LogonController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get("username", "password");
 
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsDynamicText()
        {
            // Act
            var okResult = _controller.Get("username", "password").Result as OkObjectResult;
 
            // Assert
            var item = Assert.IsAssignableFrom<bool>(okResult.Value);
            Assert.True(item);
        }
    }
}