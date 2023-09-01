//Program to check for Amstrong Number
using static System.Console;
Write ("Enter a number to check for Armstrong Number : ");
if (int.TryParse (ReadLine (), out int num) && num > 0)
   GetAmstrong (num);
else WriteLine ("Enter Valid Number");
void GetAmstrong (int n) {
   int exp = n.ToString ().Length;
   double res = 0;
   while (n > 0) {
      res += Math.Pow ((n % 10), exp);
      n /= 10;
   }
   WriteLine ($"It is {((res == num) ? "" : "not ")}an Armstrong Number");
}