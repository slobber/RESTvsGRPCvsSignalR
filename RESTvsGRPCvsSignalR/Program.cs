using BenchmarkDotNet.Running;
using System;
using BenchmarkDotNet.Configs;

namespace RESTvsGRPCvsSignalR;

internal class Program
{
  private static void Main(string[] args)
  {
    BenchmarkRunner.Run<BenchmarkHarness>();
    Console.ReadKey();
  }
}