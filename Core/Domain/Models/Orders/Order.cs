using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Orders
{
    public class Order :ModelBase<Guid>
    {
        public string UserEmail { get; set; } = default;

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public OrderAddress ShipToAddress { get; set; } = default;

        public DeliveryMethod DeliveryMethod { get; set; } = default;

        [ForeignKey("DeliveryMethod")] //we will make relations in configuration
        public int DeliveryMethodId { get; set; }


        public OrderStatuses orderStatuses { get; set; } = OrderStatuses.Pending;

        public ICollection<OrderItem> Items { get; set; } = [];


        public decimal SubTotal { get;set; }

        //we will make total as drived attribute

        public decimal GetTotal() =>SubTotal+DeliveryMethod.Price;

    }
}
