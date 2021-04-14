using Employee.Domain.DTOs;
using System.Threading.Tasks;

namespace Employee.Domain.Queries
{
    public interface ISynchronizationQueries
    {
        Task<TesteDTO> GetSynchronizationFirstAsync();
    }
}
