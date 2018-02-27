using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ITUniver.Calc.DB.NH.Repositories
{
    public class NHBaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity
    {
        public virtual void Delete(long id)
        {
            var item = Find(id);

            if (item != null)
            {
                var session = Helper.GetCurrentSession();
                try
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(item);
                        transaction.Commit();
                    }
                }
                finally
                {
                    Helper.CloseSession();
                }
            }
        }

        public virtual T Find(long id)
        {
            var session = Helper.GetCurrentSession();

            return session.Get<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            var session = Helper.GetCurrentSession();

            return session.CreateCriteria<T>().List<T>();
        }

        protected IEnumerable<T> GetAll(Expression<Func<T, bool>> condition)
        {
            var session = Helper.GetCurrentSession();

            return session
                .QueryOver<T>()
                .And(condition)
                .List<T>();
        }

        public virtual IEnumerable<T> GetAll(string condition)
        {
            return GetAll();
        }

        public virtual void Save(T item)
        {
            var session = Helper.GetCurrentSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    transaction.Commit();
                }
            }
            finally
            {
                Helper.CloseSession();
            }
        }
    }
}
