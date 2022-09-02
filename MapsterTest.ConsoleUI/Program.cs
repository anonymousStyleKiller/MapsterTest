using BenchmarkDotNet.Running;
using MapsterTest.ConsoleUI.Benchmark;

class Program
{
    static async Task Main(string[] args)
    {
        BenchmarkRunner.Run<MappingPerformance>();
        Console.ReadLine();
        
    }
}