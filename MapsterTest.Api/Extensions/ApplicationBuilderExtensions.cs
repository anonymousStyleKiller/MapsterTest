using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Mock;

namespace MapsterTest.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    internal static  void Initialize(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var initializers = serviceScope.ServiceProvider.GetServices<IDbService>();

        foreach (var initializer in initializers)  initializer.Init();
    }
    
    internal static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IDbService, DbService>();
    }
    
    internal static void ConfigureSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment()) return;
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(Program).Assembly.GetName().Name);
            options.DisplayRequestDuration();
        });
    }
    
    internal static void UseForwarding(this IApplicationBuilder app)
    {
        app.UseCors();
        app.UseForwardedHeaders();
    }
    
    internal static void UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    }
}