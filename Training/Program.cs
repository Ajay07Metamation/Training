//Program to check for Armstrong Number
using static System.Console;
Write ("Enter a number to check for Armstrong Number : ");
if (int.TryParse (ReadLine (), out int num) && num > 0)
   WriteLine ("It is " + (IsArmstrong (num) ? "" : "not ") + "a Armstrong Number");
else WriteLine ("Enter Valid Number");
bool IsArmstrong (int n) {
   int exp = n.ToString ().Length;
   int res = 0;
   while (n > 0) {
      int power = 1;
      for (int i = 0; i < exp; i++)
         power *= n % 10;
      res += power;
      n /= 10;
   }
   return (res == num) ? true : false;
}