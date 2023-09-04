//Program to get all possible permutations of a string
using static System.Console;
string answer = "";
string[] permuteWord = {};
Write ("Enter the string : ");
string word = ReadLine () ?? "";
if (word.Length > 0 && word.All (char.IsLetter)) {
   Write ("\nAll Possible Permutations are : \n");
   PrintPermute (word, answer);
} else WriteLine ("Enter Valid Input");
void PrintPermute (string word, string answer) {
   if (word.Length == 0) {
      Write ($"{answer}\n");
      return;
   }
   for (int i = 0; i < word.Length; i++) 
      PrintPermute (word[..i] + word[(i+1)..], answer + word[i]);
}