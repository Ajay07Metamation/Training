//This Program makes the computer guess what number we think.
//Think of a number
Console.ForegroundColor = ConsoleColor.Cyan;
int lowLimit = 0,highLimit = 100,baseLimit = (lowLimit + highLimit) / 2;
Console.WriteLine ("Heyy computer I'm thinking of a number between 1 to 100" + '\n' + "Try to guess it ");
Console.ResetColor();
//Setting lowlimit,highlimit and mid range
for (int tries = 1; tries <= 7; tries++) {
   Console.Write ($"Is the number greater than {baseLimit} (Y)es / (N)o ?  ");
   switch (Console.ReadKey ().Key) {
      case ConsoleKey.Y:
         lowLimit = baseLimit;
         break;
      case ConsoleKey.N:
         highLimit = baseLimit;
         break;
      default:
         Console.WriteLine ("Enter valid number");
         break;
   } 
   //Reducing range after each iteration
   baseLimit = (lowLimit + highLimit) / 2;
   Console.WriteLine ();
}
//Printing the guess
Console.WriteLine ();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine ($"The secret number is  {highLimit} ");
Console.ResetColor ();