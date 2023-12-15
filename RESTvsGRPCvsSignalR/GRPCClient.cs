using Grpc.Core;
using ModelLibrary.GRPC;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ModelLibrary.GRPC.MeteoriteLandingsService;

namespace RESTvsGRPCvsSignalR;

public class GRPCClient
{
  private readonly Channel channel;
  private readonly MeteoriteLandingsServiceClient client;

  public GRPCClient()
  {
    channel = new Channel("localhost:6000", ChannelCredentials.Insecure);
    client = new MeteoriteLandingsServiceClient(channel);
  }

  public async Task<string> GetSmallPayloadAsync()
  {
    return (await client.GetVersionAsync(new EmptyRequest())).ApiVersion;
  }

  public async Task<List<string>> StreamSmallPayloadAsync()
  {
    var list = new List<string>();
    using var call = client.GetSmallPayload(new EmptyRequest());
    while (await call.ResponseStream.MoveNext()) list.Add(call.ResponseStream.Current.ApiVersion);

    return list;
  }

  public async Task<List<MeteoriteLanding>> StreamLargePayloadAsync()
  {
    var meteoriteLandings = new List<MeteoriteLanding>();

    using var call = client.GetLargePayload(new EmptyRequest());
    while (await call.ResponseStream.MoveNext()) meteoriteLandings.Add(call.ResponseStream.Current);

    return meteoriteLandings;
  }

  public async Task<IList<MeteoriteLanding>> GetLargePayloadAsListAsync()
  {
    return (await client.GetLargePayloadAsListAsync(new EmptyRequest())).MeteoriteLandings;
  }

  public async Task<string> PostLargePayloadAsync(MeteoriteLandingList meteoriteLandings)
  {
    return (await client.PostLargePayloadAsync(meteoriteLandings)).Status;
  }
}