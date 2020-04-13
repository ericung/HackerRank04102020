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

public class Anagram
{
  public string Value;
  public Dictionary<char, int> Hash;
}

class Solution
{

  // This solution is the brute force version
  // Complete the sherlockAndAnagrams function below.
  static int sherlockAndAnagrams(string s)
  {
    int anagramCount = 0;
    List<List<Anagram>> lengthGroup = new List<List<Anagram>>();
    for (int i = 0; i < s.Length; i++)
    {
      lengthGroup.Add(new List<Anagram>());
    }

    // enumerate out all the possible derivations of s.
    for (int i = 0; i < s.Length; i++)
    {
      for (int j = 1; j <= s.Length; j++)
      {
        if ((s.Length - i) - j >= 0)
        {
          Anagram anagram = new Anagram();
          anagram.Value = s.Substring(i, j);
          anagram.Hash = new Dictionary<char, int>();
          foreach (char c in anagram.Value)
          {
            if (anagram.Hash.ContainsKey(c))
            {
              anagram.Hash[c]++;
            }
            else
            {
              anagram.Hash.Add(c, 1);
            }
          }

          lengthGroup[j - 1].Add(anagram);
        }
      }
    }

    // iterate through and compare the values, brute force
    for (int i = 0; i < s.Length; i++)
    {
      for (int j = 0; j < lengthGroup[i].Count; j++)
      {
        Anagram item = lengthGroup[i].ElementAt(j);
        // Console.WriteLine(j + ": " + item.Value);
        for (int k = j + 1; k < lengthGroup[i].Count; k++)
        {
          Anagram compare = lengthGroup[i].ElementAt(k);
          // Console.WriteLine(j + " : " + k + " = " + compare.Value);
          bool isAnagram = true;
          foreach (char e in item.Value)
          {
            if (!compare.Hash.ContainsKey(e))
            {
              isAnagram = false;
            }
            else
            {
              if (item.Hash[e] != compare.Hash[e])
                isAnagram = false;
            }
          }

          if (isAnagram)
          {
            // Console.WriteLine(item.Value + " = " + compare.Value);
            anagramCount++;
          }
        }
        // Console.WriteLine("================");
      }
    }

    return anagramCount;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int q = Convert.ToInt32(Console.ReadLine());

    for (int qItr = 0; qItr < q; qItr++)
    {
      string s = Console.ReadLine();

      int result = sherlockAndAnagrams(s);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}

