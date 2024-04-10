using Tasks.Hashmap;

namespace Test.Hashmap.DesignHashSetUtil;
internal class AddCommand : ICommand
{
    public bool Execute(DesignHashset hashset, int value)
    {
        hashset.Add(value);
        return false;
    }
}
