using Abstraction;
using AutoMapper;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesManager(IUnitOfWork unitOfWork,IMapper mapper) : IServiceManager
    {

        //we will use lazy that when we call servicemanager it will not create
        // and return all types of services

        private readonly Lazy<IProductServices> _LazyproductServices=new Lazy<IProductServices>(()=>new ProductServices(unitOfWork,mapper));


        public IProductServices ProductServices 
            => _LazyproductServices.Value;
    }
}
