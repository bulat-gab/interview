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
    
    private LruCache<string, string> _stringCache;

    [SetUp]
    public void SetUp()
    {
        _integerCache = new LruCache<string, int>(4);
        _stringCache = new LruCache<string, string>(4); 
    }

    [Test]
    public void Contains_ShouldReturnTrue_WhenExists()
    {
        var cache = new LruCache<int, string>(2);
        cache.Put(1, "X");

        cache.Contains(1).Should().BeTrue();
    }
    
    [Test]
    public void Contains_ShouldReturnFalse_WhenNotExist()
    {
        var cache = new LruCache<int, string>(2);
        cache.Contains(2).Should().BeFalse();
    }
    
    [Test]
    public void Get_WhenEmptyCache()
    {
        var cache = new LruCache<int, string>(2);
        cache.Get(1).Should().Be(null);
    }
    
    [Test]
    public void Get_ShouldUpdateUsageOrder()
    {
        var cache = new LruCache<int, string>(2);

        cache.Put(1, "A"); // Add first item
        cache.Put(2, "B"); // Add second item

        cache.Get(1); // Update first item usage
        
        cache.Put(3, "C"); // Add third item, causing eviction of the least recently used (2, "B")
        
        cache.Contains(2).Should().BeFalse();

        cache.Contains(1).Should().BeTrue();
        cache.Contains(3).Should().BeTrue();
    }

    [Test]
    public void Put_ShouldEvictLeastRecentlyUsed_WhenCapacityExceeded()
    {
        var cache = new LruCache<int, string>(2);

        cache.Put(1, "A"); // Add first item
        cache.Put(2, "B"); // Add second item
        cache.Put(3, "C"); // Add third item, causing eviction of the least recently used (1, "A")
        
        cache.Contains(1).Should().BeFalse();
        cache.Contains(2).Should().BeTrue();
        cache.Contains(3).Should().BeTrue();
    }

    [Test]
    public void Put_ShouldUpdateValue_WhenKeyExists()
    {
        var cache = new LruCache<int, string>(2);

        cache.Put(1, "A"); 
        cache.Put(1, "X");
        
        cache.Get(1).Should().Be("X");
    }
    
    [Test]
    public void Put_ShouldUpdateUsageOrder()
    {
        var cache = new LruCache<int, string>(2);

        cache.Put(1, "A"); // Add first item
        cache.Put(2, "B"); // Add second item
        cache.Put(1, "X"); // Update first item
        cache.Put(3, "C"); // Add third item, causing eviction of the least recently used (2, "B")
        
        cache.Contains(2).Should().BeFalse();

        cache.Contains(1).Should().BeTrue();
        cache.Get(1).Should().Be("X");
        cache.Contains(3).Should().BeTrue();
    }
    
    [Test]
    public void Put_RemovesLastItem_WhenCacheFull()
    {
        _stringCache = new LruCache<string, string>(4);
        
        _stringCache.Put("a", "1");
        _stringCache.Put("b", "2");
        _stringCache.Put("c", "3");
        _stringCache.Put("d", "4");
        _stringCache.Put("e", "5");
        
        var result = _stringCache.Get("a");
        result.Should().BeNull();
    }

    [Test]
    public void GetPut_ManyTimes()
    {
        var cache = new LruCache<int, string>(4);

        for (var i = 0; i < 1000; i++)
        {
            var val = i.ToString();
            cache.Put(i, val);
            var result = cache.Get(i);
            result.Should().Be(val);
        }

        cache.Get(999).Should().Be("999");
    }

}
