using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot9
{
  class Program
  {
    public static void addParen(List<String> list, int leftRem, int rightRem, char[] str, int index)
    {
      if (leftRem < 0 || rightRem < leftRem) return;

      if (leftRem == 0 && rightRem == 0)
      {
        list.Add(new string(str));
      } else
      {
        str[index] = '(';
        addParen(list, leftRem - 1, rightRem, str, index + 1);

        str[index] = ')';
        addParen(list, leftRem, rightRem - 1, str, index + 1);
      }
    }

    public static List<String> generateParens(int count)
    {
      char[] str = new char[count * 2];
      List<String> list = new List<String>();
      addParen(list, count, count, str, 0);
      return list;
    }

    static void Main(string[] args)
    {
      List<String> result = generateParens(3);

      foreach(String str in result)
      {
        Console.WriteLine(str);
      }
    }
  }
}
