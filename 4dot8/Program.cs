using ChapterFour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4dot8
{
  class Program
  {
    public static Node FindCommonAncestor(Node a, Node b)
    {
      if ((a == null)||(b == null))
      {
        return null;
      }

      // Cover a side
      Dictionary<int, int> visited = new Dictionary<int, int>();
      Node iterative = a;

      while(iterative != null)
      {
        visited[iterative.Value] = 1;
        iterative = iterative.Parent;
      }

      Node commonAncestor = b;
      while(commonAncestor != null)
      {
        if (visited.ContainsKey(commonAncestor.Value))
        {
          break;
        }
        else
        {
          commonAncestor = commonAncestor.Parent;
        }
      }

      return commonAncestor;
    }

    static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41 };
      Node head1 = Node.CreateMinimalBST(array1);

      Node.Print(head1);
      Console.WriteLine(FindCommonAncestor(head1.Left.Left, head1.Left.Right.Right).Value);
    }
  }
}
