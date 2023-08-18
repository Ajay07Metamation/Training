//Pascal's Triangle
Console.Write ("Enter number of rows : ");
int.TryParse (Console.ReadLine (), out int row);
int val = 1;
Console.WriteLine ("Pascal's triangle");
for (int i = 0; i < row; i++) {
   for (int blank = 1; blank <= row - i; blank++)
      Console.Write (" ");
   for (int j = 0; j <= i; j++) {
      if (j == 0 || i == 0 || j == i)
         val = 1;
      else
         val = val * (i - j + 1) / j;
      Console.Write (val + " ");
   }
   Console.WriteLine ();
}