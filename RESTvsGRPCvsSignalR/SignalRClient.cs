using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary.SignalR;

namespace RESTvsGRPCvsSignalR;

public class SignalRClient
{
  private readonly HubConnection
    client = new HubConnectionBuilder().WithUrl("http://localhost:7000/api", options =>
    {
      options.SkipNegotiation = true;
      options.Transports = HttpTransportType.WebSockets;
      options.TransportMaxBufferSize = 65536 * 8;
      options.ApplicationMaxBufferSize = 65536 * 8;
    }).AddMessagePackProtocol().Build();

  public SignalRClient()
  {
    client.StartAsync().Wait();
  }


  public async Task<string> GetSmallPayloadAsync()
  {
    return await client.InvokeAsync<string>("Get");
  }

  public async Task<List<MeteoriteLanding>> GetLargePayloadAsync()
  {
    return await client.InvokeAsync<List<MeteoriteLanding>>("GetLargePayloadAsync");
  }

  public async Task<string> PostLargePayloadAsync(List<MeteoriteLanding> meteoriteLandings)
  {
    return await client.InvokeAsync<string>("PostLargePayloadAsync", meteoriteLandings);
  }

  public async Task<List<MeteoriteLanding>> StreamLargePayloadAsync()
  {
    var meteoriteLandings = new List<MeteoriteLanding>();

    var stream = client.StreamAsync<MeteoriteLanding>("StreamLargePayloadAsync");

    await foreach (var item in stream) meteoriteLandings.Add(item);
    return meteoriteLandings;
  }

  public async Task<List<string>> StreamSmallPayloadAsync()
  {
    var list = new List<string>();

    var stream = client.StreamAsync<string>("StreamSmallPayloadAsync");

    await foreach (var item in stream) list.Add(item);
    return list;
  }
}