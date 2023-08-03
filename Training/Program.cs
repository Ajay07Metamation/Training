//This Program makes the computer guess what number we think.
using static System.Console;
//Setting lowlimit,highlimit and mid range
WriteLine ("Heyy user think of a number between 1 to 100" + '\n' + "The computer will guess it ");
ResetColor ();
double N = 2, remainder = 0, power = 0, secret = 0;
for (int tries = 1; tries <= 7; tries++) {
   //Finding the bits from LSB TO MSB
   //Computing the secret number 
   Write ($"Is the remainder when divided by {N} is {remainder} (Y)es / (N)o ?  ");
   switch (ReadKey ().Key) {
      case ConsoleKey.Y:
         if (tries == 1) remainder = 0;
         secret = secret + (0 * (Math.Pow (2, power)));
         power++;
         N = Math.Pow (2, power + 1);
         break;
      case ConsoleKey.N:
         secret = secret + (1 * (Math.Pow (2, power)));
         remainder = remainder + (N / 2);
         power++;
         N = Math.Pow (2, power + 1);
         break;
      default:
         WriteLine ("Enter valid number");
         break;
   }
   WriteLine ();
}
//Printing the guess
WriteLine ();
ForegroundColor = ConsoleColor.Green;
WriteLine ($"The secret number is {secret}");
ResetColor ();