using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using ModelLibrary.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RESTvsGRPCvsSignalR;

[RPlotExporter]
[AsciiDocExporter]
[CsvExporter]
[HtmlExporter]
public class BenchmarkHarness
{
  [Params(100, 200)] public int IterationCount;

  private readonly RESTClient restClient = new();
  private readonly GRPCClient grpcClient = new();
  private readonly SignalRClient signalRClient = new();

  #region SignalR

  [Benchmark]
  public async Task SignalRGetSmallPayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await signalRClient.GetSmallPayloadAsync();
  }

  [Benchmark]
  public async Task SignalRStreamSmallPayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await signalRClient.StreamSmallPayloadAsync();
  }

  [Benchmark]
  public async Task SignalRGetLargePayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await signalRClient.GetLargePayloadAsync();
  }

  [Benchmark]
  public async Task SignalRPostLargePayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++)
      await signalRClient.PostLargePayloadAsync(MeteoriteLandingData.SignalRMeteoriteLandings);
  }

  [Benchmark]
  public async Task SignalRStreamLargePayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await signalRClient.StreamLargePayloadAsync();
  }

  #endregion

  #region Rest

  [Benchmark]
  public async Task RestGetSmallPayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await restClient.GetSmallPayloadAsync();
  }

  [Benchmark]
  public async Task RestGetLargePayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await restClient.GetLargePayloadAsync();
  }

  [Benchmark]
  public async Task RestPostLargePayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++)
      await restClient.PostLargePayloadAsync(MeteoriteLandingData.RestMeteoriteLandings);
  }

  #endregion

  #region Grpc

  [Benchmark]
  public async Task GrpcGetSmallPayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await grpcClient.GetSmallPayloadAsync();
  }

  [Benchmark]
  public async Task GrpcStreamSmallPayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await grpcClient.StreamSmallPayloadAsync();
  }

  [Benchmark]
  public async Task GrpcStreamLargePayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++) await grpcClient.StreamLargePayloadAsync();
  }

  [Benchmark]
  public async Task GrpcGetLargePayloadAsListAsync()
  {
    for (var i = 0; i < IterationCount; i++) await grpcClient.GetLargePayloadAsListAsync();
  }

  [Benchmark]
  public async Task GrpcPostLargePayloadAsync()
  {
    for (var i = 0; i < IterationCount; i++)
      await grpcClient.PostLargePayloadAsync(MeteoriteLandingData.GrpcMeteoriteLandingList);
  }

  #endregion
}

public class AllowNonOptimized : ManualConfig
{
  public AllowNonOptimized()
  {
    AddValidator(JitOptimizationsValidator.DontFailOnError);

    AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
    AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
    AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
  }
}