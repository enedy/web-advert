using Employee.Domain.Entities;
using System.Threading.Tasks;
using Employee.Core.Data;

namespace Employee.Domain.Repository
{
    public interface ISynchronizationRepository : IRepository<Synchronization>
    {
        Task<Synchronization> GetSynchronizationFirstAsync();
    }
}
