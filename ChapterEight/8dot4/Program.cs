using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot4
{
  class Program
  {
    public static List<List<int>> getSubsets(List<int> set, int index)
    {
      List<List<int>> allsubsets;
      if (set.Count == index)
      {
        allsubsets = new List<List<int>>();
        allsubsets.Add(new List<int>());
      }
      else
      {
        allsubsets = getSubsets(set, index + 1);
        int item = set[index];
        List<List<int>> moresubsets = new List<List<int>>();
        foreach(List<int> subset in allsubsets)
        {
          List<int> newsubset = new List<int>();
          newsubset.AddRange(subset);
          newsubset.Add(item);
          moresubsets.Add(newsubset);
        }

        allsubsets.AddRange(moresubsets);
      }

      return allsubsets;
    }

    static void Main(string[] args)
    {
      List<int> set = new List<int>();
      set.Add(1);
      set.Add(2);
      set.Add(3);
      set.Add(4);
      set.Add(5);
      set.Add(6);
      List<List<int>> product = getSubsets(set, 0);

      foreach(var subset in product)
      {
        if (subset.Count == 0)
        {
          Console.Write("empty");
        }
        foreach(var element in subset)
        {
          Console.Write(element + " ");
        }

        Console.WriteLine("");
      }
    }
  }
}
