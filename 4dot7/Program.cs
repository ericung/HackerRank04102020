using System;
using System.Collections.Generic;

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
      Node.PrintQueue(buildOrderQueue);

      Console.WriteLine("============================");

      string[] projects02 = { "a", "b", "c", "d", "e", "f", "g" };
      List<Tuple<string, string>> dependencies02 = new List<Tuple<string, string>>();
      dependencies02.Add(Tuple.Create("f", "c"));
      dependencies02.Add(Tuple.Create("f", "a"));
      dependencies02.Add(Tuple.Create("f", "b"));
      dependencies02.Add(Tuple.Create("d", "g"));
      dependencies02.Add(Tuple.Create("c", "a"));
      dependencies02.Add(Tuple.Create("b", "a"));
      dependencies02.Add(Tuple.Create("a", "e"));

      Node[] arrayOfNodes02 = Node.CreateDependencyTree(projects02, dependencies02);
      Queue<Node> buildOrderQueue02 = Node.FindBuildOrder(arrayOfNodes02);
      Node.PrintQueue(buildOrderQueue02);

    }
  }
}
