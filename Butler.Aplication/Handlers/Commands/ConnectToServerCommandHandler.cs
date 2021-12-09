using Butler.Aplication.Abstracts.Repositories;
using Butler.Aplication.Abstracts.Results;
using Butler.Aplication.Commands;
using Butler.Aplication.Handlers.Commands.Extensions;
using Butler.Aplication.Results;
using Butler.Core;
using Butler.Core.ValueObjects;
using Discord.WebSocket;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Butler.Aplication.Handlers.Commands
{
    internal class ConnectToServerCommandHandler : IRequestHandler<ConnectToServerCommand, IBaseResult>
    {
        private IConfiguration _configuration;
        private DiscordSocketClient _discordCli;
        private IServersRepository _servers;

        public ConnectToServerCommandHandler(IConfiguration configuration, DiscordSocketClient discordCli, IServersRepository servers)
        {
            _configuration = configuration;
            _discordCli = discordCli;
            _servers = servers;
        }

        public async Task<IBaseResult> Handle(ConnectToServerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = ButlerAggregate.Create(
                    MapAuthVO(),
                    MapDiscrodEntity()
                    );
                var servers = entity.GetConnectedServers();
                await _servers.CreateMany(servers.Select(x => x.AsDto()));
                return BaseResult.CreateSuccess();
            }
            catch (Exception ex)
            {
                return BaseResult.CreateFail(ex.GetBaseException().Message);
            }
        }

        private Core.Entities.Discord MapDiscrodEntity() => Core.Entities.Discord.Create(_discordCli);

        private AuthVO MapAuthVO() => new AuthVO { Token = _configuration.GetSection("auth:token").Value, Type = Discord.TokenType.Bot };
    }
}
