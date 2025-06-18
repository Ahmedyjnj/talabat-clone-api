using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; }

       

        public List<BasketItem> Items { get; set; } = [];

        //this is temporary data not persisted in the database in Ram even we close browser it still stored
        //we will not make it inherit from model base we will isolate it from database

        //this is using to cashing to reduce the number of calls to the database
        //Redis or in memory cache is the real time Data platform 

        //to install redis we will install subsystem ubentu 
    }
}
