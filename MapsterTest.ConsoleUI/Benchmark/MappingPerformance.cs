using BenchmarkDotNet.Attributes;
using MapsterTest.ConsoleUI.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        using var host = Hosting;
        await host.StartAsync();
        var cient = ServiceProvider.GetRequiredService<MockCient>();
        var x = await cient.GetInfoByAutoMapper();
        await host.StopAsync();
    }
}