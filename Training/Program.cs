//This program is Number Guessing game!!
var game = ConsoleKey.Y;
while (game == ConsoleKey.Y) {
   int random = new Random ().Next (1, 101); //Variable to store random number generated
   Console.Write ("Guess the number between 1 to 100: ");
   for (int tries = 1; ; tries++) {
      string value = Console.ReadLine ();
      if (!int.TryParse (value, out int guess) ||  guess <1 || guess >100) { // Getting valid integer input from user
         Console.WriteLine ("Enter valid integer within the range"); continue;
      }
      if (guess == random) {  // check the guess
         Console.WriteLine ($"Your guess is correct. You took {tries} attempts."); break;
      }
      string result = (guess > random) ? "Your guess is too high" : "Your guess is too low";
      Console.WriteLine (result);
   }
   Console.Write ("Do you want to play again (Y)es / (N)o :"); // Asking user whether he wants to play again
   game = Console.ReadKey ().Key;
   Console.WriteLine ();
}