using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class Orderstatus
    {
        public Orderstatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
