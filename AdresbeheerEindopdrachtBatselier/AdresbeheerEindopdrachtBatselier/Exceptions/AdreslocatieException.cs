using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEindopdrachtBatselier.Exceptions
{
    public class AdreslocatieException : Exception
    {
        public AdreslocatieException(string msg) : base(msg) { }
        public AdreslocatieException(string msg, Exception exception) : base(msg, exception) { }
    }
}
