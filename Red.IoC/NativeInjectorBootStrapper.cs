using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Red.Domain.CommandHandlers;
using Red.Domain.Commands;
using Red.Domain.Core.Bus;
using Red.Domain.Core.Notifications;
using Red.Domain.EventHandlers;
using Red.Domain.Events;
using Red.Domain.Interfaces;
using Red.Infra.CrossCutting.Bus;
using Red.Infra.Data.Context;
using Red.Infra.Data.Repository;
using Red.Infra.Data.UoW;

namespace Red.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();
            
            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UsuarioRegisteredEvent>, UsuarioEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioUpdatedEvent>, UsuarioEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioRemovedEvent>, UsuarioEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewUsuarioCommand>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUsuarioCommand>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUsuarioCommand>, UsuarioCommandHandler>();

            // Infra - Data
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<RedContext>();

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            // services.AddScoped<IUser, AspNetUser>();
        }
    }
}