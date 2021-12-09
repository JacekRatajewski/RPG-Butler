using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Infrastructure.Application.Abstracts.Workers
{
    internal interface IWorker
    {
        Task ExecuteAsync();
    }
}
