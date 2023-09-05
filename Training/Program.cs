//Program to get Integral and Fractional part of a decimal
using static System.Console;

Write ("Enter any number : ");
if (double.TryParse (ReadLine (), out double num)) {
   PrintIntegral (num);
   PrintFractional (num);
} else WriteLine ("Enter Valid Number");

void PrintIntegral (double num) {
   //Storing digits of integral part of number in a Array and printing it
   int integral = (int)num;
   int integralLength = integral.ToString ().Length;
   int[] integralarr = new int[integralLength];
   for (int i = integralLength - 1; i >= 0; i--) {
      integralarr[i] = integral % 10;
      integral /= 10;
   }
   Write ("Integral Part : ");
   foreach (var integ in integralarr) {
      Write (integ + " ");
   }
}

void PrintFractional (double num) {
   //Converting number into string and printing fractional part
   string numword = num.ToString ();
   if (numword.All (char.IsNumber)) {
      WriteLine ("\nNo Fractional Part");
      return;
   }
   var n = numword.IndexOf ('.');
   Write ($"\nFractional part : ");
   for (int i = n + 1; i < numword.Length; i++)
      Write (numword[i] + " ");
}

