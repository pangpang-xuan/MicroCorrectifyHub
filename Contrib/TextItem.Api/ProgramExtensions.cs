using Dapr.Client;
using Dapr.Extensions.Configuration;
using Infrastructure.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Polly;
using RecALLDemo.Contrib.TextItem.Api.Services;
using Serilog;
using TheSalLab.GeneralReturnValues;

namespace RecALLDemo.Contrib.TextItem.Api;

public static class ProgramExtensions {
    
    public static readonly string AppName = typeof(ProgramExtensions).Namespace;  //确定命名空间
    

    public static void AddCustomConfiguration(
        this WebApplicationBuilder builder) {
        builder.Configuration.AddDaprSecretStore("recall-secretstore",
            new DaprClientBuilder().Build());
    }
    
    public static void AddCustomSerilog(this WebApplicationBuilder builder) {
        var seqServerUrl = builder.Configuration["Serilog:SeqServerUrl"]; //废话了

        Log.Logger = new LoggerConfiguration().ReadFrom
            .Configuration(builder.Configuration).WriteTo.Console().WriteTo
            .Seq(seqServerUrl).Enrich.WithProperty("ApplicationName", AppName)
            .CreateLogger();

        builder.Host.UseSerilog();
    }


    public static void AddCustomSwagger(this WebApplicationBuilder builder) =>
        builder.Services.AddSwaggerGen();

    
    public static void AddCustomApplicationServices(
        //专门注册自己书写的业务服务
        this WebApplicationBuilder builder) {
        builder.Services.AddScoped<IIdentityService, MockIdentityService>();
    }

    //专门添加数据库的函数
    public static void AddCustomDatabase(this WebApplicationBuilder builder) {
        builder.Services.AddDbContext<TextItemContext>(p =>
            p.UseSqlServer(
                builder.Configuration["ConnectionStrings:TextItemContext"]));
    }

    public static void ApplyDatabaseMigration(this WebApplication app) {
        using var scope = app.Services.CreateScope();

        var retryPolicy = CreateRetryPolicy();
        var context =
            scope.ServiceProvider.GetRequiredService<TextItemContext>();

        retryPolicy.Execute(context.Database.Migrate);
    }

    
    //进行模型验证的，如果用户输入的信息不符合要求的话
    public static void AddInvalidModelStateResponseFactory(
        this WebApplicationBuilder builder) {
        builder.Services.AddOptions().PostConfigure<ApiBehaviorOptions>(options => {
            options.InvalidModelStateResponseFactory = context =>
                new OkObjectResult(ServiceResult
                    .CreateInvalidParameterResult(
                        new ValidationProblemDetails(context.ModelState).Errors
                            .Select(p =>
                                $"{p.Key}: {string.Join(" / ", p.Value)}")) 
                    .ToServiceResultViewModel());  //打印模型没有通过的信息
        });
    }
    
    public static void AddCustomHealthChecks(this WebApplicationBuilder builder) =>
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy()).AddDapr()   //首先检查自己再检查自己的dapr
            .AddSqlServer(builder.Configuration["ConnectionStrings:TextItemContext"]!,
                name: "TextListDb-check", tags: new[] { "TextListDb" });

    
    

    private static Policy CreateRetryPolicy() {
        
        return Policy.Handle<Exception>().WaitAndRetryForever(
            sleepDurationProvider: _ => TimeSpan.FromSeconds(5),
            onRetry: (exception, retry, _) => {
                Console.WriteLine(
                    "Exception {0} with message {1} detected during database migration (retry attempt {2})",
                    exception.GetType().Name, exception.Message, retry);
            });
    }
    
    public static void UseCustomSwagger(this WebApplication app) {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    
}