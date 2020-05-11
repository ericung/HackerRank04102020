using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _8dot5
{
  class Program
  {
    public static int MultiplyWithoutOperator(int x, int y)
    {
      if (y == 0)
      {
        return 0;
      }

      int sum = 0;

      for(int i = 0; i < y; i++)
      {
        sum += x;
      }

      return sum;
    }

    public static int minProduct(int a, int b)
    {
      int bigger = a < b ? b : a;
      int smaller = a < b ? a : b;

      int[] memo = new int[smaller + 1];
      return minProductHelper(smaller, bigger, memo);
    }

    public static int minProductHelper(int smaller, int bigger, int[] memo)
    {
      if (smaller == 0)
      {
        return 0;
      }
      else if (smaller == 1)
      {
        return bigger;
      }
      else if (memo[smaller] > 0)
      {
        return memo[smaller];
      }

      /* Compter half, If uneven, compute other half,. If even, double it. */
      int s = smaller >> 1;
      int side1 = minProductHelper(s, bigger, memo);
      int side2 = side1;
      if (smaller % 2 == 1)
      {
        side2 = minProductHelper(smaller - s, bigger, memo);
      }

      memo[smaller] = side1 + side2;
      return side1 + side2;
    }
    

    static void Main(string[] args)
    {
      Console.WriteLine(MultiplyWithoutOperator(5, 6));

      Console.WriteLine(minProduct(5, 6));
    }
  }
}
