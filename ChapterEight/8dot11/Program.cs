using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot11
{
  class Program
  {
    public static int MakeChange(int n)
    {
      int[] denoms = { 25, 10, 5, 1 };
      int[][] map = new int[n + 1][];
      for(int i = 0; i < map.Length; i++)
      {
        map[i] = new int[denoms.Length];

        for (int j = 0; j < map[i].Length; j++)
        {
          map[i][j] = Int32.MinValue;
        }
      }

      return MakeChange(n, denoms, 0, map);
    }

    public static int MakeChange(int amount, int[] denoms, int index, int[][] map)
    {
      if (map[amount][index] > 0)
      {
        return map[amount][index];
      }

      if (index >= denoms.Length - 1) return 1;
      int denomAmount = denoms[index];
      int ways = 0;
      for(int i = 0; i * denomAmount <= amount; i ++)
      {
        int amountRemaining = amount - i * denomAmount;
        ways += MakeChange(amountRemaining, denoms, index + 1, map);
      }

      map[amount][index] = ways;
      return ways;
    }

    static void Main(string[] args)
    {
      int change = 10;
    
      var book = MakeChange(change);
      Console.WriteLine(book);
    }
  }
}
