using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DeliveryMethodNotFoundException(int Dmid):NotFoundException($"Delivery method with id {Dmid} not found")
    {
    }
}
