using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot7
{
  class Program
  {
    public static List<String> getPerms(String remainder)
    {
      int len = remainder.Length;
      List<String> result = new List<String>();

      if (len == 0)
      {
        result.Add("");
        return result;
      }

      for (int i = 0; i < len; i++)
      {
        /* Remove char i and find  permutations of remaining chars. */
        String before = remainder.Substring(0, i);
        int endLength = len - i - 1;
        String after;
        if (endLength > 0)
        {
          after = remainder.Substring(i + 1, endLength);
        }
        else
        {
          after = String.Empty;
        }
        List<String> partials = getPerms(before + after);

        /* Prepend char i to each permutation. */
        foreach (String s in partials)
        {
          result.Add(remainder[i] + s);
        }
      }

      return result;
    }

    static void Main(string[] args)
    {
      var result = getPerms("hayw");

      foreach(var item in result)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine(result.Count);
    }
  }
}
