using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    int num = 0;
    string filePath = "text1.txt";
    string textFromFile = File.ReadAllText(filePath);
    string cleanedText = new string(textFromFile.Where(c => !char.IsPunctuation(c)).ToArray());
    cleanedText = cleanedText.ToLower();
    string[] words = cleanedText.Split(' ');
    Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();
    foreach (string word in words)
    {
      if (word.Length >= 3 && word.Length <= 20)
      {
        if(!wordFrequencies.ContainsKey(word))
        {
          wordFrequencies.Add(word, 1);
        }
        else
        {
          wordFrequencies[word]++;
        }
      }
    }
    wordFrequencies = wordFrequencies.OrderByDescending(x=>x.Value).Take(50).ToDictionary(x => x.Key, x => x.Value);
    Console.WriteLine("Number -- Word -- Frequency");
    foreach (KeyValuePair<string, int> item in wordFrequencies)
    {
      num++;
      Console.WriteLine($"{num} -- {item.Key} -- {item.Value}");
    }
  }
}