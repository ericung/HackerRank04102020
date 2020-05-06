using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot3
{
  class Program
  {

    public static int? findMagicIndex(int[] array)
    {
      for(int i = 0; i < array.Length; i++)
      {
        if (array[i] == i)
        {
          return i;
        }
      }

      return null;
    }

    public static int magicFast(int[] array)
    {
      return magicFast(array, 0, array.Length - 1);
    }

    public static int magicFast(int[] array, int start, int end)
    {
      if (end < start) return -1;

      int midIndex = (start + end) / 2;
      int midValue = array[midIndex];
      if (midValue == midIndex)
      {
        return midIndex;
      }

      /* Search left */
      int leftIndex = Math.Min(midIndex - 1, midValue);
      int left = magicFast(array, start, leftIndex);
      if (left >= 0)
      {
        return left;
      }

      /* Search right */
      int rightIndex = Math.Max(midIndex + 1, midValue);
      int right = magicFast(array, rightIndex, end);

      return right;
    }

    static void Main(string[] args)
    {
      //  must have negative integers or it is the identity
      int[] array = { -33, 0, 2, 99, 101};

      int? magicIndex = findMagicIndex(array);

      string print = magicIndex != null ? magicIndex.ToString() : "null";

      Console.WriteLine(print);
      Console.WriteLine(magicFast(array));
      Console.WriteLine("o=====================================================");

      // don't need negative integers
      int[] array2 = { 1, 2, 2, 55, 66, 77 };

      int? magicIndex2 = findMagicIndex(array2);

      string print2 = magicIndex2 != null ? magicIndex2.ToString() : "null";

      Console.WriteLine(print2);
      Console.WriteLine(magicFast(array2));
    }
  }
}
