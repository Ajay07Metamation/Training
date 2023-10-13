using static System.Console;

var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter a Number : ");
   if (int.TryParse (ReadLine (), out int num) && num >= 0) {
      Write ("Do you want to convert it into (W)ords or (R)oman Numbers ?  ");
      if (ReadKey ().Key == ConsoleKey.W) {
         WriteLine ();
         NumToWords (num);
      } else if (ReadKey ().Key == ConsoleKey.R) {
         WriteLine ();
         NumToRoman (num);
      } else
         WriteLine ("Enter a valid key");
      WriteLine ("\nDo you want to convert again (Y)es or (N)o ? ");
      key = ReadKey ().Key;
      WriteLine ();
   } else WriteLine ("Enter Valid Number");
}

void NumToWords (int num) {
   Dictionary<int, string> numtoword = new () { { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" },
    { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" },{11,"Eleven" },{12,"Twelve" },{13,"Thirteen"}
   ,{14,"Fourteen" },{15,"Fifteen" },{16,"Sixteen" },{17,"Seventeen" },{18,"Eighteen" },{19,"Nineteen" },{20,"Twenty" },
    {30,"Thirty" },{40,"Fourty" },{50,"Fifty" },{60,"Sixty"},{70,"Seventy" },{80,"Eighty" },{90,"Ninety" } };
   Dictionary<int, string> endword = new () { { 3, " Hundred " }, { 4, " Thousand " }, { 5, " Thousand " }, { 6, " Lakhs " }, { 7, " Lakhs " }, { 8, " Crores " }, { 9, " Crores " } };
   string result = "", end = "";
   if (num == 0) WriteLine ("Zero");
   while (num != 0) {
      string numstr = num.ToString ();
      int numlength = numstr.Length;
      int divident = 0;
      if (numlength == 1 || (numlength == 2 && num <= 20)) {
         result += numtoword[num];
         break;
      } else if (numlength == 2 && num > 20)
         divident = 1;
      else
         divident = numlength == 3 || numlength % 2 == 0 ? (int)Math.Pow (10, numlength - 1) : (int)Math.Pow (10, numlength - 2);
      int quo = num / divident;
      result += (quo.ToString ().Length == 2 && quo > 20 ? numtoword[quo - (quo % 10)] +
                 " " + numtoword[quo % 10] : numtoword[quo]) + (numlength >= 3 ? endword[numlength] : "") + (numlength == 3 ? "and " : "");
      num %= divident;
   }
   Write ($"{result}");
}

void NumToRoman (int num) {
   string[] roman = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
   int[] number = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
   string result = "";
   if (num == 0) {
      WriteLine ("No Roman Number representation for 0");
      return;
   }
   while (num > 0) {
      for (int i = number.Length - 1; i >= 0; i--)
         if (num >= number[i]) {
            result += roman[i];
            num -= number[i];
            i++;
         }
   }
   Write (result);
}