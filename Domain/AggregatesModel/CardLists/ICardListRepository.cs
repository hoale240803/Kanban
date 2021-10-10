using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CardLists
{
    public interface ICardListRepository : IRepository<CardListObject>
    {
        CardListObject Add(CardListObject order);

        void Update(CardListObject order);

        bool UpdateTitle(string title, int idCardList);

        Task<CardListObject> GetAsync(int orderId);

        bool Delete(int id);
    }
}