int random = new Random ().Next (1, 101); //Variable to store random number generated
Console.Write ("Guess the number between 1 to 100: ");
for (int tries = 0; ; tries++) {
   int guess = ReadInt ();
   if (guess == random) { // check the guess
      Console.WriteLine ($"Your guess is correct. You took {tries} attempts."); break;
   } else if (guess > random)
      Console.WriteLine ("Your guess is too high");
   else
      Console.WriteLine ("Your guess is too low");
}
int ReadInt () { // To get valid input from user and convert to integer
   for (; ; ) {
      string value = Console.ReadLine ();
      if (int.TryParse (value, out int result)) return result;
   }
}