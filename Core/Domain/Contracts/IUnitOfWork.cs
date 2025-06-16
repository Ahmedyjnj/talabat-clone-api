using Domain.Models;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        // in constructor of unit of work we will make object manually
        // a problem that he will make object to all of repositories

        IGenericRepository<TEntity, Tkey> GetRepository<TEntity,Tkey>()
            where TEntity : ModelBase<Tkey>;




        Task<int> SaveChangesAsync();





    }
}
