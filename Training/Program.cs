// ABECEDARIAN WORD
using static System.Console;

WriteLine ("Enter how many words do you want to give");
if (int.TryParse (ReadLine (), out int size) && size > 0)
   GetAbecedarian (size);
else WriteLine ("Enter Valid Input");

void GetAbecedarian (int size) {
   string[] words = new string[size];
   for (int index = 0; index < size; index++) {
      WriteLine ($"Enter Word {index + 1} : ");
      words[index] = ReadLine () ?? "";
      if (words[index].Length < 1 || !words[index].All (char.IsLetter)) {
         WriteLine ("Invalid Input");
         index--;
      }
   }
   var SortedWord = words.Where (word => word == string.Join ("", word.OrderBy (c => c)));
   string result = SortedWord.Count () > 0 ? "The Longest ABECEDARIAN Word is : " +
                                                $"{SortedWord.OrderByDescending (word => word.Length).First ()}"
                                                : "No Abecedarian word in the array";
   WriteLine (result);
}