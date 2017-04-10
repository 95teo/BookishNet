using System.Collections.Generic;

namespace BookishNet.ServiceLayer.Interfaces
{
    public interface IGenericService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}