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
    _categoryRepository = new CategoryRepository(_context);

        public IProductRepository Products =>
            _productRepository = new ProductRepository(_context);

        public IUserRepository Users =>
            _userRepository = new UserRepository(_context); 
        
        public IInterestRepository Interests =>
            _interestRepository = new InterestRepository(_context);  
        
        public ICommentRepository Comments =>
            _commentRepository = new CommentRepository(_context);        
        public IOrderRepository Orders =>
            _orderRepository = new OrderRepository(_context);        
        public IAddressRepository Addresses =>
            _addressRepository = new AddressRepository(_context);       
        public ICartRepository Carts =>
            _cartRepository = new CartRepository(_context);

        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Rollback();
                throw new NotImplementedException("خطایی در ذخیره سازی رخ داده است دوباره امتحان کنید", ex);
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            catch (Exception ex)
            {
                // مدیریت خطاهای احتمالی در Rollback
                throw new NotImplementedException("خطایی در دیتابیس رخ داده است", ex);
            }
            finally
            {
                DisposeTransaction();
            }
        }

        private void DisposeTransaction()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DisposeTransaction();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
