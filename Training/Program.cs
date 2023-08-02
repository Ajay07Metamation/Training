//This program is spelling bee game
using static System.Console;
//Importing the words.txt file  
string[] words = File.ReadAllLines ("D:\\OneDrive - Trumpf Metamation Pvt Ltd\\Desktop\\ASSIGNMENTS\\words.txt");
char[] letters = new[] { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
int points = 0, total = 0;
//Creating a sorted dictionary to store the points and words as key value pairs
SortedDictionary<string, int> result = new SortedDictionary<string, int> ();
foreach (string word in words)
   //Applying all conditions to the words list
   //Word should have more than 4 letters
   //Word should contain the first letter of the letters array
   //Word should contain only letters in letters array
   if (word.Length >= 4 && word.Contains (letters[0]) && word.All (letters.Contains)) {
      //Calculating points based on whether it is a pangram or not
      //Adding the elememts to dictionary 
      //Condition to check if it is an pangram
      if (letters.All(letters => word.Contains(letters))){
         points = word.Length + 7;
         result.Add (word, points);
      } else {
         points = word.Length == 4 ? 1 : word.Length;
         result.Add (word, points);
      }
      total = total + points;
   }
//Printing the dictionary in descending order by value
foreach (var item in result.OrderByDescending (x => x.Value))
   //Condition to check if it is an pangram
   if (letters.All (letters => item.Key.Contains (letters))) {
      ForegroundColor = ConsoleColor.Green;
      WriteLine ($"{item.Value,4}.   {item.Key}");
      ResetColor ();
   } else Console.WriteLine ($"{item.Value,4}.   {item.Key}");
WriteLine ("-----");
WriteLine ($"{total,4}    Total");