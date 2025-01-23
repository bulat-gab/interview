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
}

internal class LruCache<TK, TV>(int capacity) : ILruCache<TK, TV>
{
    private readonly Dictionary<TK, LinkedListNode<TV>> _dict = [];
    private readonly LinkedList<TV> _list = [];

    public TV Get(TK key)
    {
        var exists = _dict.TryGetValue(key, out var node);
        if (!exists)
        {
            return default;
        }


        throw new NotImplementedException();
    }

    public void Put(TK key, TV val)
    {
        var exists = _dict.TryGetValue(key, out LinkedListNode<TV> existingNode);
        if (!exists)
        {
            if (_list.Count < capacity)
            {
                var newNode = new LinkedListNode<TV>(val);
                _dict[key] = newNode;
                _list.AddFirst(newNode);
                return;
            }


            _list.RemoveLast(); // TODO: Delete last from dictionary

             var newNode2 = new LinkedListNode<TV>(val);
            _dict[key] = newNode2;
            _list.AddFirst(newNode2);
            return;
        }


        existingNode.Value = val;
        var previousNode = existingNode.Previous;
        
        if (previousNode != null)
        {
            _list.AddFirst(existingNode); //
            _list.Remove(existingNode);
        }





            throw new NotImplementedException();
    }
}
