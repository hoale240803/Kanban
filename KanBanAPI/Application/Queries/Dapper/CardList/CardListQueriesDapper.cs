using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Queries.Dapper.CardList
{
    public class CardListQueriesDapper : ICardListQueriesDapper
    {
        private string _connectionString = string.Empty;

        public CardListQueriesDapper(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<List<CardListViewModel>> getAllCardList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select o.[Id] as ordernumber,o.OrderDate as date, o.Description as description,
                        o.Address_City as city, o.Address_Country as country, o.Address_State as state, o.Address_Street as street, o.Address_ZipCode as zipcode,
                        os.Name as status,
                        oi.ProductName as productname, oi.Units as units, oi.UnitPrice as unitprice, oi.PictureUrl as pictureurl
                        FROM ordering.Orders o
                        LEFT JOIN ordering.Orderitems oi ON o.Id = oi.orderid
                        LEFT JOIN ordering.orderstatus os on o.OrderStatusId = os.Id
                        WHERE o.Id=@id"

                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapCardList(result);
            }
        }

        private List<CardListViewModel> MapCardList(dynamic result)
        {
            var cardLists = new List<CardListViewModel>();

            foreach (dynamic item in result)
            {
                var cardList = new CardListViewModel
                {
                    _idCardList = item.idCardList,
                    _title = item.title,
                    _taskCards = new List<TaskCardOverviewModel>(),
                };

                var taskCard = new TaskCardOverviewModel
                {
                    _idCardList = item.idCardList,
                    _idTaskCard = item.idTaskCard,
                    _taskCardTitle = item.title
                };

                cardList._taskCards.Add(taskCard);
                cardLists.Add(cardList);
            }
            return cardLists;
        }
    }
}