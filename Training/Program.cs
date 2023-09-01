//Program to get Nth Armstrong Number
using static System.Console;
internal class Program {
   private static void Main (string[] args) {
      if (args.Length == 1 && int.TryParse (args[0], out int index) && index > 0 && index <= 25)
         GetNthArmstrong (index);
      else WriteLine ("Enter a Valid Index between 1 and 25 ");
   }
   static void GetNthArmstrong (int index) {
      int count = 0, num = 0;
      double res = 0;
      while (count < index) {
         num++;
         res = 0;
         int check = num;
         int exp = num.ToString ().Length;
         while (check > 0) {
            res += Math.Pow (check % 10, exp);
            check /= 10;
         }
         if (res == num) count++;
      }
      WriteLine ($"The {index}th Armstrong Number : {res}");
   }
}