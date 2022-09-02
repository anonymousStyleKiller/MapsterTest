using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using MapsterTest.Api.Dto;
using MapsterTest.ConsoleUI.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHost = Microsoft.Extensions.Hosting.IHost;

namespace MapsterTest.ConsoleUI.Benchmark;

public class MappingPerformance
{
    private static IHost? _hosting;
    private IHost Hosting;
    private IServiceProvider ServiceProvider;

    public MappingPerformance()
    {
        Hosting = _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        ServiceProvider = Hosting.Services;
    }

    IHostBuilder CreateHostBuilder(string[] args) => Host
        .CreateDefaultBuilder(args)
        .ConfigureServices(ConfigureServices);

    public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        services.AddHttpClient<MockCient>(client => client.BaseAddress = new Uri("https://localhost:7133"))
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));
    }

    [Benchmark]
    public async Task GetDataFromAutoMapper()
    {
        var cient = ServiceProvider.GetRequiredService<MockCient>();
        await cient.GetInfoByAutoMapper().ConfigureAwait(false);
    }
    
    [Benchmark]
    public async Task GetDataFromMapster()
    {
        var cient = ServiceProvider.GetRequiredService<MockCient>();
        await cient.GetInfoByMappster().ConfigureAwait(false);
    }
}