using Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class CardListEntity : Entity, IAggregateRoot
    {


        public string Title { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public string IdUser { get; set; }
        public int? IdRedemption { get; set; }

        public virtual Redemption IdRedemptionNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<TaskCardEntity> TaskCards { get; set; }

        public CardListEntity()
        {
            TaskCards = new HashSet<TaskCardEntity>();
        }
        public CardListEntity(string title, string idUser)
        {
            Title = title;
            IdUser = idUser;

        }
    }
}