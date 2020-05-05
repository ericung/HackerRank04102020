using System;
using System.Collections;

namespace _4dot3
{
  public class Node
  {
    public int Value;
    public int Height;
    public int Level;
    public Node Parent;
    public Node Left;
    public Node Right;
  }
  public class Helper
  {

    // Create a leveled binary tree using Breadth First Search
    public static Node CreateMinimalBST(int[] array)
    {
      Node head = new Node();

      // Check if the array is empty
      if ((array == null) || (array.Length == 0))
      {
        return head;
      }

      // Initiate iteration variables that will help in creating the tree.
      Node iterative = head;
      iterative.Value = array[0];
      int position = 1;
      
      // This queue will keep track of the nodes that have no children.
      Queue noChildren = new Queue();

      while (position < array.Length)
      {
        // Queue the left node
        if (iterative.Left == null)
        {
          Node left = new Node();
          left.Value = array[position];
          left.Parent = iterative;
          iterative.Left = left;
          noChildren.Enqueue(left);
          position++;
        }
        // Queue the right node
        else if (iterative.Right == null)
        {
          Node right = new Node();
          right.Value = array[position];
          right.Parent = iterative;
          iterative.Right = right;
          noChildren.Enqueue(right);
          position++;
        }
        else if ((iterative.Left != null)&&(iterative.Right != null))
        {
          // If the current node is filled, find one that isn't;
          iterative = (Node)noChildren.Dequeue();
        }
      }

      AssignHeight(head);
      AssignLevel(head, 0);

      return head;
    }

    // Helper method to assign height of tree
    private static void AssignHeight(Node head)
    {
      // Property to call FindHeight once.
      int height = FindHeight(head);

      Queue assignQueue = new Queue();
      assignQueue.Enqueue(head);
      
      while(assignQueue.Count > 0)
      {
        Node beingAssigned = (Node)assignQueue.Dequeue();
        if (beingAssigned != null)
        {
          beingAssigned.Height = height;

          assignQueue.Enqueue(beingAssigned.Left);
          assignQueue.Enqueue(beingAssigned.Right);
        }
      }
    }

    public static void AssignLevel(Node head, int level)
    {
      if (head == null)
      {
        return;
      }

      head.Level = level;

      AssignLevel(head.Left, level + 1);
      AssignLevel(head.Right, level + 1);
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

    // Find the height of the binary search tree.
    public static int FindHeight(Node head)
    {
      return FindHeightHelper(head, 0);
    }

    // Helper method called on with an extra argument to keep track of height
    public static int FindHeightHelper(Node head, int height)
    {
      if (head == null)
      {
        return height;
      }

      int leftHeight = FindHeightHelper(head.Left, height + 1);
      int rightHeight = FindHeightHelper(head.Right, height + 1);

      if (leftHeight >= rightHeight)
      {
        return leftHeight;
      }
      else
      {
        return rightHeight;
      }
    }
  }
}
