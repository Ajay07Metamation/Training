using System.Runtime;
using static System.Console;
var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter the first number : ");
   int.TryParse (Console.ReadLine (), out int num1);
   Write ("Enter the second number : ");
   int.TryParse (Console.ReadLine (), out int num2);
   Write ("Do you want to convert it into (L)CM or (G)CD ?  ");
   switch (Console.ReadKey ().Key) {
      case ConsoleKey.L:
         WriteLine ();
         WriteLine (lcm (num1, num2));
         break;
      case ConsoleKey.G:
         WriteLine ();
         WriteLine (gcd (num1, num2));
         break;
      default:
         WriteLine ("Enter a valid key");
         break;
   }
   WriteLine ("Do you want to convert again");
   key = ReadKey ().Key;
   WriteLine ();
}
int lcm (int num1, int num2) {
   int lcm = ((num1 * num2) / gcd (num1, num2));
   return lcm;
}
int gcd (int num1, int num2) {
   int gcd = 0;
   if (num1 > num2) {
      if (!(num1 % num2 == 0))
         (num1, num2) = (num2, num1 % num2);
      gcd = num2;
   } else {
      if (!(num2 % num1 == 0))
         (num2, num1) = (num1, num2 % num1);
      gcd = num1;
   }
   return gcd;
}