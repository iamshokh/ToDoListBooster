using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.UserService;
using ToDoListBooster.WebApi.Controllers;
using Xunit;

namespace ToDoListBooster.xUnitTests.Tests
{
    public class UserControllerTests
    {
        private UserController CreateUserController(IMediator mediator)
        {
            var controller = new UserController(mediator);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            return controller;
        }

        [Fact]
        public async Task EditProfile_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<EditUserCommand>(), default(CancellationToken)))
                        .ReturnsAsync(1);

            var controller = CreateUserController(mediatorMock.Object);
            controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1")
            }));

            // Act
            var result = await controller.EditProfile(new EditUserCommand
            {
                UserName = "TestUser",
                Email = "test@example.com",
                Password = "TestPassword123!"
            });

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<int>(okResult.Value);
        }
    }
}
