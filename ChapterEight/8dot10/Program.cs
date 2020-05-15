using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8dot10
{
  class Program
  {
    public enum Color { Black, White, Red, Yellow, Green }

    public static Boolean PaintFill(Color[][] screen, int r, int c, Color ncolor)
    {
      if (screen[r][c] == ncolor) return false;
      return PaintFill(screen, r, c, screen[r][c], ncolor);
    }

    public static Boolean PaintFill(Color[][] screen, int r, int c, Color ocolor, Color ncolor)
    {
      if (r < 0 || r >= screen.Length || c < 0 || c >= screen[0].Length)
      {
        return false;
      }

      if (screen[r][c] == ocolor)
      {
        screen[r][c] = ncolor;
        PaintFill(screen, r - 1, c, ocolor, ncolor); // up
        PaintFill(screen, r + 1, c, ocolor, ncolor); // down
        PaintFill(screen, r, c - 1, ocolor, ncolor); // left
        PaintFill(screen, r, c + 1, ocolor, ncolor); // right
      }

      return true;
    }

    static void Main(string[] args)
    {
      Color[][] screen = new Color[100][];

      for (int i = 0; i < 100; i ++)
      {
        screen[i] = new Color[100];
        for(int j = 0; j < 100; j++)
        {
          screen[i][j] = Color.Red;
        }
      }

      Boolean result = PaintFill(screen, 50, 50, Color.Yellow);

      Console.WriteLine(result);
    }
  }
}
