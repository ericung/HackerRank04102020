using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _8dot2
{
  class Point
  {
    public int X;
    public int Y;

    public Point(int x, int y)
    {
      X = x;
      Y = y;
    }
  }

  class Program
  {
    public static List<Point> getPath(Boolean[][] maze)
    {
      if ((maze == null)||(maze.Length == 0))
      {
        return null;
      }

      List<Point> path = new List<Point>();
      HashSet<Point> failedPoints = new HashSet<Point>();
      if (getPath(maze, maze.Length - 1, maze[0].Length - 1, path, failedPoints))
      {
        return path;
      }

      return null;
    }

    public static Boolean getPath(Boolean[][] maze, int row, int col, List<Point> path, HashSet<Point> failedPoints)
    {
      /* If out of bounds or not available, return */
      if ((col < 0)||(row < 0)||(maze[row][col]))
      {
        return false;
      }

      Point p = new Point(row, col);

      /* If we've already visited this cell, return. */
      if (failedPoints.Contains(p))
      {
        return false;
      }

      Boolean isAtOrigin = (row == 0) && (col == 0);

      /* If there's a path from start to my current location, add my location */
      if ((isAtOrigin) || (getPath(maze, row, col-1, path, failedPoints)) || (getPath(maze, row-1, col, path, failedPoints)))
      {
        path.Add(p);
        return true;
      }

      failedPoints.Add(p);
      return false;
    }


    static void Main(string[] args)
    {
      Boolean[][] maze = new Boolean[100][];
      
      for(int i = 0; i < 100; i++)
      {
        maze[i] = new Boolean[100];
        for(int j = 0; j < 100; j++)
        {
          maze[i][j] = false;
        }
      }

      List<Point> path = getPath(maze);

      for(int i = 0; i < path.Count; i++)
      {
        Console.WriteLine(path[i].X + " " + path[i].Y);
      }
    }
  }
}
