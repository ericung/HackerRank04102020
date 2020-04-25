using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4dot5
{
  class Program
  {
    public static Boolean ValidateBinarySearchTree(Node head)
    {
      return ValidateBinarySearchTree(head, null, null);
    }

    public static Boolean ValidateBinarySearchTree(Node head, int? min, int? max)
    {
      if (head == null)
      {
        return true;
      }

      if (((min != null)&&(head.Value <= min))||((max != null)&&(head.Value > max)))
      {
        return false;
      }

      if ((!ValidateBinarySearchTree(head.Left, min, head.Value))||(!ValidateBinarySearchTree(head.Right, head.Value, max)))
      {
        return false;
      }

      return true;
    }

    static void Main(string[] args)
    {
      int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41 };
      Node head1 = Helper.CreateMinimalBST(array1);

      Helper.Print(head1);
      Console.WriteLine(ValidateBinarySearchTree(head1));

      Console.WriteLine("=======================================================");
      Node head1r = Helper.CreateMinimalBSTRecursive(array1, 0, array1.Length - 1);

      Helper.Print(head1r);
      Console.WriteLine(ValidateBinarySearchTree(head1r));
    }
  }
}
