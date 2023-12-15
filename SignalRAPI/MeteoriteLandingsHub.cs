using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ModelLibrary.Data;
using ModelLibrary.SignalR;

namespace SignalRAPI;

public class MeteoriteLandingsHub : Hub
{
  private readonly ILogger<MeteoriteLandingsHub> _logger;

  public MeteoriteLandingsHub(ILogger<MeteoriteLandingsHub> logger)
  {
    _logger = logger;
  }

  public async Task<string> Get()
  {
    return await Task.FromResult("API Version 1.0");
  }

  public async Task<IEnumerable<MeteoriteLanding>> GetLargePayloadAsync()
  {
    return await Task.FromResult(MeteoriteLandingData.SignalRMeteoriteLandings);
  }

  public async Task<string> PostLargePayloadAsync(IEnumerable<MeteoriteLanding> meteoriteLandings)
  {
    return await Task.FromResult("SUCCESS");
  }

  public async IAsyncEnumerable<string> StreamSmallPayloadAsync()
  {
    for (var i = 0; i < 1000; i++)
    {
      yield return "API Version 1.0";
      await Task.Delay(0);
    }
  }

  public async IAsyncEnumerable<MeteoriteLanding> StreamLargePayloadAsync()
  {
    for (var i = 0; i < MeteoriteLandingData.SignalRMeteoriteLandings.Count; i++)
    {
      yield return MeteoriteLandingData.SignalRMeteoriteLandings[i];
      await Task.Delay(0);
    }
  }
}