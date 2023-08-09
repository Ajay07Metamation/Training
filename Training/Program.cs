using static System.Console;
Write ("Enter a number : ");
int.TryParse (Console.ReadLine (), out int num);
int i;
if (num == 1) Console.WriteLine ("1 is neither prime nor composite");
else {
   for (i = 2; i <= num / 2; i++) {
      if (num % i == 0) {
         Console.WriteLine ("It is not a Prime Number");
         break;
      }
   }
   if (i > (num / 2)) Console.WriteLine ("It is a Prime Number");
}