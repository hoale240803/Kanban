using Domain.AggregatesModel.CardLists;
using Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace Domain.AggregatesModel.Redemptions
{
    internal class RedemptionObject : Entity, IAggregateRoot
    {
        public string TypeOfRedemption { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdGift { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }

        //public virtual EmployeeObject IdEmployeeNavigation { get; set; }
        public virtual ICollection<CardListObject> CardLists { get; set; }

        //public virtual ICollection<RemptionGift> RemptionGifts { get; set; }
    }
}