//Program to Get Factorial of a Given Number
using static System.Console;
WriteLine ("Enter the number to calculate factorial : ");
if (int.TryParse (ReadLine (), out int num) && num >= 0)
   WriteLine ($"The Factorial of {num} is : " + GetFactorial (num));
else WriteLine ("Enter Valid Number");
double GetFactorial (int n) {
   if (n == 0) return 1;
   return n * GetFactorial (n - 1);
}