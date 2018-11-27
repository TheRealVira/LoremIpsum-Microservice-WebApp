using Logon.API.Controllers;
using Logon.API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Xunit;

namespace Logon.API.Tests
{
    public class UnitTest1
    {
        private LogonController _controller;
        private IDBService _dbService;
        private IAuthenticationService _authenticationService;

        public UnitTest1()
        {
            _dbService = new DBServiceFake();
            _authenticationService = new AuthenticationServiceFake();
            _controller = new LogonController(_dbService, _authenticationService, new OptionsWrapper<Audience>(
                new Audience
                    {Aud = "tester", Expiration = 2, Iss = "ab.com", Secret = "abcd"}));
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get("username", "password").Result;
 
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsDynamicText()
        {
            // Act
            var okResult = _controller.Get("username", "password").Result as OkObjectResult;
 
            // Assert
            var item = Assert.IsAssignableFrom<MyToken>(okResult.Value);
            Assert.Equal(item.AccessToken, "token");
        }
    }
}