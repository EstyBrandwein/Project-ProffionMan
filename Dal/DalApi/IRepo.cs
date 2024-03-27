using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T t);
        T Update(int id,T t);
        T Delete(int id);
    }
}
