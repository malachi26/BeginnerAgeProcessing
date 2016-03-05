using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginnerAgeProcessing
{
    class Sibling : Human
    {
        public DateTime DOB { get; set; }
        public Sibling (DateTime dateOfBirth)
        {
            this.DOB = dateOfBirth;
        }
    }
}
