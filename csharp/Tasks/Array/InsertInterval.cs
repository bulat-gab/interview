using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Tasks.Array;

public class InsertInterval
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var output = new List<int[]>();
        var intervalsCount = intervals.Length;

        int i = 0;
        // newInterval is on the left side on intervals, skip until we find overlap
        while (i < intervalsCount && newInterval[0] > intervals[i][1])
            output.Add(intervals[i++]);

        while (i < intervalsCount && newInterval[0] <= intervals[i][1] && newInterval[1] >= intervals[i][0])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }
        output.Add(newInterval);
        
        // keep adding the rest of intervals
        while (i < intervalsCount && newInterval[1] < intervals[i][0])
            output.Add(intervals[i++]);

        return output.ToArray();
    }
}

[TestFixture]
public class InsertIntervalTests
{
    [Test]
    public void Test1()
    {
        int[][] intervals = [[1, 3], [6, 9]];
        int[] newInterval = [2, 5];
        int[][] expected = [[1, 5], [6, 9]];
        
        var actual = new InsertInterval().Insert(intervals, newInterval);
        
        JaggedArraysAreEqual(expected, actual);
    }
    
    [Test]
    public void Test2()
    {
        int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];
        int[] newInterval = [4, 8];
        int[][] expected = [[1, 2], [3, 10], [12, 16]];
        
        var actual = new InsertInterval().Insert(intervals, newInterval);
        JaggedArraysAreEqual(expected, actual);
    }
    
    private static bool JaggedArraysAreEqual(int[][] array1, int[][] array2)
    {
        if (array1 == null || array2 == null)
            Assert.Fail("Arrays are null");
        if (array1.Length != array2.Length)
            Assert.Fail("Array lengths are not equal");

        for (int i = 0; i < array1.Length; i++)
        {
            var innerArray1 = array1[i];
            var innerArray2 = array2[i];
            innerArray1.Length.Should().Be(innerArray2.Length);

            for (int j = 0; j < innerArray1.Length; j++)
            {
                innerArray1[j].Should().Be(innerArray2[j]);
            }
        }
        
        return true;
    }

    private static void PrintArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write($"{array[i][j]} ");
            }
            Console.WriteLine();
        }
    }
}