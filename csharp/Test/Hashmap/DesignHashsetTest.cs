using NUnit.Framework;
using Test.Hashmap.DesignHashSetUtil;

namespace Tasks.Hashmap;

[TestFixture]
public class DesignHashsetTest
{
    [Test]
    public void Test1()
    {
        var hashset = new DesignHashset();
        hashset.Add(1);
        hashset.Add(2);

        Assert.That(hashset.Contains(1), Is.True);
        Assert.That(hashset.Contains(3), Is.False);
        hashset.Add(2);

        Assert.That(hashset.Contains(2), Is.True);
        hashset.Remove(2);

        Assert.That(hashset.Contains(2), Is.False);
    }

    [Test]
    public void Test2()
    {
        string[] input1 = ["MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains"];
        int[][] input2 = [[], [1], [2], [1], [3], [2], [2], [2], [2]];
        bool?[] output = [null, null, null, true, false, null, true, null, false];

        int length = input1.Length;
        DesignHashset hashset = null;


        for (int i = 0; i < length; i++)
        {
            if (input1[i] == "MyHashSet")
            {
                hashset = new DesignHashset();
                continue;
            }

            var cmd = CommandFactory.CreateCommand(input1[i]);
            var result = cmd.Execute(hashset, input2[i][0]);

            if (cmd is ContainsCommand)
            {
                Assert.That(result, Is.EqualTo(output[i]));
            }
        }
    }

    [Test]
    public void Test3()
    {
        string[] input1 = ["MyHashSet", "contains", "remove", "add", "add", "contains", "remove", "contains", "contains", "add", "add", "add", "add", "remove", "add", "add", "add", "add", "add", "add", "add", "add", "add", "add", "contains", "add", "contains", "add", "add", "contains", "add", "add", "remove", "add", "add", "add", "add", "add", "contains", "add", "add", "add", "remove", "contains", "add", "contains", "add", "add", "add", "add", "add", "contains", "remove", "remove", "add", "remove", "contains", "add", "remove", "add", "add", "add", "add", "contains", "contains", "add", "remove", "remove", "remove", "remove", "add", "add", "contains", "add", "add", "remove", "add", "add", "add", "add", "add", "add", "add", "add", "remove", "add", "remove", "remove", "add", "remove", "add", "remove", "add", "add", "add", "remove", "remove", "remove", "add", "contains", "add"];

        int[][] input2 = [[], [72], [91], [48], [41], [96], [87], [48], [49], [84], [82], [24], [7], [56], [87], [81], [55], [19], [40], [68], [23], [80], [53], [76], [93], [95], [95], [67], [31], [80], [62], [73], [97], [33], [28], [62], [81], [57], [40], [11], [89], [28], [97], [86], [20], [5], [77], [52], [57], [88], [20], [48], [42], [86], [49], [62], [53], [43], [98], [32], [15], [42], [50], [19], [32], [67], [84], [60], [8], [85], [43], [59], [65], [40], [81], [55], [56], [54], [59], [78], [53], [0], [24], [7], [53], [33], [69], [86], [7], [1], [16], [58], [61], [34], [53], [84], [21], [58], [25], [45], [3]];

        bool?[] output = [null, false, null, null, null, false, null, true, false, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null, true, null, null, true, null, null, null, null, null, null, null, null, true, null, null, null, null, false, null, false, null, null, null, null, null, true, null, null, null, null, true, null, null, null, null, null, null, true, true, null, null, null, null, null, null, null, false, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, false, null];

        int length = input1.Length;
        DesignHashset hashset = null;


        for (int i = 0; i < length; i++)
        {
            if (input1[i] == "MyHashSet")
            {
                hashset = new DesignHashset();
                continue;
            }

            var cmd = CommandFactory.CreateCommand(input1[i]);
            var result = cmd.Execute(hashset, input2[i][0]);

            if (cmd is ContainsCommand)
            {
                Assert.That(result, Is.EqualTo(output[i]));
            }
        }
    }
}
