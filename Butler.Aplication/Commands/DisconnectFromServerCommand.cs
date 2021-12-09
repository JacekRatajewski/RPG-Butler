using Butler.Aplication.Abstracts.Results;
using Discord.Net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Aplication.Commands
{
    public class DisconnectFromServerCommand : IRequest<IBaseResult>
    {
        public ulong ServerId { get; set; }
    }
}
