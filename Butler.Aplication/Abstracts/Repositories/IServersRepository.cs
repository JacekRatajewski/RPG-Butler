using Butler.Aplication.DTO;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Butler.Infrastructure")]
[assembly: InternalsVisibleTo("Butler.Api")]
namespace Butler.Aplication.Abstracts.Repositories
{
    internal interface IServersRepository
    {
        Task<ulong> Create(ServerDto server);
        Task<IEnumerable<ulong>> CreateMany(IEnumerable<ServerDto> enumerable);
    }
}
