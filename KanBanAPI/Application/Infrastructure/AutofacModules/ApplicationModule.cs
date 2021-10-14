using Autofac;
using Domain.AggregatesModel.Attachments;
using Domain.AggregatesModel.CardLists;
using Domain.AggregatesModel.Comments;
using Domain.AggregatesModel.TaskCards;
using Infrastructure.Data.Repositories;
using Infrastructure.Idempotency;
using KanBanAPI.Application.Commands.CardList;
using KanBanAPI.Application.Queries;
using KanBanAPI.Application.Queries.Dapper;
using MediatR;
using MiddleMan.EventBus.Abstractions;
using System.Reflection;

namespace KanBanAPI.Application.Infrastructure.AutofacModules
{
    public class ApplicationModule
           : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new TaskCardQueriesDapper(QueriesConnectionString))
                .As<ITaskCardQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AttachmentRepository>()
                .As<IAttachmentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CardListRepository>()
                .As<ICardListRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommentRepository>()
               .As<ICommentRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

            builder.RegisterType<TaskCardRepository>()
               .As<ITaskCardRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(CreateCardListCommandHandler).GetTypeInfo().Assembly)
                      .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}