using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
  class BreadthFirstSearch
  {
    public static void Search(Node root)
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

    static void Main(string[] args)
    {
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

      Search(node1);
    }
  }
}
