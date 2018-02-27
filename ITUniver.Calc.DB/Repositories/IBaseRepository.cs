using ITUniver.Calc.DB.Models;
using System.Collections.Generic;

namespace ITUniver.Calc.DB.Repositories
{
    public interface IEntity
    {
        long Id { get; set; }
    }

    public interface IBaseRepository<T>
        where T : IEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(string condition);

        T Find(long id);

        void Save(T item);

        void Delete(long id);
    }
}
