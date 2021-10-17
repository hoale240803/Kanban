using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class Redemption
    {
        public Redemption()
        {
            CardLists = new HashSet<CardListEntity>();
            RemptionGifts = new HashSet<RemptionGift>();
        }

        public int Id { get; set; }
        public string TypeOfRedemption { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdGift { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<CardListEntity> CardLists { get; set; }
        public virtual ICollection<RemptionGift> RemptionGifts { get; set; }
    }
}
