﻿using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesManager(IUnitOfWork unitOfWork,IMapper mapper,IBasketRepository basketRepository,UserManager<ApplicationUser> userManager,IConfiguration configuration) : IServiceManager
    {

        //we will use lazy that when we call servicemanager it will not create
        // and return all types of services

        private readonly Lazy<IProductServices> _LazyproductServices=new Lazy<IProductServices>(()=>new ProductServices(unitOfWork,mapper));


        public IProductServices ProductServices 
            => _LazyproductServices.Value;




        private readonly Lazy<IBasketServices>  basketServic = new Lazy<IBasketServices>(() => new BasketServices(basketRepository, mapper));


        
        public IBasketServices BasketServices => basketServic.Value;



        private readonly Lazy<IAuthenticationServices> authentication = new Lazy<IAuthenticationServices>(() => new AuthenticationServices(userManager,configuration,mapper));



        public IAuthenticationServices AuthenticationServices => authentication.Value;




        private readonly Lazy<IOrderServices> OrderServices = new Lazy<IOrderServices>(() => new OrderServices(mapper, basketRepository, unitOfWork));


        

        public IOrderServices orderServices => OrderServices.Value;
    }
}
