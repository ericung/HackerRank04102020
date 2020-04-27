using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4dot7
{
  class Program
  {

    static void Main(string[] args)
    {
      string[] projects = { "a", "b", "c", "d", "e", "f" };
      List<Tuple<string, string>> dependencies = new List<Tuple<string, string>>();
      dependencies.Add(Tuple.Create("a", "d"));
      dependencies.Add(Tuple.Create("f", "b"));
      dependencies.Add(Tuple.Create("b", "d"));
      dependencies.Add(Tuple.Create("f", "a"));
      dependencies.Add(Tuple.Create("d", "c"));

      Node[] arrayOfNodes = Node.CreateDependencyTree(projects, dependencies);
      Queue<Node> buildOrderQueue = Node.FindBuildOrder(arrayOfNodes);

      String printString = String.Empty;
      while(buildOrderQueue.Count > 0)
      {
        printString += buildOrderQueue.Dequeue().Name;
        if (buildOrderQueue.Count >= 1)
        {
          printString += " ";
        }
      }

      Console.WriteLine(printString);

    }
  }
}
