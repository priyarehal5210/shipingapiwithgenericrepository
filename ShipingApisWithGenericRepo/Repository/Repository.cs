using Microsoft.EntityFrameworkCore;
using ShipingApisWithGenericRepo.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShipingApisWithGenericRepo.Repository
{
    public class Repository<T> : Irepository<T> where T : class
    {
        private readonly ApplicationDbContext con;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext conn)
        {
            con = conn;
            dbSet = con.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }


        public T Get(int id)
        {
            return dbSet.Find(id);
        }

      

        public ICollection<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (IncludeProperties != null)
            {
                foreach (var includeprop in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            if (OrderBy != null)
                return OrderBy(query).ToList();
            return query.ToList();
        }

        public void Remove(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
