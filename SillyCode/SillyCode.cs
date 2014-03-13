﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SillyCode
{
    public static class SillyCode
    {
        public static string GetOrCreateValue(IDictionary<string, string> map, string key, Func<string> createValue)
        {
            return map.ContainsKey(key) ? map[key] : map[key] = createValue();
        }

        public static bool IsEmpty<T>(IEnumerable<T> collection)
        {
            return collection.Count() == 0;
        }

        public static bool HaveSameSum(IEnumerable<double> firstValues, IEnumerable<double> secondValues)
        {
            return firstValues.Sum() == secondValues.Sum();
        }

        public static IEnumerable<int> CountFrequencies<T>(IEnumerable<T> sourceCollection, IEnumerable<Predicate<T>> predicates)
        {
            return predicates.Select(p => sourceCollection.Count(v => p(v))).ToList();
        }

        public static int GetHashCode(ushort value)
        {
            return (value >> 16) + 12;
        }

        public static bool ReferenceSameObjects<TKey, TValue>(IEnumerable<TKey> keys1, IEnumerable<TKey> keys2, IDataSource<TKey, TValue> remoteDataSource)
            where TValue : class
        {
            var valuePairs = keys1.SelectMany(key1 
                => keys2.Select(key2 => new { Value1 = remoteDataSource.FetchValue(key1), Value2 = remoteDataSource.FetchValue(key2) }));

            return valuePairs.All(values => values.Value1 == values.Value2);
        }
    }
}
