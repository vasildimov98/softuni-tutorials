namespace _01.Microsystem
{
    using System.Linq;
    using System.Collections.Generic;

    public static class DictionaryExtension
    {
        public static void AppendValueToKey<TKey, ICollection, TValue>(this IDictionary<TKey, ICollection> dict,
            TKey key,
            TValue value)
            where ICollection : ICollection<TValue>, new()
        {
            if (!dict.ContainsKey(key))
                dict[key] = new ICollection();

            dict[key].Add(value);
        }

        public static IEnumerable<TValue> GetValuesToKey<TKey, TValue>(this IDictionary<TKey, SortedSet<TValue>> dict, TKey key)
        {
            SortedSet<TValue> collection;
            if (dict.TryGetValue(key, out collection))
                return collection;
            return Enumerable.Empty<TValue>();
        }
    }
}
