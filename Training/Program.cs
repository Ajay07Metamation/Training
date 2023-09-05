//Program to get Nth Armstrong Number
using static System.Console;
internal class Program {
   private static void Main (string[] args) {
      if (args.Length == 1 && int.TryParse (args[0], out int index) && index > 0 && index <= 25)
         PrintNthArmstrong (index);
      else WriteLine ("Enter a Valid Index between 1 and 25 ");
   }

   static void PrintNthArmstrong (int index) {
      int count = 0, num = 0;
      int res = 0;
      while (count < index) {
         num++;
         res = 0;
         int check = num;
         int exp = num.ToString ().Length;
         while (check > 0) {
            int power = 1;
            for (int i = 0; i < exp; i++)
               power *= check % 10;
            res += power;
            check /= 10;
         }
         if (res == num) count++;
      }
      WriteLine ($"The {index}th Armstrong Number : {res}");
   }
}