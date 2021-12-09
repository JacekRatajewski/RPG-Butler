using Butler.Core.Exceptions;
using Butler.Infrastructure.Application.Abstracts.Workers;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Aplication.Clients
{
    internal class DiscordClient : IWorker
    {
        private DiscordSocketClient _discordCli;
        private string _token;

        public DiscordClient(DiscordSocketClient discordCli, IConfiguration configuration)
        {
            _discordCli = discordCli;
            _token = configuration.GetSection("auth:token").Value;
        }

        public async Task ExecuteAsync()
        {
            await LoginAsync(_token, TokenType.Bot);
            await StartAsync();
        }

        internal async Task LoginAsync(string token, TokenType type)
        {
            try
            {
                await _discordCli.LoginAsync(type, token);
                _discordCli.Connected += () => Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new DiscrodLoginException(ex);
            }
        }

        internal async Task StartAsync()
        {
            try
            {
                await _discordCli.StartAsync();
                _discordCli.Ready += async () => await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new DiscrodStartException(ex);
            }
        }
    }
}
