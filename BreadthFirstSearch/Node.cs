using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{

  public class Node
  {
    public static int Identifier = 0;
    public int Id;
    public int Data;
    public Node Left;
    public Node Right;

    public Node()
    {
      Data = 0;

      Id = Identifier;
      Identifier++;
    }

    public Node(int data, Node next, Node previous)
    {
      Data = data;
      Left = next;
      Right = previous;

      Id = Identifier;
      Identifier++;
    }
  }
}
