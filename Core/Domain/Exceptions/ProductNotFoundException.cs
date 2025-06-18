using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ProductNotFoundException(int Id) : NotFoundException($"Product With Id :{Id} is not found ")
    {

    }
   
}
