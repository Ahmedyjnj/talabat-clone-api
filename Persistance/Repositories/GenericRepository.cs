using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class GenericRepository<TEntity, Tkey>(StoreDBContext context): IGenericRepository<TEntity, Tkey> where TEntity : ModelBase<Tkey>
    {


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(Tkey id)
        =>await context.Set<TEntity>().FindAsync(id);


        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, Tkey> spec)
        {
            //we need to make class to build query as order 


            return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>() , spec).ToListAsync();

        }

        public async Task<TEntity> GetByIdAsync(ISpecifications<TEntity, Tkey> spec)
        {
            return await SpecificationEvaluator.CreateQuery(context.Set<TEntity>(), spec).FirstOrDefaultAsync();

        }




        public void Add(TEntity entity)
        => context.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity)
        => context.Set<TEntity>().Remove(entity);



        public void Update(TEntity entity)
        => context.Set<TEntity>().Update(entity);

      




        // we will make save as unit of work in unit of work class
    }
}
