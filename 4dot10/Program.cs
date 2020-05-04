using ChapterFour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4dot10
{
  class Program
  {
    static void Main(string[] args)
    {
      Node head1 = new Node();
      Node left1 = new Node();
      Node right1 = new Node();
      Node leftleft1 = new Node();
      head1.Value = 1;
      left1.Value = 2;
      right1.Value = 3;
      leftleft1.Value = 4;
      head1.Left = left1;
      head1.Right = right1;
      left1.Left = leftleft1;
      Console.WriteLine("head1");
      Node.Print(head1);

      Console.WriteLine("head2");

      Node head2 = new Node();
      Node left2 = new Node();
      head2.Value = 2;
      head2.Left = left2;
      left2.Value = 4;
      Node.Print(head2);

      Boolean containsTree = Node.ContainsTree(head1, head2);
      Console.WriteLine(containsTree);
      Console.WriteLine("======================================================");
    }
  }
}
