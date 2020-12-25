using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    class LegalEntity : Client
    {
        public LegalEntity(string fullName, bool capitalization, decimal startCopital) 
            : base(fullName, capitalization, startCopital)
        {
        }
    }
}
