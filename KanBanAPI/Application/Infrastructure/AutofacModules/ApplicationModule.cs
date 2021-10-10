using Autofac;
using Domain.AggregatesModel.Attachments;
using Domain.AggregatesModel.CardLists;
using Domain.AggregatesModel.Comments;
using Domain.AggregatesModel.TaskCards;
using Infrastructure.Data.Repositories;
using KanBanAPI.Application.Queries;
using KanBanAPI.Application.Queries.Dapper;

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

            builder.RegisterType<TaskCardRepository>()
               .As<ITaskCardRepository>()
               .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}