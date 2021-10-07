using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppm.model.common
{
    public interface IOperation<T>
    {
        Result Add(T t);
        DataResult<T> ListAll();
        Result Remove(int id);
    }
}
