using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Graph;

namespace Test.Graph;
public class Matrix01Test
{
    [Test]
    public void Test1()
    {
        var input = new int[3][];
        input[0] = [0, 0, 0];
        input[1] = [0, 1, 0];
        input[2] = [0, 0, 0];


        var output = new int[3][];
        output[0] = [0, 0, 0];
        output[1] = [0, 1, 0];
        output[2] = [0, 0, 0];


        var actual = new Matrix01().UpdateMatrix(input);

        AssertMatrixEqual(actual, output);
    }

    [Test]
    public void Test2()
    {
        var input = new int[3][];
        input[0] = [0, 0, 0];
        input[1] = [0, 1, 0];
        input[2] = [1, 1, 1];


        var output = new int[3][];
        output[0] = [0, 0, 0];
        output[1] = [0, 1, 0];
        output[2] = [1, 2, 1];


        var actual = new Matrix01().UpdateMatrix(input);

        AssertMatrixEqual(actual, output);
    }

    [Test]
    public void Test1_Matrix01SolutionTwo()
    {
        var input = new int[3][];
        input[0] = [0, 0, 0];
        input[1] = [0, 1, 0];
        input[2] = [1, 1, 1];
    }

    private void AssertMatrixEqual(int[][] first, int[][] second)
    {
        Assert.That(first.Length, Is.EqualTo(second.Length));

        for (int i = 0; i < first.Length; i++)
        {
            var f1 = first[i];
            var s1 = second[i];

            Assert.That(f1.Length, Is.EqualTo(s1.Length));

            for(int j = 0; j < f1.Length; j++)
            {
                Assert.That(f1[j], Is.EqualTo(s1[j]));
            }

        }
    }
}
