using Tasks.Hashmap;

namespace Test.Hashmap.DesignHashSetUtil;
internal class RemoveCommand : ICommand
{
    public bool Execute(DesignHashset hashset, int value)
    {
        hashset.Remove(value);
        return false;
    }
}
