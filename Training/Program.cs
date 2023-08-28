// ABECEDARIAN WORD
using static System.Console;
WriteLine ("Enter word to convert into ABECEDARIAN WORD");
string word = ReadLine () ?? "";
WriteLine (Abecedarian (word));
string Abecedarian (string s) {
   var wordcheck = word.ToLower ().ToArray ();
   Array.Sort (wordcheck);
   if (wordcheck.GroupBy (x => x).Any (c => c.Count () == wordcheck.Length))
      return "ABECEDARIAN WORD : ";
   return "ABECEDARIAN WORD : " + string.Join ("", wordcheck);
} 