namespace NewspaperKids.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> Entities { get; }

        void Add(T entity);

        T FirstOrDefault();

        T FirstOrDefault(Expression<Func<T, bool>> expression);

        IEnumerable<T> Where(Expression<Func<T, bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);

        bool Contains(Expression<Func<T, bool>> expression);

        T Find(int id);

        int Count();

        int Count(Expression<Func<T, bool>> expression);

        void Remove(T entity);

        void Remove(int id);
    }
}