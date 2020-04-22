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

class Anagram
{
  public string Value;
  public Dictionary<char, int> Hash;
}

class Solution
{

  // Complete the sherlockAndAnagrams function below.
  // https://www.hackerrank.com/challenges/sherlock-and-anagrams/
  static int sherlockAndAnagrams(string s)
  {
    // Keep track of anagrams found and return it at the end.
    int anagramCount = 0;

    for (int length = 1; length < s.Length; length++)
    {
      Anagram[] array = new Anagram[s.Length - length + 1];

      for (int i = 0; (i + length) <= s.Length; i++)
      {
        Anagram anagram = new Anagram();
        anagram.Value = s.Substring(i, length);
        anagram.Hash = new Dictionary<char, int>();

        // Make a hash map of the string
        foreach (var c in anagram.Value)
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

        // Iterate the list while we are comparing strings of the same length
        foreach (var arrayItem in array)
        {
          bool isAnagram = true;

          if (arrayItem != null)
          {
            foreach (var ch in arrayItem.Value)
            {
              // Mark the current anagram with the existing list
              if (anagram.Hash.ContainsKey(ch))
              {
                if (anagram.Hash[ch] != arrayItem.Hash[ch])
                {
                  isAnagram = false;
                  break; // Unsure if break only works in first foreach
                }
              }
              else
              {
                isAnagram = false;
                break;
              }
            }
          }
          else
          {
            isAnagram = false;
          }

          if (isAnagram)
          {
            anagramCount++;
          }
        }

        array[i] = anagram;
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
