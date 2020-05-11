using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _8dot6
{
  public class Tower
  {
    private Stack<int> Disks;
    private int _Index;

    public Tower(int i)
    {
      Disks = new Stack<int>();
      _Index = i;
    }

    public int Index()
    {
      return _Index;
    }

    public void Add(int d)
    {
      if ((Disks.Count>0) && Disks.Peek() <= d)
      {
        Console.WriteLine("It's empty!");
      } 
      else
      {
        Disks.Push(d);
      }
    }

    public void MoveTopTo(Tower t)
    {
      int top = Disks.Pop();
      t.Add(top);
    }

    public void MoveDisks(int n, Tower destination, Tower buffer)
    {
      if (n>0)
      {
        MoveDisks(n - 1, buffer, destination);
        Console.WriteLine(n - 1 + " : " +  destination.Index());
        MoveTopTo(destination);
        buffer.MoveDisks(n - 1, destination, this);
      }
    }
  }
  
  public class Program
  {
    static void Main(string[] args)
    {
      int n = 3;
      Tower[] towers = new Tower[n];
      for (int i = 0; i < 3; i++)
      {
        towers[i] = new Tower(i);
      }

      for (int i = n - 1; i >= 0; i--)
      {
        towers[0].Add(i);
      }

      towers[0].MoveDisks(n, towers[2], towers[1]);
    }
  }
}
