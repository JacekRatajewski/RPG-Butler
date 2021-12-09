using Butler.Aplication.DTO;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Aplication.Handlers.Commands.Extensions
{
    internal static class SocketGuildExtensions
    {
        internal static ServerDto AsDto(this SocketGuild value) =>
            new ServerDto
            {
                Id = value.Id,
                Name = value.Name
            };
    }
}
