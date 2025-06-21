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
        public Order()
        {
            
        }
        public Order(string userEmail, decimal subTotal, ICollection<OrderItem> items, OrderAddress shipToAddress, DeliveryMethod deliveryMethod)
        {
            UserEmail = userEmail;
            SubTotal = subTotal;
            Items = items;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
        }

        public string UserEmail { get; set; } = default!;

        public decimal SubTotal { get; set; }

        public ICollection<OrderItem> Items { get; set; } = [];

        public OrderAddress ShipToAddress { get; set; } = default!;

        public DeliveryMethod DeliveryMethod { get; set; } = default!;

        [ForeignKey("DeliveryMethod")] //we will make relations in configuration
        public int DeliveryMethodId { get; set; }


        public OrderStatuses orderStatuses { get; set; } = OrderStatuses.Pending;

       
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
      
        //we will make total as drived attribute

        public decimal GetTotal() =>SubTotal+DeliveryMethod.Price;

    }
}
