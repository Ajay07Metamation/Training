//This program is Number Guessing game!!
var game = ConsoleKey.Y;
while (game == ConsoleKey.Y) {
   //Variable to store random number generated
   int secretnum = new Random ().Next (1, 101);
   Console.Write ("Guess the number between 1 to 100: ");
   for (int tries = 1; ; tries++) {
      string value = Console.ReadLine ();
      if (!int.TryParse (value, out int guess) || guess < 1 || guess > 100) {
         // Getting valid integer input from user
         Console.WriteLine ("Enter valid integer within the range"); continue;
      }
      if (guess == secretnum) {  // check the guess
         Console.WriteLine ($"Your guess is correct. You took {tries} attempts."); break;
      }
      Console.WriteLine ($"Your guess is too {(guess > secretnum ? "high" : "low")}");
   }
   // Asking user whether he wants to play again
   Console.Write ("Do you want to play again (Y)es / (N)o :");
   game = Console.ReadKey ().Key;
   Console.WriteLine ();
}