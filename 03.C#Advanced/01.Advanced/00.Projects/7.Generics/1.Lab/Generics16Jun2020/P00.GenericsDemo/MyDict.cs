using System.Collections.Generic;

namespace P00.GenericsDemo
{
    public class MyDict<TK, TV>
        where TK : struct
        where TV : class, new()
    {
        private Dictionary<TK, TV> dict;
    }
}
