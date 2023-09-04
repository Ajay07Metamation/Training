using static System.Console;
var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter a Number : ");
   if (int.TryParse (ReadLine (), out int num) && num >= 0) {
      Write ("Do you want to convert it into (W)ords or (R)oman Numbers ?  ");
      switch (ReadKey ().Key) {
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
      WriteLine ("\nDo you want to convert again (Y)es or (N)o ? ");
      key = ReadKey ().Key;
      WriteLine ();
   } else WriteLine ("Enter Valid Number");
}
void NumtoWords (int num) {
   Dictionary<int, string> numtoword = new () { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" },
    { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" },{11,"Eleven" },{12,"Twelve" },{13,"Thirteen"}
   ,{14,"Fourteen" },{15,"Fifteen" },{16,"Sixteen" },{17,"Seventeen" },{18,"Eighteen" },{19,"Nineteen" },{20,"Twenty" },
    {30,"Thirty" },{40,"Fourty" },{50,"Fifty" },{60,"Sixty"},{70,"Seventy" },{80,"Eighty" },{90,"Ninety" } };
   string result = "", end = "";
   if (num == 0) WriteLine ("Zero");
   while (num != 0) {
      string numstr = num.ToString ();
      int numlength = numstr.Length;
      int divident = 0;
      if (numlength == 1) {
         result += numtoword[num];
         break;
      } else if (numlength == 2)
         divident = 1;
      else if (numlength == 3) {
         divident = 100;
         end = " Hundred " + (num % 100 == 0 ? "" : "and ");
      } else if (numlength == 4 || numlength == 5) {
         divident = 1000;
         end = " Thousand ";
      } else if (numlength == 6 || numlength == 7) {
         divident = 100000;
         end = " Lakhs ";
      } else if (numlength == 8 || numlength == 9) {
         divident = 10000000;
         end = " Crores ";
      }
      int quo = num / divident;
      result += (quo.ToString ().Length == 2 && quo > 20 ? numtoword[quo - (quo % 10)] +
                 " " + numtoword[quo % 10] : numtoword[quo]) + (numlength != 2 ? end : "");
      if (numlength == 2) break;
      num %= divident;
   }
   Write ($"{result}");
}
void NumtoRoman (int num) {
   string[] roman = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
   int[] number = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
   string result = "";
   if (num == 0) WriteLine ("No Roman Number representation for 0");
   while (num > 0)
      for (int i = number.Length - 1; i >= 0; i--)
         if (num >= number[i]) {
            result += roman[i];
            num = num - number[i];
            i++;
         }
   Write (result);
}