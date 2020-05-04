using ChapterFour;
using System;

namespace _4dot6
{
  class Program
  {
    public static Node Successor(Node node)
    {
      Node successor = node;

      if (node.Right != null)
      {
        successor = node.Right;

        while(successor.Left != null)
        {
          successor = successor.Left;
        }

        return successor;
      }
      else if (node.Parent != null)
      {
        successor = node.Parent;
        
        while(successor.Parent != null)
        {
          successor = successor.Parent;
        }

        return successor;
      }

      return node;
    }

    static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41 };
      Node head1 = Node.CreateMinimalBST(array1);

      Node.Print(head1);
      Console.WriteLine(Successor(head1.Left).Value);
    }
  }
}
