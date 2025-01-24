using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Implementation.MyLRUCache;

public interface ILruCache<in TK, TV> // TODO: check if I need 'in'
{
    TV Get(TK key);
    void Put(TK key, TV val);
    bool Contains(TK key);
}

internal class LruNode<TK, TV>(TK key, TV val)
{
    public TK Key { get; set; } = key;
    public TV Val { get; set; } = val;

    public LruNode<TK, TV> Previous { get; set; }
    public LruNode<TK, TV> Next { get; set; }

    public static LruNode<TK, TV> CreateDummy() => new LruNode<TK, TV>(default, default);

    public void Invalidate()
    {
        Key = default;
        Val = default;
        Previous = null;
        Next = null;
    }
}
public class LruCache<TK, TV> : ILruCache<TK, TV>
{
    private readonly Dictionary<TK, LruNode<TK, TV>> _dict = [];
    
    private LruNode<TK,TV> _head;
    private LruNode<TK,TV> _tail;
    
    private readonly int _capacity;
    
    public int Count => _dict.Count;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="capacity"></param>
    /// <exception cref="ArgumentException"></exception>
    public LruCache(int capacity)
    {
        if (capacity < 2)
        {
            throw new ArgumentException($"Capacity must be at least 2 but was {capacity}");
        }

        _head = LruNode<TK, TV>.CreateDummy();
        _tail = LruNode<TK,TV>.CreateDummy();
        _head.Next = _tail;
        _tail.Previous = _head;
        
        _capacity = capacity;
    }

    public TV Get(TK key)
    {
        var exists = _dict.TryGetValue(key, out LruNode<TK, TV> existingNode);
        if (!exists)
        {
            return default;
        }

        AddFirst(existingNode);
        return existingNode.Val;
    }

    public void Put(TK key, TV val)
    {
        var exists = _dict.TryGetValue(key, out var existingNode);
        if (exists)
        {
            existingNode.Val = val;
            AddFirst(existingNode);
            return;
        }

        var newNode = new LruNode<TK, TV>(key, val);
        _dict[key] = newNode;
        AddFirst(newNode);

        if (Count <= _capacity)
            return;
        
        var keyToDelete = _tail.Previous.Key;
        if (!_dict.Remove(keyToDelete, out var nodeToDelete))
        {
            // Should not happen.
            throw new Exception($"Fatal error. Dictionary and Linked list are not synchronized.");
        }

        _tail.Previous = nodeToDelete.Previous;
        nodeToDelete.Previous.Next = _tail;
        nodeToDelete.Invalidate();
    }
    
    public bool Contains(TK key) => _dict.ContainsKey(key);

    private void AddFirst(LruNode<TK, TV> node)
    {
        // Removes node from current position in Linked List
        var prev = node.Previous;
        var next = node.Next;
        
        if (prev != null)
            prev.Next = next;
        if (next != null)    
            next.Previous = prev;
            
        // move to beginning of Linked List 
        var firstNode = _head.Next;
        node.Next = firstNode;
        firstNode.Previous = node;
        node.Previous = _head;
        _head.Next = node;
    }
}
