// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Anagram
// To find anagrams from the given text file
// ----------------------------------------------------------------------------------------

using static System.Console;

internal class Program {
   private static void Main (string[] args) {
      // Sort each word in alphabetical order and group them
      var anagram = File.ReadAllLines ("C:/etc/words.txt")
          .GroupBy (word => string.Concat (word.OrderBy (ch => ch)))
          .Where (word => word.Count () > 1) 
          .OrderByDescending (word => word.Count ()) 
          .ToList ();
      anagram.ForEach (g => WriteLine ($"{g.Count ()} {string.Join (", ", g)}"));
      // Writing the output to a file
      using (var stream = new StreamWriter ("C:/etc/Anagrams.txt"))
         anagram.ForEach (word => stream.WriteLine ($"{word.Count ()} {string.Join (", ", word)}"));
   }
}