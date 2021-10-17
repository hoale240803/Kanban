using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.DataModels
{
    public partial class Buyer
    {
        public Buyer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string IdentityGuid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
