using IMS.Model.Models;
using System.Threading.Tasks;

namespace IMS.Model.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        Task<int> Commit();
    }
}
