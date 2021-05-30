using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEindopdrachtBatselier.Exceptions
{
    public class AdresException : Exception
    {
        public AdresException(string msg) : base(msg) { }
        public AdresException(string msg, Exception exception) : base(msg, exception) { }
    }
}
