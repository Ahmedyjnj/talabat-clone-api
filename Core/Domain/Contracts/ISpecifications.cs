﻿using Domain.Models;
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

        public Expression<Func<TEntity, bool>>? Criteria { get; }




        public List<Expression<Func<TEntity,object>>> IncludeExpressions { get; }



        //we will make base class to implement these and make product inherit it 
    }
}
