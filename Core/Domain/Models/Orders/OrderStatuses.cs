using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Orders
{
    public enum OrderStatuses
    {
        Pending=0,
        PaymentReceived=1,
        PaymentFailed=2
    }
}
