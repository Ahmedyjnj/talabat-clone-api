using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntity,Tkey> where TEntity : ModelBase<Tkey>
    {

         Expression<Func<TEntity, bool>>? Criteria { get; }




         List<Expression<Func<TEntity,object>>> IncludeExpressions { get; }



        //we will make base class to implement these and make product inherit it 


        //we need to make a expression to sort the data

        
        Expression<Func<TEntity, object>> OrderBy { get; }


        Expression<Func<TEntity, object>> OrderByDesc { get; }


        public int Take { get;  }
        public int Skip { get;  }

        public bool IsPaginated { get; set; }
    }
}
