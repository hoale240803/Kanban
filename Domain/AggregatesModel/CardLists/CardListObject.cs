using Domain.AggregatesModel.Users;
using Domain.SeedWork;
using System;

namespace Domain.AggregatesModel.CardLists
{
    public class CardListObject : Entity, IAggregateRoot
    {
        public string Title { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public int? IdUser { get; set; }
        public int? IdRedemption { get; set; }

        //public virtual RedemptionObject IdRedemptionNavigation { get; set; }
        public virtual UserObject IdUserNavigation { get; set; }

        public CardListObject(string title, int idUser)
        {
            Title = title;
            IdUser = idUser;
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