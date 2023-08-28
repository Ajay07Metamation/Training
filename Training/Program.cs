// Tables
using static System.Console;
Console.Write ("Till which tables do you want to print : ");
if (int.TryParse (Console.ReadLine () ?? "", out int count)) {
   for (int i = 1; i <= count; i++) {
      for (int j = 1; j <= 10; j++)
         Console.WriteLine ($"{i,2} * {j,2} = {i * j,-1}");
      Console.WriteLine ();
   }
} else Console.WriteLine ("Enter a valid Number");