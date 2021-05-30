using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEindopdrachtBatselier.Exceptions
{
    public class StraatException : Exception
    {
        public StraatException(string msg) : base(msg) { }
        public StraatException(string msg, Exception exception) : base(msg, exception) { }
    }
}
