using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IUser : IRepository<UserObject>
    {
        UserObject Login(UserObject order);

        UserObject Register(UserObject order);

        void Update(UserObject order);

        Task<UserObject> GetAsync(int orderId);

        void Delete(string id);
    }
}