//Diamond Pattern
Console.Write ("Enter the height of the pattern : ");
int height = int.Parse (Console.ReadLine ());
for (int i = 0; i <= height; i++) {
   for (int blank = 0; blank < height - i; blank++)
      Console.Write (" ");
   for (int j = 1; j <= (2 * i) - 1; j++) {
      Console.Write ("*");
   }
   Console.WriteLine ();
}
for (int i = height - 1; i > 0; i--) {
   for (int blank = 0; blank < height - i; blank++)
      Console.Write (" ");
   for (int j = 1; j <= (2 * i) - 1; j++) {
      Console.Write ("*");
   }
   Console.WriteLine ();
}