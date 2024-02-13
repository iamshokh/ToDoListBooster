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
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.WebApi.Controllers;
using Xunit;

namespace ToDoListBooster.xUnitTests.Tests
{
    public class TaskListControllerTests
    {
        private TaskListController CreateTaskListController(IMediator mediator)
        {
            var controller = new TaskListController(mediator);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
            return controller;
        }

        [Fact]
        public async Task Create_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<CreateTaskListCommand>(), default(CancellationToken)))
                        .ReturnsAsync(1); 

            var controller = CreateTaskListController(mediatorMock.Object);
            controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1")
            }));

            // Act
            var result = await controller.Create(new CreateTaskListCommand { Title = "Test", Descrition = "Test Description" });

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task Update_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<UpdateTaskListCommand>(), default(CancellationToken)))
                        .ReturnsAsync(1); 

            var controller = CreateTaskListController(mediatorMock.Object);

            // Act
            var result = await controller.Update(new UpdateTaskListCommand { Id = 1, Title = "Updated Test", Descrition = "Updated Test Description" });

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<GetAllTaskListQuery>(), default(CancellationToken)))
                        .ReturnsAsync(new List<TaskList>());

            var controller = CreateTaskListController(mediatorMock.Object);

            // Act
            var result = await controller.GetAll(new GetAllTaskListQuery());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<List<TaskList>>(okResult.Value);
        }

        [Fact]
        public async Task Delete_ValidCommand_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<DeleteTaskListCommand>(), default(CancellationToken)))
                        .ReturnsAsync(1); 

            var controller = CreateTaskListController(mediatorMock.Object);

            // Act
            var result = await controller.Delete(new DeleteTaskListCommand { Id = 1 });

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<int>(okResult.Value);
        }
    }
}
