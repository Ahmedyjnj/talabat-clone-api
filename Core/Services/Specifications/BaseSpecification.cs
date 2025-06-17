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

        #region criteria
        public BaseSpecification(Expression<Func<TEntity, bool>> PassedExpression)
        {


            Criteria = PassedExpression;



        }

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; } 
        #endregion

        //we make it nullable because it will be null if a specification is not passed
        //or get all

        #region Includes
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new List<Expression<Func<TEntity, object>>>();


        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludeExpressions.Add(includeExpression);
        }

        #endregion



        #region sorting


        public Expression<Func<TEntity, object>> OrderBy { get; private set; }
       

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

       
        protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExpression)
            =>OrderBy=OrderByExpression;


        protected void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExpression)
           => OrderByDesc = OrderByDescExpression;


        #endregion



        #region Pagination
         
        //now it [] a empty 
        //we make full proberty in query params to handle this 
        //no we need to add information of json in pagination
        //we need to add size index count


        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; set; }

        protected void ApplyPagination(int PageSize, int PageIndex)
        {
            Take = PageSize;
            Skip = ((PageIndex-1)*PageSize ) <0?0: ((PageIndex - 1) * PageSize);
            IsPaginated = true;
        }

        #endregion



    }
}
       

