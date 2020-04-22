using System;
using System.Collections;
using System.Collections.Generic;

namespace _4dot3
{
  class Program
  {
    static LinkedList<Node>[] Organize(Node head)
    {
      LinkedList<Node>[] nodeList = new LinkedList<Node>[head.Height];
      for(int i = 0; i < head.Height; i++)
      {
        nodeList[i] = new LinkedList<Node>();
      }

      Queue queue = new Queue();
      queue.Enqueue(head);

      while (queue.Count > 0)
      {
        Node iterative = (Node)queue.Dequeue();

        // Use the level property instead of calling parent and refinding the level of the node
        nodeList[iterative.Level].AddLast(iterative);

        if (iterative.Left != null)
        {
          queue.Enqueue(iterative.Left);
        }
        if (iterative.Right != null)
        {
          queue.Enqueue(iterative.Right);
        }
      }

      return nodeList;
    }
    

    static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41 };
      Node head1 = Helper.CreateMinimalBST(array1);

      LinkedList<Node>[] linkedList = Organize(head1);
      for(int i = 0; i < linkedList.Length; i++)
      {
        foreach(var node in linkedList[i])
        {
          Console.WriteLine("Level " + i + ": " + node.Value);
        }
      }
    }
  }
}
