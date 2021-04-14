using System.Threading.Tasks;

namespace Employee.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
