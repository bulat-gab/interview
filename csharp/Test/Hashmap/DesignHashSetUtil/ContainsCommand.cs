using Tasks.Hashmap;

namespace Test.Hashmap.DesignHashSetUtil;
internal class ContainsCommand : ICommand
{
    public bool Execute(DesignHashset hashset, int value)
    {
        return hashset.Contains(value);
    }
}
