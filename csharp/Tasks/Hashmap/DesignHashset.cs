using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Hashmap;

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 * 
 * Constraints:
    0 <= key <= 10^6
    At most 10^4 calls will be made to add, remove, and contains.
 */
public class DesignHashset
{
    private bool[] _entries = new bool[1000 * 1000 + 1];

    private const int MinValue = 0;
    private const int MaxValue = 1000 * 1000;

    public DesignHashset()
    {

    }

    public void Add(int key)
    {
        if (!IsValidKey(key))
            return;

        _entries[key] = true;
    }

    public void Remove(int key)
    {
        if (!IsValidKey(key))
            return;

        _entries[key] = false;
    }

    public bool Contains(int key)
    {
        if (!IsValidKey(key))
            return false;

        return _entries[key];
    }

    private bool IsValidKey(int key)
    {
        if (key < MinValue || key > MaxValue)
            return false;

        return true;
    }
}
