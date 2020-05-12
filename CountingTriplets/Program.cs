using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
  // Complete the countTriplets function below.
  static long countTriplets(List<long> arr, long r)
  {
    long answer = 0;
    Dictionary<long, long> left = new Dictionary<long, long>();
    Dictionary<long, long> right = new Dictionary<long, long>();

    for (int i = 0; i < arr.Count; i++)
    {
      if (right.ContainsKey(arr[i]))
      {
        right[arr[i]]++;
      }
      else
      {
        right[arr[i]] = 1;
      }

      left[arr[i]] = 0;
    }

    for (int i = 0; i < arr.Count; i++)
    {
      right[arr[i]]--;

      if (arr[i] % r == 0)
      {
        long leftIndex = arr[i] / r;
        long rightIndex = arr[i] * r;
        if (!left.ContainsKey(leftIndex))
        {
          left[leftIndex] = 0;
        }

        if (!right.ContainsKey(rightIndex))
        {
          right[rightIndex] = 0;
        }

        answer += left[leftIndex] * right[rightIndex];
      }

      left[arr[i]]++;
    }

    return answer;
  }


  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string[] nr = Console.ReadLine().TrimEnd().Split(' ');

    int n = Convert.ToInt32(nr[0]);

    long r = Convert.ToInt64(nr[1]);

    List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

    long ans = countTriplets(arr, r);

    textWriter.WriteLine(ans);

    textWriter.Flush();
    textWriter.Close();
  }
}

