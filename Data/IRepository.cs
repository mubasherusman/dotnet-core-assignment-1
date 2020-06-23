using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Data
{
    interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> FetchAll();
        Task<T> FetchById(int id);
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
