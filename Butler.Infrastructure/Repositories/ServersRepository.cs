using Butler.Aplication.Abstracts.Repositories;
using Butler.Aplication.DTO;
using Butler.Infrastructure.Contexts;
using Butler.Infrastructure.Entities.Extensions;
using Butler.Infrastructure.Exceptions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Butler.Api")]
namespace Butler.Infrastructure.Repositories
{
    internal class ServersRepository : IServersRepository
    {
        private AtlasContext _context;

        public ServersRepository(AtlasContext context)
        {
            _context = context;
        }

        public async Task<ulong> Create(ServerDto server)
        {
            try
            {
                await _context.Servers.InsertOneAsync(server.AsEntity());
                return server.Id;
            }
            catch (Exception ex)
            {
                throw new InsertException(ex, server.Id);
            }
        }

        public async Task<IEnumerable<ulong>> CreateMany(IEnumerable<ServerDto> servers)
        {
            try
            {
                await _context.Servers.InsertManyAsync(servers.Select(x => x.AsEntity()));
                return servers.Select(x => x.Id);
            }
            catch (Exception ex)
            {
                throw new InsertException(ex);
            }
        }
    }
}
