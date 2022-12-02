using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository.Irepository
{
    public interface Irepository<T> where T:class
    {
        void Add(T entity); //add
        void Remove(int id); //delete
        void Remove(T entity);
        void Update(T entity); //update
        T Get(int id); //find
        ICollection<T> GetAll(
         Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string IncludeProperties = null
            );
     
    }
}
