using Butler.Aplication.Abstracts.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Aplication.Commands
{
    public class ConnectToServerCommand : IRequest<IBaseResult>
    {
        public ulong ServerId { get; set; }
    }
}
