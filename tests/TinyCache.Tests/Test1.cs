using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace TinyCache.Tests
{

    public class Test1
    {
        private readonly CacheMem cache = new();






        [Fact]
        public void Set_AddsValue()
        {


            cache.Set(1, "Apple");

            Assert.Equal("Apple", cache.GetOrDefault(1));
        }

        [Fact]
        public void Set_UpdatesExistingValue()
        {


            cache.Set(1, "Apple");
            cache.Set(1, "Orange");

            Assert.Equal("Orange", cache.GetOrDefault(1));
        }

        [Fact]
        public void ContainsKey_ReturnsTrue_WhenKeyExists()
        {

            cache.Set(1, "Apple");

            Assert.True(cache.ContainsKey(1));
        }

        [Fact]
        public void ContainsKey_ReturnsFalse_WhenKeyDoesNotExist()
        {


            Assert.False(cache.ContainsKey(99));
        }

        [Fact]
        public void GetAll_ReturnsAllEntries()
        {

            cache.Set(1, "Apple");
            cache.Set(2, "Orange");

            var entries = cache.GetAll();

            Assert.Equal(2, entries.Length);
            Assert.Contains(entries, x => x.Key == 1 && x.Value == "Apple");
            Assert.Contains(entries, x => x.Key == 2 && x.Value == "Orange");
        }

        [Fact]
        public void GetOrAdd_AddsValue_WhenKeyDoesNotExist()
        {


            var result = cache.GetOrAdd(1, "Apple");

            Assert.Equal("Apple", result);
            Assert.Equal("Apple", cache.GetOrDefault(1));
        }

        [Fact]
        public void GetOrAdd_ReturnsExistingValue_WhenKeyExists()
        {

            cache.Set(1, "Apple");

            var result = cache.GetOrAdd(1, "Orange");

            Assert.Equal("Apple", result);
            Assert.Equal("Apple", cache.GetOrDefault(1));
        }

        [Fact]
        public void GetOrDefault_ReturnsValue_WhenKeyExists()
        {

            cache.Set(1, "Apple");

            Assert.Equal("Apple", cache.GetOrDefault(1));
        }

        [Fact]
        public void GetOrDefault_ReturnsNull_WhenKeyDoesNotExist()
        {


            Assert.Null(cache.GetOrDefault(99));
        }

        [Fact]
        public void Remove_RemovesExistingKey()
        {

            cache.Set(1, "Apple");

            var result = cache.Remove(1);

            Assert.True(result);
            Assert.False(cache.ContainsKey(1));
        }

        [Fact]
        public void Remove_ReturnsFalse_WhenKeyDoesNotExist()
        {


            Assert.False(cache.Remove(99));
        }

        [Fact]
        public void TryAdd_AddsNewKey()
        {


            var result = cache.TryAdd(1, "Apple");

            Assert.True(result);
            Assert.Equal("Apple", cache.GetOrDefault(1));
        }

        [Fact]
        public void TryAdd_ReturnsFalse_WhenKeyAlreadyExists()
        {

            cache.Set(1, "Apple");

            var result = cache.TryAdd(1, "Orange");

            Assert.False(result);
            Assert.Equal("Apple", cache.GetOrDefault(1));
        }

        [Fact]
        public void TryGet_ReturnsTrueAndValue_WhenKeyExists()
        {

            cache.Set(1, "Apple");

            var found = cache.TryGet(1, out var value);

            Assert.True(found);
            Assert.Equal("Apple", value);
        }

        [Fact]
        public void TryGet_ReturnsFalse_WhenKeyDoesNotExist()
        {


            var found = cache.TryGet(99, out _);

            Assert.False(found);
        }

        [Fact]
        public void TryUpdate_UpdatesValue_WhenOldValueMatches()
        {

            cache.Set(1, "Apple");

            var result = cache.TryUpdate(1, "Orange", "Apple");

            Assert.True(result);
            Assert.Equal("Orange", cache.GetOrDefault(1));
        }

        [Fact]
        public void TryUpdate_ReturnsFalse_WhenOldValueDoesNotMatch()
        {

            cache.Set(1, "Apple");

            var result = cache.TryUpdate(1, "Orange", "Banana");

            Assert.False(result);
            Assert.Equal("Apple", cache.GetOrDefault(1));
        }

        [Fact]
        public void TryUpdate_ReturnsFalse_WhenKeyDoesNotExist()
        {


            Assert.False(cache.TryUpdate(99, "Orange", "Apple"));
        }

        [Fact]
        public void Clear_RemovesAllEntries()
        {

            cache.Set(1, "Apple");
            cache.Set(2, "Orange");

            cache.Clear();

            Assert.Empty(cache.GetAll());
            Assert.False(cache.ContainsKey(1));
            Assert.False(cache.ContainsKey(2));
        }
    }

}
