using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Aplication.Abstracts.Results
{
    public class IBaseResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}
