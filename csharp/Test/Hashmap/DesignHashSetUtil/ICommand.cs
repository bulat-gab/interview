using Tasks.Hashmap;

namespace Test.Hashmap.DesignHashSetUtil;
internal interface ICommand
{
    bool Execute(DesignHashset hashset, int value);
}
