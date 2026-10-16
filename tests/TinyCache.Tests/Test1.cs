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
        private readonly CacheMem _cache = new();
        [Fact]
        public void Test()
        {
            _cache.Set(1,"shyam");
            var data = _cache.TryGet(1, out string value);
            Assert.True(data);
            Assert.Equal("shyam", value);
        }
        [Fact]
        public void TestAgain()
        {
            var found = _cache.TryGet(
            10, out var value);

        Assert.False(found);
        Assert.Null(value);

        }
        
    }
}