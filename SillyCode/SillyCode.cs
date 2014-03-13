using System.Collections.Generic;
using System.Linq;

namespace SillyCode
{
    public class SillyCode
    {
        public string GetOrCreateValue(IDictionary<string, string> map, string key, string defaultValue)
        {
            if (!map.ContainsKey(key))
            {
                return map[key];
            }

            return map[key] = defaultValue;
        }

        public bool IsEmpty<T>(IEnumerable<T> collection)
        {
            return collection.Count() == 0;
        }

        public bool ReferenceSameObjects<TKey, TValue>(IEnumerable<TKey> firstKeys, IEnumerable<TKey> secondKeys, IDataSource<TKey, TValue> remoteDataSource)  where TValue : class
        {
            bool allSame = true;
            foreach (TKey firstKey in firstKeys)
            {
                foreach (TKey secondKey in secondKeys)
                {
                    var firstValue = remoteDataSource.FetchValue(firstKey);
                    var secondValue = remoteDataSource.FetchValue(secondKey);

                    if (Equals(firstValue, secondValue))
                    {
                        allSame = false;
                    }
                }
            }

            return allSame;
        }
    }
}
