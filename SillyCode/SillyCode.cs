using System;
using System.Collections.Generic;
using System.Linq;

namespace SillyCode
{
    public class SillyCode
    {
        public string GetOrCreateValue(IDictionary<string, string> map, string key, Func<string> createValue)
        {
            if (!map.ContainsKey(key))
            {
                return map[key];
            }

            return map[key] = createValue();
        }

        public bool IsEmpty<T>(IEnumerable<T> collection)
        {
            return collection.Count() == 0;
        }

        public bool HaveSameSum(IEnumerable<double> firstValues, IEnumerable<double> secondValues)
        {
            return firstValues.Sum() == secondValues.Sum();
        }

        public IEnumerable<int> CountFrequencies<T>(IEnumerable<T> sourceCollection, IEnumerable<Predicate<T>> predicates)
        {
            return predicates.Select(p => sourceCollection.Count(v => p(v))).ToList();
        }

        public bool ReferenceSameObjects<TKey, TValue>(IEnumerable<TKey> firstKeys, IEnumerable<TKey> secondKeys, IDataSource<TKey, TValue> remoteDataSource)  where TValue : class
        {
            return
                firstKeys.SelectMany(firstKey => secondKeys.Select(secondKey => new { FirstValue = remoteDataSource.FetchValue(firstKey), SecondValue = remoteDataSource.FetchValue(secondKey) }))
                    .All(values => values.FirstValue == values.SecondValue);
        }
    }
}
