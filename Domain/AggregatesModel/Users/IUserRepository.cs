using Domain.AggregatesModel.Users;
using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IUserRepository : IRepository<UserObject>
    {
        UserObject Login(UserObject order);

        UserObject Register(UserObject order);

        void Update(UserObject order);

        Task<UserObject> GetAsync(int orderId);

        void Delete(string id);
    }
}