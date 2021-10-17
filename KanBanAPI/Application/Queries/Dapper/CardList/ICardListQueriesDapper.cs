using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Queries.Dapper.CardList
{
    public interface ICardListQueriesDapper
    {
        Task<List<CardListViewModel>> getAllCardList();
    }
}