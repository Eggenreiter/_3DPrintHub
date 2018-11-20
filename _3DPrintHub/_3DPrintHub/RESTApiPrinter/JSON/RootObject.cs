using System;
using System.Collections.Generic;
using System.Text;

namespace _3DPrintHub.RESTApiPrinter
{
    class RootObject
    {
        public Sd sd { get; set; }
        public State state { get; set; }
        public Temperature temperature { get; set; }
    }
}
