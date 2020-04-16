using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{

  public class Node
  {
    public static int Identifier = 1;
    public int Id;
    public int Data;
    public List<Node> Children;

    public Node()
    {
      Data = 0;

      Children = new List<Node>();

      Id = Identifier;
      Identifier++;
    }

    public Node(int data, List<Node> Children)
    {
      Data = data;

      Children = new List<Node>();

      foreach (var child in Children)
      {
        this.Children.Add(child);
      }

      Id = Identifier;
      Identifier++;
    }
  }
}
