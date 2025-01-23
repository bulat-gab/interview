using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Tasks.Implementation.MyLRUCache;

[TestFixture]
internal class LRUCacheTest
{
    private LruCache<string, int> _integerCache;

    [SetUp]
    public void SetUp()
    {
        _integerCache = new LruCache<string, int>(10);
    }

    [Test]
    public void Get_WhenEmptyCache()
    {
        var result = _integerCache.Get("x");
        result.Should().Be(default);
    }

}
