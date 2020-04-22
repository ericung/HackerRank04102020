using System;
using System.Collections;

namespace _4dot2
{
  class Node
  {
    public int Value;
    public Node Left;
    public Node Right;
  }
  class Program
  {
    // Create a leveled binary tree using Breadth First Search
    static Node CreateMinimalBST(int[] array)
    {
      Node head = new Node();
      Queue queue = new Queue();

      // Check if the array is empty
      if ((array == null) || (array.Length == 0))
      {
        return head;
      }

      Node iterative = head;
      iterative.Value = array[0];
      queue.Enqueue(iterative);
      int position = 1;

      while (position < array.Length)
      {
        // Queue the left node
        if (iterative.Left == null)
        {
          Console.WriteLine("Left: " + array[position]);
          Node left = new Node();
          left.Value = array[position];
          iterative.Left = left;
          queue.Enqueue(left);
          position++;
        }
        // Queue the right node
        else if (iterative.Right == null)
        {
          Console.WriteLine("Right: " + array[position]);
          Node right = new Node();
          right.Value = array[position];
          iterative.Right = right;
          queue.Enqueue(right);
          position++;
        }
        else if ((iterative.Left != null)&&(iterative.Right != null))
        {
          // If the current node is filled, find one that isn't;
          Console.WriteLine("Reset: ");
          iterative = (Node)queue.Dequeue();
        }
      }

      return head;
    }

    // Solution from the book
    static Node NodeCreateMinimalBSTRecursive(int[] array, int start, int end)
    {
      if (end < start)
      {
        return null;
      }

      int middle = (start + end) / 2;
      Node head = new Node();
      head.Value = array[middle];
      head.Left = NodeCreateMinimalBSTRecursive(array, start, middle - 1);
      head.Right = NodeCreateMinimalBSTRecursive(array, middle + 1, end);
      return head;
    }

    // Print node and the levels
    public static void Print(Node head, int level)
    {
      if (head == null)
      {
        return;
      }

      Console.WriteLine(level + ": " + head.Value);

      Print(head.Left, level + 1);
      Print(head.Right, level + 1);
    }

    static void Main()
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41 };
      Node head1 = CreateMinimalBST(array1);
      Print(head1, 0);

      Console.WriteLine("&&&&&&&&&&&&&&");

      Node head1r = NodeCreateMinimalBSTRecursive(array1, 0, array1.Length - 1);
      Print(head1r, 0);


      Console.WriteLine("=============================================");
      int[] array2 = { 1, 2, 4, 5 , 9};
      Node head2 = CreateMinimalBST(array2);
      Print(head2, 0);

      Console.WriteLine("&&&&&&&&&&&&&&");

      Node head2r = NodeCreateMinimalBSTRecursive(array2, 0, array2.Length - 1);
      Print(head2r, 0);
    }
  }
}
