using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.DependencyInjection;
using SignalRAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR().AddMessagePackProtocol();


var app = builder.Build();

app.MapHub<MeteoriteLandingsHub>("/api", options => { options.Transports = HttpTransportType.WebSockets; });


app.Run();