// ABECEDARIAN WORD
using static System.Console;
WriteLine ("Enter how many words do you want to give");
if (int.TryParse (ReadLine (), out int index)) {
   string[] words = new string[index];
   for (int i = 0; i < index; i++) {
      WriteLine ($"Enter Word {i + 1} : ");
      words[i] = ReadLine () ?? "";
      if (words[i].All(char.IsLetter));
      else {
         WriteLine ("Invalid Input");
         i--;
      }
   }
   var sortedword = words.Where (word => word == string.Join ("", word.OrderBy (c => c)));
   string result = sortedword.Count () > 0 ? "The Longest ABECEDARIAN Word is : " +
                                             $"{sortedword.OrderByDescending (word => word.Length).First ()}" 
                                             : "No Abecedarian word in the array";
   WriteLine (result);  
} else WriteLine ("Enter Valid Input");