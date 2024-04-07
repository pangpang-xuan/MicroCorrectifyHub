using Autofac;
using RecALLDemo.Core.List.Api.Infrastructure.Services;
using RecALLDemo.Core.List.Domain.AggregateModels.ListAggregate;
using RecALLDemo.Core.List.Infrastructure.Repositories;

namespace RecALLDemo.Core.List.Api.Infrastructure.AutofacModules;

public class ApplicationModule : Module {
    protected override void Load(ContainerBuilder builder) {
        builder.RegisterType<ListRepository>().As<IListRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<MockIdentityService>().As<IIdentityService>()
            .InstancePerLifetimeScope();
    }
}
