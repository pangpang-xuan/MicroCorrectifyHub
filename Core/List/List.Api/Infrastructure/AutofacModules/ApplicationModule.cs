using System.Data.Common;
using Autofac;
using RecALLDemo.Core.List.Api.Application.IntegrationEvents;
using RecALLDemo.Core.List.Api.Application.Queries;
using RecALLDemo.Core.List.Api.Infrastructure.Services;
using RecALLDemo.Core.List.Domain.AggregateModels.ItemAggregate;
using RecALLDemo.Core.List.Domain.AggregateModels.ListAggregate;
using RecALLDemo.Core.List.Domain.AggregateModels.SetAggregate;
using RecALLDemo.Core.List.Infrastructure.Repositories;
using RecALLDemo.Infrasturcture.EventBus;
using RecALLDemo.Infrasturcture.EventBus.Abstractions;
using RecALLDemo.Infrasturcture.IntegrationEventLog.Services;

namespace RecALLDemo.Core.List.Api.Infrastructure.AutofacModules;

public class ApplicationModule : Module {
    protected override void Load(ContainerBuilder builder) {
        builder.RegisterType<ListRepository>().As<IListRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SetRepository>().As<ISetRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ItemRepository>().As<IItemRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<IdentityService>().As<IIdentityService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<ContribUrlService>().As<IContribUrlService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ListQueryService>().As<IListQueryService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<SetQueryService>().As<ISetQueryService>()
            .InstancePerLifetimeScope();
        
        builder.Register<Func<DbConnection, IIntegrationEventLogService>>(_ =>
            connection => new IntegrationEventLogService(connection));
        builder.RegisterType<ListIntegrationEventService>()
            .As<IListIntegrationEventService>().InstancePerLifetimeScope();

        builder.RegisterType<DaprEventBus>().As<IEventBus>()
            .InstancePerLifetimeScope();
    }
}
