//Program to get all possible permutations of a string
using static System.Console;
string answer = "";
Write ("Enter the string : ");
string word = ReadLine () ?? "";
if (word.Length > 0 && word.All (char.IsLetter)) {
   Write ("\nAll Possible Permutations are : \n");
   GetPermute (word, answer);
} else WriteLine ("Enter Valid Input");
void GetPermute (string word, string answer) {
   if (word.Length == 0) {
      Write ($"{answer}\n");
      return;
   }
   for (int i = 0; i < word.Length; i++) {
      char ch = word[i];
      string leftstr = word.Substring (0, i);
      string rightstr = word.Substring (i + 1);
      string reststr = leftstr + rightstr;
      GetPermute (reststr, answer + ch);
   }
}