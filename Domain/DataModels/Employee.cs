using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class Employee
    {
        public Employee()
        {
            Redemptions = new HashSet<Redemption>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdRedemption { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Redemption> Redemptions { get; set; }
    }
}
