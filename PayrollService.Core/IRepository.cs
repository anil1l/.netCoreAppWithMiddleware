using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PayrollService.Core
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(int id);
        bool Save();
    }
}
