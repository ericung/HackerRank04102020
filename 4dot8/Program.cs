using ChapterFour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4dot8
{
  class Result
  {
    public Node Node;
    public Boolean IsAncestor;
    
    public Result(Node n, Boolean isAnc)
    {
      Node = n;
      IsAncestor = isAnc;
    }
  }
  class Program
  {
    // This is my solution.
    // Take the hashmap and 
    public static Node FindCommonAncestorMySolution(Node a, Node b)
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

    public static Node FindCommonAncestor(Node root, Node p, Node q)
    {
      Result r = CommonAncestorHelper(root, p, q);
      Console.WriteLine(r.Node.Value + " : " + r.IsAncestor);
      if (r.IsAncestor)
      {
        return r.Node;
      }

      return null;
    }

    public static Result CommonAncestorHelper(Node root, Node p, Node q)
    {
      if (root == null)
      {
        return new Result(null, false);
      }

      if (root == p && root == q)
      {
        return new Result(root, true);
      }

      Console.WriteLine("root: "+ root.Value + "| a: " + p.Value + " | b: " + q.Value);

      Result rx = CommonAncestorHelper(root.Left, p, q);
      if (rx.IsAncestor)
      {
        return rx;
      }

      Result ry = CommonAncestorHelper(root.Right, p, q);
      if (ry.IsAncestor)
      {
        return ry;
      }

      if (rx.Node != null && ry.Node != null)
      {
        return new Result(root, true); // This is the common ancestor.
      }
      else if (root == p || root == q)
      {
        /* If we're currently at p or q, and we also found one of those nodes in a 
         * subtree, then this is truly an ancestor and the flag should be true.
         */
        Boolean isAncestor = rx.Node != null || ry.Node != null;
        if (rx.Node != null)
        {
          Console.WriteLine("2rx: " + rx.Node.Value + " : " + rx.IsAncestor + " : " + isAncestor);
        }

        if (ry.Node != null)
        {
          Console.WriteLine("2ry: " + ry.Node.Value + " : " + ry.IsAncestor + " : " + isAncestor);
        }
        return new Result(root, isAncestor);
      }
      else
      {
        return new Result(rx.Node != null ? rx.Node : ry.Node, false);
      }
    }

    static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 57, 68, 69 };
      Node head1 = Node.CreateMinimalBST(array1);

      Node.Print(head1);
      Console.WriteLine("My solution: " + FindCommonAncestorMySolution(head1.Left.Left, head1.Left.Right.Right).Value);


      Node a = head1.Left.Right.Left.Left;
      Node b = head1.Left.Right.Right.Right;

      Console.WriteLine("Book solution: " + FindCommonAncestor(head1, a, b).Value);
      Console.WriteLine("========================================");
      Node a2 = head1.Right.Left.Right;
      Node b2 = head1.Right.Left.Left;
      // Node a2 = head1.Left.Left;
      // Node b2 = head1.Left.Left.Right;
      Console.WriteLine("Book solution: " + FindCommonAncestor(head1, a2, b2).Value);

    }
  }
}
