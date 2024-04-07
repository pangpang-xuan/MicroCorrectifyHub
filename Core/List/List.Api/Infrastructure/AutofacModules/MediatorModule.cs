using System.Reflection;
using Autofac;
using MediatR;
using RecALLDemo.Core.List.Api.Application.Commands;
using Module = Autofac.Module;

namespace RecALLDemo.Core.List.Api.Infrastructure.AutofacModules;


//注册中介者

public class MediatorModule : Module {
    protected override void Load(ContainerBuilder builder) {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(typeof(CreateListCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
    }
}
