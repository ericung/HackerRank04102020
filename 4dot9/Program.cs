using ChapterFour;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _4dot9
{
  class Program
  {
    public static List<LinkedList<int>> AllSequence(Node node)
    {
      List<LinkedList<int>> result = new List<LinkedList<int>>();

      if (node == null)
      {
        result.Add(new LinkedList<int>());
        return result;
      }

      LinkedList<int> prefix = new LinkedList<int>();
      prefix.AddLast(node.Value);

      /* Recurse on left and right subtrees */
      List<LinkedList<int>> leftSeq = AllSequence(node.Left);
      List<LinkedList<int>> rightSeq = AllSequence(node.Right);

      /* Weave together each list from the left and right sides. */
      foreach (LinkedList<int> left in leftSeq)
      {
        foreach (LinkedList<int> right in rightSeq)
        {
          List<LinkedList<int>> weaved = new List<LinkedList<int>>();
          weaveLists(left, right, weaved, prefix);
          result.AddRange(weaved);
        }
      }
      return result;
    }

    /* Weave lists together in all possible ways. This algorithm works by removing the
     from one list, recursing, and then doing the same thing with the other list.*/
    public static void weaveLists(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results, LinkedList<int> prefix)
    {
      /* One list is empty. Add remainder to [a cloned] prefix and store result. */
      if (first.Count == 0 || second.Count == 0)
      {
        int[] prefixArray = new int[prefix.Count];
        prefix.CopyTo(prefixArray, 0);
        LinkedList<int> result = new LinkedList<int>(prefixArray);
        foreach(var item in first)
        {
          result.AddLast(item);
        }
        foreach(var item in second)
        {
          result.AddLast(item);
        }
        results.Add(result);
        return;
      }

      /* Recurse with head of first added to the prefix. Removing the head will damage
       * first, so we'll need to put it back where we found it afterwards. */
      int headFirst = first.First();
      first.RemoveFirst();
      prefix.AddLast(headFirst);
      weaveLists(first, second, results, prefix);
      prefix.RemoveLast();
      first.AddFirst(headFirst);

      /* Do the same thing with second, damging and then restoring the list. */
      int headSecond = second.First();
      second.RemoveFirst();
      prefix.AddLast(headSecond);
      weaveLists(first, second, results, prefix);
      prefix.RemoveLast();
      second.AddFirst(headSecond);
    }

    public static void PrintSequence(List<LinkedList<int>> sequences)
    {
      foreach(var linkedList in sequences)
      {
        int count = 0;
        String str = String.Empty;
        foreach(var item in linkedList)
        {
          str += item;
          
          if (count < linkedList.Count - 1)
          {
            str += " ";
          }

          count++;
        }

        Console.WriteLine(str);
      }
    }

    static void Main(string[] args)
    {
      //int[] array1 = { 1, 2, 4, 5, 6, 7, 10, 11, 23, 24, 27, 29, 39, 41 };
      int[] array1 = { 1, 2, 3, 4 };
      Node head1 = Node.CreateMinimalBST(array1);

      Node.Print(head1);

      List<LinkedList<int>> sequences = AllSequence(head1);

      PrintSequence(sequences);
      
      Console.WriteLine("================================================");

      Node head2 = new Node();
      Node head2Left = new Node();
      Node head2Right = new Node();

      head2.Left = head2Left;
      head2.Right = head2Right;

      head2.Value = 2;
      head2Left.Value = 1;
      head2Right.Value = 3;

      List<LinkedList<int>> sequences2 = AllSequence(head2);

      PrintSequence(sequences2);

    }
  }
}
