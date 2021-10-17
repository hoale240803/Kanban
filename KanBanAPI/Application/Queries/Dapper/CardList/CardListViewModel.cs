using Domain.AggregatesModel.TaskCard;
using System.Collections.Generic;

namespace KanBanAPI.Application.Queries.Dapper.CardList
{
    public record CardListViewModel
    {
        public int _idCardList { get; set; }
        public string _title { get; set; }
        public List<TaskCardOverviewModel> _taskCards { get; set; }
    }
    public record TaskCardOverviewModel
    {
        public int _idCardList { get; set; }
        public int _idTaskCard { get; set; }
        public string _taskCardTitle { get; set; }
    }
}