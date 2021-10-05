using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class RemptionGift
    {
        public int IdRedemption { get; set; }
        public int IdGift { get; set; }
        public int? Quantity { get; set; }

        public virtual Gift IdGiftNavigation { get; set; }
        public virtual Redemption IdRedemptionNavigation { get; set; }
    }
}
