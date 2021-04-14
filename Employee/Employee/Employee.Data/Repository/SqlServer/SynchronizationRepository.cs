using Employee.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Employee.Core.Data;
using Employee.Domain.Entities;
using Employee.Domain.Repository;

namespace Employee.Data.Repository.SqlServer
{
    public class SynchronizationRepository : ISynchronizationRepository
    {
        private readonly SqlServerContext _context;
        public SynchronizationRepository(SqlServerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Synchronization> GetSynchronizationFirstAsync()
        {
            return await _context.Synchronization.FirstOrDefaultAsync(x => x.Id > 0);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
