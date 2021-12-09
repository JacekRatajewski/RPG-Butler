using Butler.Core.Exceptions;
using Discord;
using Discord.WebSocket;

namespace Butler.Core.Entities
{
    internal class Discord
    {
        private DiscordSocketClient _discordCli { get; }
        internal Discord(DiscordSocketClient discordCli)
        {
            Validate(discordCli);
            _discordCli = discordCli;
        }

        private void Validate(DiscordSocketClient discordCli)
        {
            if (discordCli is null) throw new ArgumentNullException("DiscordCli is null");
        }

        internal static Discord Create(DiscordSocketClient discordCli) => new Discord(discordCli);

        internal IList<SocketGuild> GetGuilds() => _discordCli.Guilds.ToList();
    }
}
