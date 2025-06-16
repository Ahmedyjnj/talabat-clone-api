using Domain.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public abstract class  BaseSpecification<TEntity, Tkey> : ISpecifications<TEntity, Tkey> where TEntity : ModelBase<Tkey>
    {

        public BaseSpecification(Expression<Func<TEntity,bool>> PassedExpression)
        {


            Criteria = PassedExpression;



        }

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

        //we make it nullable because it will be null if a specification is not passed
        //or get all

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();
          
        
        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludeExpressions.Add(includeExpression);
        }



















    }
}
       

