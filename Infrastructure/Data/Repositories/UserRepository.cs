using Domain.AggregatesModel.Users;
using Domain.SeedWork;
using Domain.Users;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KanbanContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UserRepository(KanbanContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserObject> GetAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public UserObject Login(UserObject order)
        {
            throw new NotImplementedException();
        }

        public UserObject Register(UserObject order)
        {
            throw new NotImplementedException();
        }

        public void Update(UserObject order)
        {
            throw new NotImplementedException();
        }
    }
}