using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess;

namespace DataAccess
{
    public class BaseRepository<T> : IDisposable where T : class 

    {
        protected readonly SocialTapContext _context;

        public BaseRepository()
        {
            _context = new SocialTapContext();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T model)
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> models)
        {
            _context.Set<T>().AddRange(models);
            _context.SaveChanges();
        }

        public void Remove(T model)
        {
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}