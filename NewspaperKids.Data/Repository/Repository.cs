namespace NewspaperKids.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly IDbSet<T> set;

        public Repository(IDbSet<T> set)
        {
            this.set = set;
        }

        public void Add(T entity)
        {
            this.set.Add(entity);
        }

        public T FirstOrDefault()
        {
            return this.set.FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return this.set.FirstOrDefault(expression);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return this.set.Where(expression);
        }

        public T Find(int id)
        {
            return this.set.Find(id);
        }

        public int Count()
        {
            return this.set.Count();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return this.set.Count(expression);
        }

        public void Remove(T entity)
        {
            this.set.Remove(entity);
        }

        public void Remove(int id)
        {
            this.set.Remove(this.set?.Find(id));
        }

        public IEnumerable<T> Entities
        {
            get
            {
                return this.set;
            }
        }

        public bool Contains(Expression<Func<T, bool>> expression)
        {
            return this.set.Any(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return this.set.Any(expression);
        }
    }
}