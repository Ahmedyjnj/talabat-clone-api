using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class SpecificationEvaluator
    {
        //create query
        //context.set<TEntity>() ; => input query parameter
        public static IQueryable<TEntity> CreateQuery<TEntity, Tkey>(IQueryable<TEntity> InputQuery, ISpecifications<TEntity, Tkey> spec) where TEntity : ModelBase<Tkey>
        {
            var query = InputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if (spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }


            if (spec.IncludeExpressions is not null && spec.IncludeExpressions.Count>0)
            {//he will use aggregate that add in seqance
                //route academy
                //route academy .net
                //route academy .net core

                query = spec.IncludeExpressions.Aggregate(query,(currentquery,exp)=>currentquery.Include(exp));
                
            }

            if (spec.IsPaginated == true)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            return query;
               

        }



    }
}
