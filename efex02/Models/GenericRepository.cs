﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efex02.Models
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(long id);
        IEnumerable<T> GetAll();
        void Create(T newDataObject);
        void Update(T changedDataObject);
        void Delete(long id);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EFDatabaseContext context;
        public GenericRepository(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public virtual void Create(T newDataObject)
        {
            context.Add<T>(newDataObject);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.Remove<T>(Get(id));
            context.SaveChanges();
        }

        public T Get(long id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T changedDataObject)
        {
            context.Update<T>(changedDataObject);
            context.SaveChanges();
        }
    }
}
