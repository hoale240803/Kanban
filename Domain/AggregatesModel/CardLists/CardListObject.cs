using Domain.AggregatesModel.TaskCard;
using Domain.AggregatesModel.Users;
using Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Domain.AggregatesModel.CardLists
{
    public class CardListObject : Entity, IAggregateRoot
    {

        public string _title { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public int? _idUser { get; set; }
        public int? _idRedemption { get; set; }

        //public virtual RedemptionObject IdRedemptionNavigation { get; set; }
        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method OrderAggrergateRoot.AddOrderItem() which includes behaviour.
        private readonly List<TaskCardObject> _taskCards;
        public IReadOnlyCollection<TaskCardObject> TaskCards => _taskCards;
        public virtual UserObject IdUserNavigation { get; set; }

        public CardListObject()
        {
            _taskCards = new List<TaskCardObject>();
        }
        public CardListObject(string title, int idUser)
        {
            _title = title;
            _idUser = idUser;
            _taskCards = new List<TaskCardObject>();
        }

        #region methods

        public bool AddCardListObject(string title, int idUser)
        {
            var newCardList = new CardListObject(title, idUser);

            return true;
        }

        #endregion methods
    }
}