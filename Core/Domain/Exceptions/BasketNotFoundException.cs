using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BasketNotFoundException(string Key):NotFoundException($"Basket with Key:{Key} is not found")
    {
    }
}
