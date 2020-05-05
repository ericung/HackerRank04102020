using ChapterFour;
using System;
using System.Collections.Generic;

namespace _4dot11
{
  class Program
  {
    public static Node RandomNode(Node head)
    {
      if (head == null)
      {
        return null;
      }

      List<Node> list = new List<Node>();
      Queue<Node> traverse = new Queue<Node>();
      Random random = new Random();
      traverse.Enqueue(head);

      list.Add(head);

      while(traverse.Count > 0)
      {
        Node current = traverse.Dequeue();

        if (current != null)
        {
          list.Add(current);
          traverse.Enqueue(current.Left);
          traverse.Enqueue(current.Right);
        }
      }

      int randomPosition = random.Next(1, list.Count);

      return list[randomPosition];
    }
 
    public static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29 };
      Node head1 = Node.CreateMinimalBST(array1);

      Node.Print(RandomNode(head1));
    }
  }
}
