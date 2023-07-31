//This Program makes the computer guess what number we think.
//Think of a number
int LowLimit = 0;
int HighLimit = 100;
int BaseLimit = (LowLimit + HighLimit) / 2;
Console.WriteLine ("Heyy computer I'm thinking of a number try to guess it ");
//Setting lowlimit,highlimit and mid range
for (int tries = 1; tries <= 7; tries++) {
   Console.Write ($"Is the number greater than {BaseLimit} (Y)es / (N)o ?  ");
   var key = Console.ReadKey ().Key;
   switch (key) {
      case ConsoleKey.Y:
         LowLimit = BaseLimit;
         break;
      case ConsoleKey.N:
         HighLimit = BaseLimit;
         break;
      default:
         Console.WriteLine ("Enter valid number");
         break;
   } 
   //Reducing range after each iteration
   BaseLimit = (LowLimit + HighLimit) / 2;
   Console.WriteLine ();
}
//Printing the guess
Console.WriteLine ();
Console.WriteLine ($"The secret number is  {HighLimit} ");