using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.DependencyInjection;
using SignalRAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(options => { options.MaximumReceiveMessageSize = 65536 * 8; }).AddMessagePackProtocol();


var app = builder.Build();

app.MapHub<MeteoriteLandingsHub>("/api", options =>
{
  options.Transports = HttpTransportType.WebSockets;
  options.TransportMaxBufferSize = 65536 * 8;
  options.ApplicationMaxBufferSize = 65536 * 8;
});


app.Run();