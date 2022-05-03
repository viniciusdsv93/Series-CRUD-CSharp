using System.Collections.Generic;

namespace _21seriesCRUD.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ReturnList();
        T ReturnById(int Id);
        void Insert(T entity);
        void Delete(int Id);
        void Update(int Id, T entity);
        int NextId();
    }
}