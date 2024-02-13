using MediatR;
using ToDoListBooster.BizLogicLayer.AccountService;
using ToDoListBooster.BizLogicLayer.ComentService;
using ToDoListBooster.BizLogicLayer.TaskItemService;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.BizLogicLayer.UserService;
using ToDoListBooster.DataLayer.EfClasses;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<RegistrationCommand, int>, RegistrationCommandHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, LoginResponseDto>, LoginCommandHandler>();

            services.AddScoped<IRequestHandler<CreateTaskListCommand, int>, CreateTaskListCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTaskListCommand, int>, UpdateTaskListCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTaskListCommand, int>, DeleteTaskListCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllTaskListQuery, List<TaskList>>, GetAllTaskListQueryHandler>();

            services.AddScoped<IRequestHandler<EditUserCommand, int>,  EditUserCommandHandler>();

            services.AddScoped<IRequestHandler<CreateTaskItemCommand, int>, CreateTaskItemCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTaskItemCommand, int>, UpdateTaskItemCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTaskItemCommand, int>, DeleteTaskItemCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStatusTaskItemCommand, int>, UpdateStatusTaskItemCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllTaskItemQuery, List<TaskItem>>, GetAllTaskItemQueryHandler>();

            services.AddScoped<IRequestHandler<CreateCommentCommand, int>, CreateCommentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCommentCommand, int>, UpdateCommentCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCommentCommand, int>, DeleteCommentCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCommentQuery, List<Comment>>, GetAllCommentQueryHandler>();

        }
    }
}
