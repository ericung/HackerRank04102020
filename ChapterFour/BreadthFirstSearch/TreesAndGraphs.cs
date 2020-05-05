using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
  class TreesAndGraphs
  {
    public static void BreadthFirstSearch(Node root)
    {
      Queue<Node> queue = new Queue<Node>();
      root.Data = 1;
      queue.Enqueue(root);

      while(queue.Count() != 0)
      {
        Node r = queue.Dequeue();
        r.Data = 1;

        Console.WriteLine("Id: " + r.Id);

        if(r.Left != null)
        {
          if (r.Left.Data == 0)
          {
            r.Left.Data = 1;
            queue.Enqueue(r.Left);
          }
        }

        if (r.Right != null)
        {
          if (r.Right.Data == 0)
          {
            r.Right.Data = 1;
            queue.Enqueue(r.Right);
          }
        }
      }
    }

    public static void DepthFirstSearch(Node root)
    {
      if (root == null)
      {
        return;
      }

      if (root.Data == 0)
      {
        root.Data = 1;
        Console.WriteLine("Id: " + root.Id);
      }

      DepthFirstSearch(root.Left);
      DepthFirstSearch(root.Right);
    }

    static void Main(string[] args)
    {
      Console.WriteLine("First Test Case");
      Node node1 = new Node();
      Node node2 = new Node();
      Node node3 = new Node();
      Node node4 = new Node();
      Node node5 = new Node();
      Node node6 = new Node();
      Node node7 = new Node();

      node1.Left = node2;
      node1.Right = node3;
      node2.Left = node4;
      node2.Right = node5;
      node3.Left = node6;
      node3.Right = node7;

      // BreadthFirstSearch(node1);
      DepthFirstSearch(node1);

      Console.WriteLine("Second Test Case");
      Node node8 = new Node();
      Node node9 = new Node();
      Node node10 = new Node();
      Node node11 = new Node();
      Node node12 = new Node();
      Node node13 = new Node();
      Node node14 = new Node();

      node8.Left = node9;
      node8.Right = node12;
      node9.Left = node10;
      node9.Right = node13;
      node10.Left = node11;
      node12.Right = node14;

      // BreadthFirstSearch(node8);
      DepthFirstSearch(node8);
    }
  }
}
