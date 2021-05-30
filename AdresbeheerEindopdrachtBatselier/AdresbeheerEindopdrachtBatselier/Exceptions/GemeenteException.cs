using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEindopdrachtBatselier.Exceptions
{
    public class GemeenteException : Exception
    {
        public GemeenteException(string msg) : base(msg) { }
        public GemeenteException(string msg, Exception exception) : base(msg, exception) { }
    }
}
