using System;
using System.Collections.Generic;
using System.Text;

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
