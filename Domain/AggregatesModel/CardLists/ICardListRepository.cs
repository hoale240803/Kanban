using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CardLists
{
    public interface ICardListRepository : IRepository<CardListObject>
    {
        CardListObject Add(CardListObject order);

        bool Update(CardListObject order);

        bool UpdateTitle(string title);

        Task<CardListObject> GetAsync(int orderId);

        bool Delete(int id);
    }
}