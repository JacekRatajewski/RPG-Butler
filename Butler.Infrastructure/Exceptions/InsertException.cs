using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Infrastructure.Exceptions
{
    internal class InsertException : Exception
    {
        public InsertException(Exception ex) : base(ex.GetBaseException().Message) { }
        public InsertException(Exception ex, ulong id) : base(ex.GetBaseException().Message + $"ServerId:{id}") { }
    }
}
