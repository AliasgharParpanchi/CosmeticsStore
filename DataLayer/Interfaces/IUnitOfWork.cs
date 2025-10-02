using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        IInterestRepository Interests { get; }
        ICommentRepository Comments { get; }
        IOrderRepository Orders { get; }
        IAddressRepository Addresses { get; }
        ICartRepository Carts { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        int Complete();
        Task<int> CompleteAsync();
    }


}
