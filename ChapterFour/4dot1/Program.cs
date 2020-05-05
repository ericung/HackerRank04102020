using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreesAndGraphs;

// Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
namespace _4dot1
{
  class Program
  {
    // We'll use the depth first search function
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

      foreach(var child in root.Children)
      {
        DepthFirstSearch(child);
      }
    }

    // Mark the nodes visited starting from point a. If it hits b, a path exists
    public static bool PathExists(Node a, Node b)
    {
      bool path = false;

      DepthFirstSearch(a);

      if (b.Data != 0)
      {
        path = true;
      }

      return path;
    }

    static void Main(string[] args)
    {
      Node node1 = new Node();
      Node node2 = new Node();
      Node node3 = new Node();
      Node node4 = new Node();

      node1.Children.Add(node2);
      node2.Children.Add(node3);

      Console.WriteLine(PathExists(node1, node4) ? "It exists" : "It doesn't exist");

      node1.Data = 0;
      node2.Data = 0;
      node3.Data = 0;
      node3.Children.Add(node4);
      
      Console.WriteLine(PathExists(node1, node4) ? "It exists" : "It doesn't exist");
    }
  }
}
