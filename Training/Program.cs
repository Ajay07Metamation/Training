//Program to check Isogram
using static System.Console;
Write ("Enter a String : ");
String letter = ReadLine () ?? "";
WriteLine(IsIsogram(letter));
string IsIsogram(string s) {
   WriteLine("Method - 1");
   if (s.Length>= 1) {
      for (int ch = 0; ch < letter.Length - 1; ch++)
         for (int ch1 = ch + 1; ch1 < letter.Length; ch1++)
            if (letter[ch] == letter[ch1]) {
               return "It is not an Isogram\n";
            } 
      return "It is an Isogram\n";
   }return "Invalid Input\n";
}
// Using LINQ operator
WriteLine("Method - 2");
if (letter.Length >= 1) {
   if (letter.GroupBy (c => c).Any (g => g.Count () > 1)) WriteLine ("It is not an Isogram");
   else WriteLine ("It is an Isogram");
} else WriteLine ("Invalid Input");