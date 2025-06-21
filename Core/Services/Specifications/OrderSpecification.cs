using Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class OrderSpecification :BaseSpecification<Order,Guid>
    {

        public OrderSpecification(string email) : base(x => x.UserEmail == email)
        {
            AddInclude(x => x.Items);
            AddInclude(x => x.DeliveryMethod);
           

            AddOrderByDesc(o=>o.OrderDate);
        }


        public OrderSpecification(Guid id) : base(o=>o.Id==id)
        {
            AddInclude(x => x.Items);
            AddInclude(x => x.DeliveryMethod);
            

           
        }
    }
}
