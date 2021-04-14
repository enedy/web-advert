using Employee.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Employee.Core.Data;
using Employee.Domain.Entities;
using Employee.Domain.Repository;

namespace Employee.Data.Repository.Oracle
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OracleContext _context;
        public EmployeeRepository(OracleContext oracleContext)
        {
            _context = oracleContext;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Employee> GetEmployeeFirstAsync()
        {
            return await _context.Employee.FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
