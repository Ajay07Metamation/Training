//Program to get Integral and Fractional part of a decimal
using static System.Console;
Write ("Enter any number : ");
if (double.TryParse (ReadLine (), out double num))
   GetDigit (num);
else WriteLine ("Enter Valid Number");
void GetDigit (double num) {
   string numword = num.ToString ();
   var n = numword.IndexOf ('.');
   Write ("Integral Part : ");
   for (int i = 0; i < numword.Length; i++) {
      if (i == n) {
         Write ($"\nFractional part : ");
         i++;
      }
      Write (numword[i] + " ");
   }
}
