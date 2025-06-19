using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IServiceManager
    {


        IProductServices ProductServices { get; }

        IBasketServices BasketServices { get; }



        IAuthenticationServices AuthenticationServices { get; }





    }
}
