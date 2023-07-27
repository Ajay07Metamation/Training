//This Program makes the computer guess what number we think.
//Think of a number
int Lowlimit, Highlimit, Baselimit;
Lowlimit = 0;
Highlimit = 100;
Baselimit = (Lowlimit + Highlimit) / 2;
Console.WriteLine ("Heyy computer I'm thinking of a number try to guess it ");
//Setting lowlimit,highlimit and mid range
for (int tries = 1; tries <= 7; tries++) {
   Console.Write ($"Is the number greater than {Baselimit} (Y)es / (N)o ?  ");
   var key = Console.ReadKey ().Key;
   if (key is ConsoleKey.Y)
      Lowlimit = Baselimit;
   else if (key is ConsoleKey.N)
      Highlimit = Baselimit;
   else {
      Console.WriteLine ("Enter valid number");
      continue;
   }
   //Reducing range after each iteration
   Baselimit = (Lowlimit + Highlimit) / 2;
   Console.WriteLine ();
}
//Printing the guess
Console.WriteLine ();
Console.WriteLine ($"The secret number is  {Highlimit} ");