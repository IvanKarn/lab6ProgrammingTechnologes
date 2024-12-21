using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6ProgrammingTechnologes
{
    public class ValueError : Exception
    {
        public ValueError()
        {
        }

        public ValueError(string? message) : base(message)
        {
        }
    }
}
