using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Core.Exceptions
{
    internal class DiscrodStartException : Exception
    {
        public DiscrodStartException(Exception ex) : base(ex.GetBaseException().Message) { }
    }
}
