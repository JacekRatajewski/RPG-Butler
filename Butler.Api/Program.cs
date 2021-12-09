using Butler.Aplication.Abstracts.Repositories;
using Butler.Aplication.Clients;
using Butler.Infrastructure.Contexts;
using Butler.Infrastructure.Repositories;
using Butler.Infrastructure.Workers;
using Discord.WebSocket;
using MediatR;
//SERVICES
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<DiscordSocketClient>();

//CONTEXTS
builder.Services.AddSingleton<AtlasContext>();

//REPOSITORIES
builder.Services.AddTransient<IServersRepository, ServersRepository>();

builder.Services.AddTransient<DiscordClient>();
builder.Services.AddHostedService<Worker<DiscordClient>>();

//APPLICATION
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
