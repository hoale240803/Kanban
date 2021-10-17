using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.DataModels
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public int OrderId { get; set; }
        public string PictureUrl { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }

        public virtual Order Order { get; set; }
    }
}
