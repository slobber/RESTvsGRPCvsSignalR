using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ModelLibrary.Data;

public static class MeteoriteLandingData
{
  private static string meteoriteLandingsJson;

  public static string MeteoriteLandingsJson
  {
    get
    {
      if (meteoriteLandingsJson == null)
      {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceStream = assembly.GetManifestResourceStream("ModelLibrary.Data.MeteoriteLandings.json");

        using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
        {
          meteoriteLandingsJson = reader.ReadToEnd();
        }
      }

      return meteoriteLandingsJson;
    }
  }


  private static List<SignalR.MeteoriteLanding> signalRMeteoriteLandings;

  public static List<SignalR.MeteoriteLanding> SignalRMeteoriteLandings
  {
    get
    {
      if (signalRMeteoriteLandings == null)
        signalRMeteoriteLandings = JsonConvert.DeserializeObject<List<SignalR.MeteoriteLanding>>(MeteoriteLandingsJson);
      return signalRMeteoriteLandings;
    }
  }

  private static List<REST.MeteoriteLanding> restMeteoriteLandings;

  public static List<REST.MeteoriteLanding> RestMeteoriteLandings
  {
    get
    {
      if (restMeteoriteLandings == null)
        restMeteoriteLandings = JsonConvert.DeserializeObject<List<REST.MeteoriteLanding>>(MeteoriteLandingsJson);
      return restMeteoriteLandings;
    }
  }

  private static List<GRPC.MeteoriteLanding> grpcMeteoriteLandings;

  public static List<GRPC.MeteoriteLanding> GrpcMeteoriteLandings
  {
    get
    {
      if (grpcMeteoriteLandings == null)
        grpcMeteoriteLandings =
          JsonConvert.DeserializeObject<List<GRPC.MeteoriteLanding>>(MeteoriteLandingsJson,
            new ProtobufJsonConvertor());
      return grpcMeteoriteLandings;
    }
  }

  private static GRPC.MeteoriteLandingList grpcMeteoriteLandingList;

  public static GRPC.MeteoriteLandingList GrpcMeteoriteLandingList
  {
    get
    {
      if (grpcMeteoriteLandingList == null)
      {
        grpcMeteoriteLandingList = new GRPC.MeteoriteLandingList();
        grpcMeteoriteLandingList.MeteoriteLandings.AddRange(GrpcMeteoriteLandings);
      }

      return grpcMeteoriteLandingList;
    }
  }
}