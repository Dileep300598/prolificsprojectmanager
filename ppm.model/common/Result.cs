using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppm.model.common
{
 public class Result
    {
        public bool isSucess { get; set; }
        public string status { get; set; }
    }
    public class DataResult<T> : Result
    {
        public IEnumerable<T> results { get; set; }
    }
}