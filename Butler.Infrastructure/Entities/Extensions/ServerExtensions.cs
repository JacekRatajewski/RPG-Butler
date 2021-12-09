using Butler.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Infrastructure.Entities.Extensions
{
    internal static class ServerExtensions
    {
        internal static Server AsEntity(this ServerDto value) =>
            new Server
            {
                Id = value.Id,
                CreatedDate = DateTime.Now,
                IsConnected = false,
                Name = value.Name
            };
    }
}
