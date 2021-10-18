using Domain.DataModels;
using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CardLists
{
    public interface ICardListRepository : IRepository<CardListEntity>
    {
        CardListEntity Add(CardListEntity order);

        void Update(CardListEntity order);

        bool UpdateTitle(string title, string idUser, int idCardList);

        Task<CardListEntity> GetAsync(int orderId);

        bool Delete(int id);
    }
}