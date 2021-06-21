using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    class Tuple<First, Second>
    {
        public Tuple(First item1, Second item2)
        {
           this.Item1 = item1;
           this.Item2 = item2;
        }  

        public First Item1 { get; set; }
        public Second Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
