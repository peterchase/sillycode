using System;
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

        public bool HaveSameSum(IEnumerable<double> firstValues, IEnumerable<double> secondValues)
        {
            return firstValues.Sum() == secondValues.Sum();
        }

        public IEnumerable<int> CountFrequencies(IEnumerable<int> sourceCollection, IEnumerable<Predicate<int>> predicates)
        {
            return predicates.Select(p => sourceCollection.Count(v => p(v))).ToList();
        }
    }
}
