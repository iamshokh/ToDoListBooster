using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.AccountService;
using ToDoListBooster.WebApi.Controllers;
using Xunit;

namespace ToDoListBooster.xUnitTests.Tests
{
    public class AccountControllerTests
    {
        public AccountControllerTests()
        {
        }

        [Fact]
        public async Task Registration_ReturnsOkObjectResult_WithUserId()
        {
            // Arrange
            var mediator = new Mock<IMediator>();
            var controller = new AccountController(mediator.Object);
            var registrationCommand = new RegistrationCommand
            {
                UserName = "testuser",
                Email = "test@example.com",
                Password = "Test123@"
            };

            // Act
            var result = await controller.Registration(registrationCommand) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<int>(result.Value);
        }

        [Fact]
        public async Task Login_ReturnsOkObjectResult_WithLoginResponseDto()
        {
            // Arrange
            var mediator = new Mock<IMediator>();
            var controller = new AccountController(mediator.Object);
            var loginCommand = new LoginCommand
            {
                NameOrEmail = "shaxzod",
                Password = "Shaxzod@123"
            };

            // Act
            var result = await controller.Login(loginCommand) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<LoginResponseDto>(result.Value);
        }
    }
}
