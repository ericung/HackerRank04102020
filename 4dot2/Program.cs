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
    static Node CreateBinaryTree(int[] array)
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
      Node head1 = CreateBinaryTree(array1);
      Print(head1, 0);

      Console.WriteLine("=============================================");
      int[] array2 = { 1, 2, 4, 5 };
      Node head2 = CreateBinaryTree(array2);
      Print(head2, 0);
    }
  }
}
