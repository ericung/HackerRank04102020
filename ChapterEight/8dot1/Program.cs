using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot1
{
  class Program
  {
    static int CountSteps(int steps)
    {
      if (steps < 0)
      {
        return 0;
      }
      else if (steps == 0)
      {
        return 1;
      } else 
      {
        return CountSteps(steps - 1) + CountSteps(steps - 2) + CountSteps(steps - 3);
      }
    }

    static int CountStepsMemo(int steps, Dictionary<int,int> memo)
    {
      if (steps < 0)
      {
        return 0;
      }
      else if (steps == 0)
      {
        return 1;
      }
      else if (memo.ContainsKey(steps))
      {
        return memo[steps];
      }
      else
      {
        memo[steps] = CountStepsMemo(steps - 1, memo) + CountStepsMemo(steps - 2, memo) + CountStepsMemo(steps - 3, memo);
        return memo[steps];
      }
    }

    static void Main(string[] args)
    {
      Console.WriteLine(CountSteps(10));
      Console.WriteLine(CountStepsMemo(36, new Dictionary<int, int>()));
    }
  }
}
