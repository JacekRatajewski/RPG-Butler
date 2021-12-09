using Butler.Core.Exceptions;
using Discord.WebSocket;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Tests.Core.Entities
{
    internal class DiscrodTests
    {
        public Mock<DiscordSocketClient> DISCORD_CLI { get; private set; }
        public Butler.Core.Entities.Discord DISCORD { get; private set; }
        public Guid SERVER_ID_PASS => Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            DISCORD_CLI = new Mock<DiscordSocketClient>();
            DISCORD = Butler.Core.Entities.Discord.Create(DISCORD_CLI.Object);
        }

        [Test]
        public void When_Discord_Cli_Is_Null_Then_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Butler.Core.Entities.Discord.Create(null));
        }
    }
}
