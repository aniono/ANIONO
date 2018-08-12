using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeProblems.Tests
{
    public class TestsVerifier
    {
        public void Verify<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> items, Func<TKey, TValue> func)
        {
            foreach (var kvp in items)
            {
                var input = kvp.Key;
                var actual = func(kvp.Key);
                var expected = kvp.Value;

                Assert.Equal(expected, actual);
            }
        }
    }
}
