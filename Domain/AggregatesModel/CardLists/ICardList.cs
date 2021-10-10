using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CardLists
{
    public interface ICardList : IRepository<CardListObject>
    {
        CardListObject Add(CardListObject order);

        void Update(CardListObject order);

        Task<CardListObject> GetAsync(int orderId);

        void Delete(string id);
    }
}