using Application.Interfaces;
using Application.Services;
using Domain.CommandHandlers;
using Domain.Commands;
using Domain.core.Bus;
using Domain.EventHandlers;
using Domain.Events;
using Domain.Interfaces;
using Domain.Notifications;
using Infrastruct.Data.Bus;
using Infrastruct.Data.Data;
using Infrastruct.Data.Repository;
using MediatR;

namespace DDDNB.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services) 
        {
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IStudentAppService, StudentAppService>();

            services.AddScoped<StudyContext>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, bool>, StudentCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentUpdatedEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentRemovedEvent>, StudentEventHandler>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
