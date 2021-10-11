﻿using Autofac;
using KanBanAPI.Application.Commands.CardList;
using MediatR;
using System.Reflection;

namespace KanBanAPI.Application.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CreateCardListCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(DeleteCardListCommand).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));
            //builder.RegisterAssemblyTypes(typeof(SetTitleCardListCommand).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));
            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events
            //builder.RegisterAssemblyTypes(typeof(ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            //builder
            //    .RegisterAssemblyTypes(typeof(CreateOrderCommandValidator).GetTypeInfo().Assembly)
            //    .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //    .AsImplementedInterfaces();
            //  builder.RegisterAssemblyTypes(typeof(CreateCardListCommandHandler).GetTypeInfo().Assembly)
            //.AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

            //  builder.RegisterType(typeof(IdentifiedCommandHandler<CreateCardListCommand, bool>))
            //  .As<IRequestHandler<IdentifiedCommand<CreateCardListCommand, bool>, bool>>()
            //  .AsImplementedInterfaces();
            builder.RegisterType<CreateCardListCommand>()
       .As<CreateCardListCommand>();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            //builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}