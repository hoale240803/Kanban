using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DataModels
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int? BuyerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Description { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressState { get; set; }
        public string AddressStreet { get; set; }
        public string AddressZipCode { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Orderstatus OrderStatus { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
