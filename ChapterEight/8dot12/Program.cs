using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot12
{
  class Program
  {
    public static int GRID_SIZE = 8;

    public static void placeQueens(int row, int[] columns, List<int[]> results)
    {
      if (row == GRID_SIZE)
      {
        results.Add(columns);
      } else
      {
        for (int col = 0; col < GRID_SIZE; col++)
        {
          if (checkValid(columns, row, col))
          {
            if (checkValid(columns, row, col))
            {
              columns[row] = col;
              placeQueens(row + 1, columns, results);
            }
          }
        }
      }
    }

    public static Boolean checkValid(int[] columns, int row1, int column1)
    {
      for (int row2 = 0; row2 < row1; row2++)
      {
        int column2 = columns[row2];

        if (column1 == column2)
        {
          return false;
        }
        int columnDistance = Math.Abs(column2 - column1);

        int rowDistance = row1 - row2;
        if (columnDistance == rowDistance)
        {
          return false;
        }
      }

      return true;
    }

    static void Main(string[] args)
    {
      int[] columns = new int[8];
      List<int[]> results = new List<int[]>();

      placeQueens(0, columns, results);

      foreach (var place in results)
      {
        foreach(var item in place)
        {
          Console.Write(item + " ");
        }

        Console.WriteLine("");
      }
    }
  }
}
