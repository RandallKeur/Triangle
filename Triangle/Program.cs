// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Collections.Immutable;

public class Program{
    public static void Main(string[] args)
    {
    
    IList<IList<int>> triangle = new List<IList<int>>();
    triangle.Add(new List<int>(){-1});
    triangle.Add(new List<int>(){2,3});
    triangle.Add(new List<int>(){1,-1,-3});
    //triangle.Add(new List<int>(){4,1,8,3});

    var listMath = new ListMath();
    var sum = listMath.MinimumTotal(triangle.Reverse());

    //listMath.MinTotal(triangle);
    Console.WriteLine($"Total sum is {sum}");
    
    }
}

public class ListMath
{
    public void MinTotal(IList<IList<int>> triangle)
    {
        var reversedList = triangle.Reverse();
        var index = 0;
        var tempSum = GetMinimumTotalOfPath(triangle, index);
    }

    private int GetMinimumTotalOfPath(IList<IList<int>> triangle, int index)
    {
        var firstList = triangle.FirstOrDefault();
        triangle.FirstOrDefault().Remove(0);
        foreach (var value in firstList)
        {
            
        }
    }

    private IList<int> GenerateNewListRev(IList<int> inputList, int index)
    {
        var tempList = new List<int>();
        if (index > 0)
            tempList.Add(inputList[index-1]);
        tempList.Add(inputList[index]);
        return tempList;
    }
    public int MinimumTotal(IEnumerable<IList<int>> triangle)
    {
        var sum = 0;
        var minIndexTracker = 0;
        foreach (var list in triangle)
        {
            var tempList = GenerateNewList(list, minIndexTracker);
            var minIndex = FindIndexOfMinValueInList(tempList);
            minIndexTracker += minIndex;
            sum += tempList[minIndex];
        }

        return sum;
    }

    private IList<int> GenerateNewList(IList<int> inputList, int indexOfLastMin)
    {
        IList<int> tempList = new List<int>();
        tempList.Add(inputList[indexOfLastMin]);
        if (inputList.Count > 1)
            tempList.Add(inputList[++indexOfLastMin]);
            
        return tempList;
    }

    private int FindIndexOfMinValueInList(IList<int> inputList)
    {
        return inputList.IndexOf(inputList.Min());
    }
}
