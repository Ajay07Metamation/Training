﻿using static System.Console;
var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter a Number : ");
   if (int.TryParse (Console.ReadLine (), out int num)) {
      Write ("Do you want to convert it into (B)inary or (H)exadecimal ?  ");
      switch (Console.ReadKey ().Key) {
         case ConsoleKey.B:
            WriteLine ();
            WriteLine ($"The number in Binary is : {Convert.ToString (num, 2)}");
            WriteLine($"The number in Binary is : " + binary (num));
            break;
         case ConsoleKey.H:
            WriteLine ();
            WriteLine ($"The number in Hexadecimal is : {num:X}");
            WriteLine ($"The number in Hexadecimal is : " + hexadecimal(num));
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

String binary (int num) {
   string result = "";
   while (num != 0) {
      result += (num % 2).ToString ();
      num= num / 2;
   }
   return String.Concat(result.Reverse());
}

String hexadecimal(int num) {
   string[] hexa = new string[] { "A", "B", "C", "D", "E", "F" };
   string result = "";
   while (num != 0) {
      if (num % 16 < 10) {
         result += (num % 16).ToString ();
         num = num / 16;
      }
      if (num%16 >=10 && num %16 <=16) {
         result += (hexa[(num%16)%10]).ToString ();
         num = num / 16;
      }
   }
   return String.Concat (result.Reverse ());
}