using System;

namespace _4dot4
{
  class Program
  {
    public static Node CreateUnevenNode()
    {
      Node head = new Node();
      Node left1 = new Node();
      Node right1 = new Node();
      Node left12 = new Node();
      Node right12 = new Node();
      Node left121 = new Node();
      Node left1211 = new Node();
      Node right1212 = new Node();

      head.Left = left1;
      head.Right = right1;
      left1.Left = left12;
      left1.Right = right12;
      left12.Left = left121;
      left121.Left = left1211;
      left121.Right = right1212;

      return head;
    }

    public static Boolean IsBalanced(Node head)
    {
      if (head == null)
      {
        return true;
      }

      int leftHeight = Helper.FindHeight(head.Left);
      int rightHeight = Helper.FindHeight(head.Right);

      if (Math.Abs(leftHeight - rightHeight) > 1)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41 };
      Node head1 = Helper.CreateMinimalBST(array1);

      Console.WriteLine(IsBalanced(head1));

      Node head2 = CreateUnevenNode();

      Console.WriteLine(IsBalanced(head2));

    }
  }
}
