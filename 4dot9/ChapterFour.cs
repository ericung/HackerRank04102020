using System;
using System.Collections;

namespace ChapterFour
{
  public class Node
  {
    public int Value;
    public Node Parent;
    public Node Left;
    public Node Right;
    
    public static Node CreateMinimalBST(int[] array)
    {
      return CreateMinimalBST(array, 0, array.Length - 1);
    }

    public static Node CreateMinimalBST(int[] array, int start, int end)
    {
      if (end < start)
      {
        return null;
      }

      int middle = (start + end) / 2;
      Node head = new Node();
      head.Value = array[middle];
      head.Left = CreateMinimalBST(array, start, middle - 1);
      head.Right = CreateMinimalBST(array, middle + 1, end);
      
      if (head.Left != null)
      {
        head.Left.Parent = head;
      }

      if (head.Right != null)
      {
        head.Right.Parent = head;
      }

      return head;
    }

    // Helper method to assign height of tree
    public static int CheckHeight(Node head)
    {
      if (head == null)
      {
        return -1;
      }

      int leftHeight = CheckHeight(head.Left);
      if (leftHeight == Int32.MinValue) return Int32.MinValue;

      int rightHeight = CheckHeight(head.Right);
      if (rightHeight == Int32.MinValue) return Int32.MinValue;

      int heightDiff = leftHeight - rightHeight;
      if (Math.Abs(heightDiff) > 1)
      {
        return Int32.MinValue;
      }
      else
      {
        return Math.Max(leftHeight, rightHeight) + 1;
      }
    }

    public Boolean IsBalanced(Node head)
    {
      return CheckHeight(head) != Int32.MinValue;
    }

    public static void Print(Node head)
    {
      PrintHelper(head, 0);
    }

    // Print node and the levels
    public static void PrintHelper(Node head, int level)
    {
      if (head == null)
      {
        return;
      }

      Console.WriteLine(level + ": " + head.Value);

      PrintHelper(head.Left, level + 1);
      PrintHelper(head.Right, level + 1);
    }
  }
}
