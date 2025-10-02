using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Repository;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using DataLayer.Repositories;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyProjectContext _context;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private UserRepository _userRepository;
        private InterestRepository _interestRepository;
        private CommentRepository _commentRepository;
        private OrderRepository _orderRepository;
        private AddressRepository _addressRepository;
        private CartRepository _cartRepository;
        private DbContextTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(MyProjectContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }


        public ICategoryRepository Categories =>
            _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context));

        public IProductRepository Products =>
            _productRepository ?? (_productRepository = new ProductRepository(_context));

        public IUserRepository Users =>
            _userRepository ?? (_userRepository = new UserRepository(_context));

        public IInterestRepository Interests =>
            _interestRepository ?? (_interestRepository = new InterestRepository(_context));

        public ICommentRepository Comments =>
            _commentRepository ?? (_commentRepository = new CommentRepository(_context));

        public IOrderRepository Orders =>
            _orderRepository ?? (_orderRepository = new OrderRepository(_context));

        public IAddressRepository Addresses =>
            _addressRepository ?? (_addressRepository = new AddressRepository(_context));

        public ICartRepository Carts =>
            _cartRepository ?? (_cartRepository = new CartRepository(_context));

        // متد همزمان برای سازگاری
        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw new Exception("خطایی در ذخیره‌سازی رخ داده است", ex);
            }
        }

        // متد ناهمزمان
        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw new Exception("خطایی در ذخیره‌سازی رخ داده است", ex);
            }
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw new Exception("خطا در تایید تراکنش", ex);
            }
            finally
            {
                DisposeTransaction();
            }
        }


        public void RollbackTransaction()
        {
            try
            {
                _transaction?.Rollback();
            }
            catch (Exception ex)
            {
                // لاگ کنید اما خطا نیندازید
                System.Diagnostics.Debug.WriteLine("خطا در Rollback: " + ex.Message);
            }
            finally
            {
                DisposeTransaction();
            }
        }

        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DisposeTransaction();
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}

