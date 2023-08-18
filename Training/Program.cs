// Tables
Console.Write ("Till which tables do you want to print : ");
int count = int.Parse (Console.ReadLine ());
for (int i = 1; i <= count; i++) {
   for (int j = 1; j <= 10; j++) {
      Console.WriteLine ($"{i}*{j} = {i * j}");
   }
   Console.WriteLine ();
}