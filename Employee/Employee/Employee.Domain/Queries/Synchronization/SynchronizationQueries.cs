using Employee.Domain.DTOs;
using Employee.Domain.Repository;
using System.Threading.Tasks;

namespace Employee.Domain.Queries
{
    public class SynchronizationQueries : ISynchronizationQueries
    {
        private readonly ISynchronizationRepository _synchronizationRepository;
        public SynchronizationQueries(ISynchronizationRepository synchronizationRepository)
        {
            _synchronizationRepository = synchronizationRepository;
        }

        public async Task<TesteDTO> GetSynchronizationFirstAsync()
        {
            var sync = await _synchronizationRepository.GetSynchronizationFirstAsync();

            return new TesteDTO()
            {
                CompanyId = sync.CompanyId,
                Id = sync.Id
            };
        }
    }
}
