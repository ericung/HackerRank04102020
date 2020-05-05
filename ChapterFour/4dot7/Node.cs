using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4dot7
{
  class Node
  {
    public string Name;
    public List<Node> Dependencies;
    public List<Node> Children;

    public Node()
    {
      Dependencies = new List<Node>();
      Children = new List<Node>();
    }

    public static Node[] CreateDependencyTree(string[] array, List<Tuple<string, string>> dependencies)
    {
      Node[] projectNodes = new Node[array.Length];
      Dictionary<string, Node> nameToProject = new Dictionary<string, Node>();

      for(int i = 0; i < array.Length; i++)
      {
        projectNodes[i] = new Node();
        projectNodes[i].Name = array[i];
        nameToProject[projectNodes[i].Name] = projectNodes[i];
      }

      foreach(var relationship in dependencies)
      {
        Node target = nameToProject[relationship.Item1];
        Node dependent = nameToProject[relationship.Item2];

        dependent.Dependencies.Add(target);
        target.Children.Add(dependent);
      }

      return projectNodes;
    }

    public static Node FindRoot(Node item)
    {
      Queue<Node> findingRoot = new Queue<Node>();
      Dictionary<string, int> traversed = new Dictionary<string, int>();
      findingRoot.Enqueue(item);
      Node root = item;

      while(findingRoot.Count > 0)
      {
        Node currentSuccessor = findingRoot.Dequeue();
        
        if (currentSuccessor.Dependencies.Count > 0)
        {
          foreach(var dependent in currentSuccessor.Dependencies)
          {
            if (!traversed.ContainsKey(dependent.Name))
            {
              findingRoot.Enqueue(dependent);
            }

            traversed[dependent.Name] = 1;
          }
        }

        root = currentSuccessor;
      }

      return root;
    }

    public static Queue<Node> FindBuildOrder(Node[] arrayOfNodes)
    {
      Dictionary<string, int> traversed = new Dictionary<string, int>(); // Optimized to check if node is already visited.
      Queue<Node> prepareOrderQueue = new Queue<Node>();
      List<Node> roots = new List<Node>();

      // Make sure each node in the list gets visited at least once.
      foreach(Node node in arrayOfNodes)
      {
        prepareOrderQueue.Enqueue(node);
      }

      // Find roots to each node.
      while(prepareOrderQueue.Count > 0)
      {
        // Operate on each node.
        Node iterative = prepareOrderQueue.Dequeue();

        // If node hasn't been analyzed yet, analyze it.
        if (!traversed.ContainsKey(iterative.Name))
        {
          Queue<Node> iterativeQueue = new Queue<Node>();
          iterativeQueue.Enqueue(iterative);

          while(iterativeQueue.Count > 0)
          {
            Node successor = iterativeQueue.Dequeue();

            // If the node has no dependecies, add it to the root node.
            if (successor.Dependencies.Count == 0)
            {
              roots.Add(successor);
            }
            else
            {
              foreach (var parent in successor.Dependencies)
              {
                // If node hasn't been operated on yet operate on it
                if (!traversed.ContainsKey(parent.Name))
                {
                  // Queue up the parent.
                  iterativeQueue.Enqueue(parent);
                  traversed[parent.Name] = 1;
                }
              }
            }
          }
        }

        traversed[iterative.Name] = 1;
      }

      // Organize results into buildOrderQueue variable.
      Dictionary<string, int> printed = new Dictionary<string, int>();
      Queue<Node> operatorQueue = new Queue<Node>();
      foreach (Node node in roots)
      {
        operatorQueue.Enqueue(node);
      }

      Queue<Node> buildOrderQueue = new Queue<Node>();
      while(operatorQueue.Count > 0)
      {
        Node next = operatorQueue.Dequeue();
        if (!printed.ContainsKey(next.Name))
        {
          Boolean shouldPrint = true;

          foreach(Node dependent in next.Dependencies)
          {
            Console.WriteLine(next.Name);

            if (!printed.ContainsKey(dependent.Name))
            {
              shouldPrint = false;
            }
          }

          if (shouldPrint)
          {
            buildOrderQueue.Enqueue(next);

            foreach(Node child in next.Children)
            {
              operatorQueue.Enqueue(child);
            }

            printed[next.Name] = 1;
          }
          else
          {
            operatorQueue.Enqueue(next);
          }
        }
      }

      if (buildOrderQueue.Count != arrayOfNodes.Length)
      {
        throw new Exception("Cycle in graph");
      }
      else
      {
        return buildOrderQueue;
      }
    }
    

    public static void Print(Node head)
    {
      Dictionary<string, int> printStatus = new Dictionary<string, int>(); // No duplicate children
      Queue<Node> printQueue = new Queue<Node>();
      printQueue.Enqueue(head);

      while(printQueue.Count > 0 )
      {
        Node printing = printQueue.Dequeue();

        Console.WriteLine(printing.Name);

        foreach(var children in printing.Children)
        {
          if (!printStatus.ContainsKey(children.Name))
          {
            printQueue.Enqueue(children);
          }

          printStatus[children.Name] = 1;
        }
      }
    }

    public static void PrintQueue(Queue<Node> queue)
    {
      String printString = String.Empty;
      while(queue.Count > 0)
      {
        printString += queue.Dequeue().Name;
        if (queue.Count >= 1)
        {
          printString += " ";
        }
      }

      Console.WriteLine(printString);
    }
  }
}
