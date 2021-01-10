using System;

namespace Playground01102021
{
  class Program
  {

    public void fizzBuzz(int[] array)
    {
      for (int i = 0; i < array.Length; i++) {
        if ((array[i] % 3 == 0)&&(array[i] % 5 == 0)) {
          Console.WriteLine("fizz buzz");
        }
        else if (array[i] % 3 == 0)
        {
          Console.WriteLine("fizz");
        }
        else if (array[i]%5 == 0)
        {
          Console.WriteLine("buzz");
        } else
        {
          Console.WriteLine(array[i]);
        }
      }
    }

    static void Main(string[] args)
    {
      int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

      Program program = new Program();

      program.fizzBuzz(array);
    }
  }
}
