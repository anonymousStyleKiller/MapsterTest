using System.Reflection;
using Mapster;
using MapsterMapper;
using MapsterTest.Api.Contexts;
using MapsterTest.Api.Interfaces;
using MapsterTest.Api.Mappings;
using MapsterTest.Api.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MapsterTest.Api.Extensions;

public static class ServiceCollectionExtensions
{
    internal static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContextFactory<BaseContext>(options =>
                options.EnableSensitiveDataLogging()
                    .UseSqlServer(configuration
                        .GetConnectionString("DefaultConnection")));
    }
    
    
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddSingleton(GetConfiguredMappingConfig());
        services.AddScoped<IMapper, ServiceMapper>();
    }

    private static TypeAdapterConfig GetConfiguredMappingConfig()
    {
        var config = new TypeAdapterConfig
        {
                Compiler = expression => expression.Compile() 
        };
         new UserRegisterMapping().Register(config);
        return config;
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
    }

    internal static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (!assembly.IsDynamic)
                {
                    var xmlFile = $"{assembly.GetName().Name}.xml";
                    var xmlPath = Path.Combine(baseDirectory, xmlFile);
                    if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);
                }

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "MPortal",
            });
            
        });
    }

}