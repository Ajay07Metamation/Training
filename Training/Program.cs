// Tables
using static System.Console;
Write ("Till which tables do you want to print : ");
if (int.TryParse (ReadLine () ?? "", out int count)) {
   for (int i = 1; i <= count; i++) {
      for (int j = 1; j <= 10; j++)
         WriteLine ($"{i} * {j,2} = {i * j,-1}");
      WriteLine ();
   }
} else WriteLine ("Enter a valid Number");