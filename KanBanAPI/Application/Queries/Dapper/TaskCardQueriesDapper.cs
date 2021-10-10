using Dapper;
using Domain.AggregatesModel.Comments;
using Domain.AggregatesModel.TaskCard;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanBanAPI.Application.Queries.Dapper
{
    public class TaskCardQueriesDapper : ITaskCardQueries
    {
        private string _connectionString = string.Empty;

        public TaskCardQueriesDapper(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<CommentObject>> GetCommentsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<CommentObject>("SELECT * FROM ordering.cardtypes");
            }
        }

        public async Task<TaskCardViewModel> GetTaskCardAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // not yet
                var result = await connection.QueryAsync<dynamic>(
                   @"select o.[Id] as ordernumber,o.OrderDate as date, o.Description as description,
                        o.Address_City as city, o.Address_Country as country, o.Address_State as state, o.Address_Street as street, o.Address_ZipCode as zipcode,
                        os.Name as status,
                        oi.ProductName as productname, oi.Units as units, oi.UnitPrice as unitprice, oi.PictureUrl as pictureurl
                        FROM ordering.Orders o
                        LEFT JOIN ordering.Orderitems oi ON o.Id = oi.orderid
                        LEFT JOIN ordering.orderstatus os on o.OrderStatusId = os.Id
                        WHERE o.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapTaskCardObject(result);
            }
        }

        public Task<IEnumerable<TaskCardObject>> GetTaskCardsFromCardListAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        private TaskCardViewModel MapTaskCardObject(dynamic result)
        {
            var taskCard = new TaskCardViewModel
            {
                IdCardList = result[0].idCardList,
                IdUser = result[0].idUser,
                UserName = result[0].userName,
                EstimateTime = result[0].estimateTime,
                Duedate = result[0].duedate,
                Priority = result[0].priority,
                CreateAt = result[0].taskCardcreateAt,
                CreateBy = result[0].taskCardcreateBy,
                Status = result[0].status,
                ActualTime = result[0].actualTime,
                UpdateAt = result[0].taskCardUpdateAt,
                UpdateBy = result[0].taskCardUpdateBy,
                Title = result[0].title,
                Device = result[0].device,
                Location = result[0].location
            };

            foreach (dynamic item in result)
            {
                var attachment = new AttachmentViewModel
                {
                    FileId = item.fileId,
                    IdAttachment = item.idAttachment,
                    Category = item.attachmentCategory,
                    Path = item.path
                };
                taskCard.Attachments.Add(attachment);
            }

            foreach (dynamic item in result)
            {
                var comment = new CommentViewModel
                {
                    IdComment = item.idComment,
                    Content = item.commentContent,
                    CreateAt = item.createAtItem,
                    CreateBy = item.createBy
                };

                taskCard.Comments.Add(comment);
            }
            foreach (dynamic item in result)
            {
                var taggedUser = new TaggedUserViewModel
                {
                    Id = item.idTaggeduser,
                    Name = item.TaggedUserName,
                };
                taskCard.TaggedUsers.Add(taggedUser);
            }
            foreach (dynamic item in result)
            {
                var label = new HashTagLabelViewModel
                {
                    IdLabel = item.idLabel,
                    Title = item.labelTitle
                };
                taskCard.Labels.Add(label);
            }
            foreach (dynamic item in result)
            {
                var taskCardHistory = new TaskCardHistoryViewModel
                {
                    IdHistory = item.idHistory,
                    Content = item.historyContent
                };
                taskCard.Histories.Add(taskCardHistory);
            }

            return taskCard;
        }
    }
}