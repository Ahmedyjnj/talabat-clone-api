using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity:ModelBase<Tkey>
    {
        // we will use unit of work to make save we dont make it here  
        //unit of work reduce number of requests to db
        //only getall , getbyid that will work asynchronus

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, Tkey> spec);
        
        Task<TEntity> GetByIdAsync(Tkey id);

        Task<TEntity> GetByIdAsync(ISpecifications<TEntity, Tkey> spec);

        // we will make add and update and delete as void it not save or work async

        Task<int> CountAsync(ISpecifications<TEntity, Tkey> spec);



        void Add(TEntity entity);

        void Update(TEntity entity);


        void Delete(TEntity entity);












    }
}
