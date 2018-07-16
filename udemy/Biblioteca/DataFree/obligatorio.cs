using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFree
{
    public interface obligatorio<T>
    {
        void crear(T obj);
        void update(T obj);
        void delete(T obj);
        void find(ref T obj);
        void findAll(ref List<T> obj);
    }
}
