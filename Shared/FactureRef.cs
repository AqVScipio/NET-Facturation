using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public class FactureRef
    {
        public string FReference { get; set; }
        public FactureRef(string fRef)
        {
            FReference = fRef;
        }
    }
}
