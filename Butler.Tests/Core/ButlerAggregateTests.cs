using Butler.Core.Exceptions;
using Butler.Core;
using Butler.Core.ValueObjects;
using NUnit.Framework;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;
using Moq;
using System;

namespace Butler.Tests.Core
{
    public class Tests
    {
        internal AuthVO AUTH_PASS = new AuthVO { Token = "test", Type = TokenType.Bot };
        internal Mock<DiscordSocketClient> DISCORD_CLI_MOCK = new Mock<DiscordSocketClient>();
        internal Butler.Core.Entities.Discord DISCORD { get; private set; }
        internal ButlerAggregate BUTLER { get; private set; }

        [SetUp]
        public void Setup()
        {
            DISCORD = Butler.Core.Entities.Discord.Create(DISCORD_CLI_MOCK.Object);
            BUTLER = ButlerAggregate.Create(AUTH_PASS, DISCORD);
        }

        [Test]
        public void When_Token_Is_Null_Then_Throw_TokenValidationException()
        {
            Assert.Throws<TokenValidationException>(() => ButlerAggregate.Create(new AuthVO(), DISCORD));
        }

        [Test]
        public void When_Token_Type_Is_Null_Then_Throw_TokenValidationException()
        {
            Assert.Throws<TokenValidationException>(() => ButlerAggregate.Create(new AuthVO { Token = "test", Type = TokenType.Bearer }, DISCORD));
        }

        [Test]
        public void When_Token_Type_Is_Not_Type_Bot_Then_Throw_TokenValidationException()
        {
            Assert.Throws<TokenValidationException>(() => ButlerAggregate.Create(new AuthVO { Token = "test", Type = TokenType.Bearer }, DISCORD));
        }

        [Test]
        public void When_Discord_Is_Null_Then_Throw_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ButlerAggregate.Create(AUTH_PASS, null));
        }
    }
}