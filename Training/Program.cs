// ABECEDARIAN WORD
using static System.Console;
WriteLine ("Enter word to convert into ABECEDARIAN WORD");
string word = Console.ReadLine () ?? "";
var wordcheck = word.ToLower ().ToArray ();
Array.Sort (wordcheck);
if (wordcheck.GroupBy (x => x).Any (c => c.Count () == wordcheck.Length))
   WriteLine ("It is not an ABECEDARIAN WORD");
else Console.WriteLine ($"ABECEDARIAN WORD : {String.Concat (wordcheck)}");