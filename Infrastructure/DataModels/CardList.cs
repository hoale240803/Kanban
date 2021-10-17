using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.DataModels
{
    public partial class CardList
    {
        public CardList()
        {
            TaskCards = new HashSet<TaskCard>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Location { get; set; }
        public string Device { get; set; }
        public int? IdUser { get; set; }
        public int? IdRedemption { get; set; }

        public virtual Redemption IdRedemptionNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<TaskCard> TaskCards { get; set; }
    }
}
