using ChapterFour;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _4dot12
{
  class Program
  {
    public static int CountPathsWithSum(Node root, int targetSum)
    {
      return CountPathsWithSum(root, targetSum, 0, new Dictionary<int, int>());
    }

    public static int CountPathsWithSum(Node node, int targetSum, int runningSum, Dictionary<int, int> pathCount)
    {
      if(node == null)
      {
        return 0;
      }

      /* Count paths with sum ending at the current node. */
      runningSum += node.Value;
      int sum = runningSum - targetSum;
      int totalPaths = pathCount.ContainsKey(sum) ? pathCount[sum] : 0;

      /* If runningSum equals targetSum, then one additional path starts at root.
       * Add in this path. */
      if (runningSum == targetSum)
      {
        totalPaths++;
      }

      /* Increment pathCount, recurse, then decrement pathCount. */
      incrementHashTable(pathCount, runningSum, 1); // Increment pathCount.
      totalPaths += CountPathsWithSum(node.Left, targetSum, runningSum, pathCount);
      totalPaths += CountPathsWithSum(node.Right, targetSum, runningSum, pathCount);
      incrementHashTable(pathCount, runningSum, -1);

      return totalPaths;
    }

    public static void incrementHashTable(Dictionary<int, int> hashTable, int key, int delta)
    {
      int newCount = hashTable.ContainsKey(key) ? hashTable[key] : 0 + delta;
      if (newCount == 0)
      {
        hashTable.Remove(key);
      } else
      {
        hashTable[key] = newCount;
      }
    }

    static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29 };
      Node head1 = Node.CreateMinimalBST(array1);

      int paths = CountPathsWithSum(head1, 10);
      Console.WriteLine(paths);

      /* This problem is similar to Depth First Search. */
    }
  }
}
