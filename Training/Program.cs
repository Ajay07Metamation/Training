//Program to check Isogram
using static System.Console;
bool breakouter = false;
Write ("Enter a String : ");
String letter = ReadLine () ?? "";
//Using for loop
for (int ch = 0; ch < letter.Length - 1; ch++) {
   for (int ch1 = ch + 1; ch1 < letter.Length; ch1++) {
      if (letter[ch] == letter[ch1]) {
         WriteLine ("It is not an Isogram");
         breakouter = true;
         break;
      }
   }
   if (breakouter == true) break;
}
if (breakouter == false) WriteLine ("It is an Isogram");
// Using LINQ operator
if (letter.GroupBy (c => c).Any (g => g.Count () > 1)) WriteLine ("It is not an Isogram");
else WriteLine ("It is an Isogram");
