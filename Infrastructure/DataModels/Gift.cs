using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.DataModels
{
    public partial class Gift
    {
        public Gift()
        {
            RemptionGifts = new HashSet<RemptionGift>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public int? Point { get; set; }
        public string Status { get; set; }

        public virtual ICollection<RemptionGift> RemptionGifts { get; set; }
    }
}
