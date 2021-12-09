using Butler.Core.Exceptions;
using Butler.Core.ValueObjects;
using Discord;
using Discord.WebSocket;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Butler.Tests")]
[assembly: InternalsVisibleTo("Butler.Aplication")]
namespace Butler.Core
{
    internal class ButlerAggregate
    {
        public AuthVO AuthVO { get; init; }
        public Entities.Discord Discord { get; init; }
        private ButlerAggregate(AuthVO auth, Entities.Discord discord)
        {
            Validate(auth, discord);
            AuthVO = auth;
            Discord = discord;
        }

        private void Validate(AuthVO auth, Entities.Discord discord)
        {
            if (auth is null || string.IsNullOrEmpty(auth.Token)) throw new TokenValidationException("Token is null or empty");
            if (auth is null || auth.Type is null) throw new TokenValidationException("Token type is null or empty");
            if (auth is null || auth.Type != TokenType.Bot) throw new TokenValidationException("Token type is type Bot");
            if (discord is null) throw new ArgumentNullException("Discord is null");
        }

        internal IList<SocketGuild> GetConnectedServers() => Discord.GetGuilds();

        internal static ButlerAggregate Create(AuthVO authVO, Entities.Discord discord) => new ButlerAggregate(authVO, discord);
    }
}
