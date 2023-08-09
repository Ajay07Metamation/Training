using System.Numerics;
using static System.Console;
var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter a Number : ");
   if (int.TryParse (Console.ReadLine (), out int num)) {
      Write ("Do you want to convert it into (W)ords or (R)oman Numbers ?  ");
      switch (Console.ReadKey ().Key) {
         case ConsoleKey.W:
            WriteLine ();
            NumtoWords (num);
            break;
         case ConsoleKey.R:
            WriteLine ();
            NumtoRoman (num);
            break;
         default:
            WriteLine ("Enter a valid key");
            break;
      }
      WriteLine ("\nDo you want to convert again");
      key = ReadKey ().Key;
      WriteLine ();
   }
}

void NumtoWords (int num) {
   Dictionary<int, string> numtoword = new () { { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
    { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "Ten" },
    {11,"Eleven" },{12,"Twelve" },{13,"Thirteen" },{14,"Fourteen" },{15,"Fifteen" },
    {16,"Sixteen" },{17,"Seventeen" },{18,"Eighteen" },{19,"Nineteen" },{20,"Twenty" },
    {30,"Thirty" },{40,"Fourty" },{50,"Fifty" },{60,"Sixty"},{70,"Seventy" },{80,"Eighty" },{90,"Ninety" } };
   string result = "";
   int quo = 0;
   if (num == 0) WriteLine ("Zero");
   while (num != 0) {
      if (Convert.ToString (num).Length == 1) {
         result += numtoword[num];
         num = num / 10;
      }
      if (Convert.ToString (num).Length == 2) {
         if (Convert.ToString (num).Length == 2 && num > 20) {
            result += numtoword[num - (num % 10)] + " " + numtoword[num % 10];
            num = num / 10;
            break;
         } else {
            result += numtoword[num];
            num = num / 10;
            break;
         }
      }
      if (Convert.ToString (num).Length == 3) {
         quo = num / 100;
         result += numtoword[quo] + " Hundred and ";
         num = num % 100;
      }
      if (Convert.ToString (num).Length == 4 || Convert.ToString (num).Length == 5) {
         quo = num / 1000;
         result += (Convert.ToString (quo).Length == 2 && quo > 20 ? numtoword[quo - (quo % 10)] + " " + numtoword[quo % 10] : numtoword[quo]) + " Thousand ";
         num = num % 1000;
      }
      if (Convert.ToString (num).Length == 6 || Convert.ToString (num).Length == 7) {
         quo = num / 100000;
         result += (Convert.ToString (quo).Length == 2 && quo > 20 ? numtoword[quo - (quo % 10)] + " " + numtoword[quo % 10] : numtoword[quo]) + " Lakhs ";
         num = num % 100000;
      }
      if (Convert.ToString (num).Length == 8 || Convert.ToString (num).Length == 9) {
         quo = num / 10000000;
         result += (Convert.ToString (quo).Length == 2 && quo > 20 ? numtoword[quo - (quo % 10)] + " " + numtoword[quo % 10] : numtoword[quo]) + " Crores ";
         num = num % 10000000;
      }

   }
   Write ($"{result}");
}
void NumtoRoman (int num) {
   Dictionary<int, string> numtoRoman = new () { { 1, "I" }, { 2, "II" }, { 3, "III" }, { 4, "IV" }, { 5, "V" },
    { 6, "VI" }, { 7, "VII" }, { 8, "VIII" }, { 9, "IX" }, { 10, "X" },{40,"XL"},{50,"L" },{90,"XC"},{100,"C"},{ 400,"CD"},{500,"D"},{900,"CM"},{1000,"M"} };
   string result = "";
   int quo = 0;
   while (num > 0) {
      if (Convert.ToString (num).Length == 4 && num <= 1000) {
         result += numtoRoman[num];
         break;
      }
      if (Convert.ToString (num).Length == 3) {
         quo = num / 100;
         if (num > 500 && num < 900)
            result += numtoRoman[500] + string.Concat (Enumerable.Repeat (numtoRoman[100], quo - 5));
         else if ((num - (num % 100)) == 400 || (num - (num % 100)) == 500 || (num - (num % 100)) == 900)
            result += numtoRoman[(num - (num % 100))];
         else if (num < 400)
            result += String.Concat (Enumerable.Repeat (numtoRoman[100], quo));
         else
            break;
         num = num % 100;
      }
      if (Convert.ToString (num).Length == 2) {
         quo = num / 10;
         if (num > 50 && num < 90)
            result += numtoRoman[50] + Enumerable.Repeat (numtoRoman[10], quo - 5);
         else if ((num - (num % 10)) == 40 || (num - (num % 10)) == 50 || (num - (num % 10)) == 90) {
            result += numtoRoman[num - (num % 10)];
            if (num % 10 != 0) {
               result += numtoRoman[num % 10];
               break;
            }
         } else {
            result += string.Concat (Enumerable.Repeat (numtoRoman[10], quo));
            num = num % 10;
         }
      }
      if (Convert.ToString (num).Length == 1) {
         result += numtoRoman[num];
         num = num / 10;
      }
   }
   Write (result);
}