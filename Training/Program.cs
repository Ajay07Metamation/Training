using static System.Console;
var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter a Number : ");
   if (int.TryParse (Console.ReadLine (), out int num)) {
      Write ("Do you want to convert it into (B)inary or (H)exadecimal ?  ");
      switch (Console.ReadKey ().Key) {
         case ConsoleKey.B:
            WriteLine ();
            WriteLine ($"The number in Binary is : {Convert.ToString (num, 2)}");
            break;
         case ConsoleKey.H:
            WriteLine ();
            WriteLine ($"The number in Hexadecimal is : {num:X}");
            break;
         default:
            WriteLine ("Enter a valid key");
            break;
      }
      WriteLine ("Do you want to convert again");
      key = ReadKey ().Key;
      WriteLine ();
   }
}
