using GrpcAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();

var app = builder.Build();
app.UseRouting();

app.MapGrpcService<MeteoriteLandingsServiceImpl>();

app.Run();