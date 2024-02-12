namespace Training {

   using System.Reflection;
   using static System.Console;
   using static System.ConsoleColor;

   internal class Program {
      private static void Main (string[] args) {
      }
   }
   public class Wordle {
      // Interface ---------------------------------
      // Public interface routine to run the game
      public Wordle () {
         mHalfWinWidth = WindowWidth / 2;
         GetDict ();
      }

      // Additional constructor for testing
      public Wordle (StreamWriter writer) {
         mWriter = writer;
         GetDict ();
         mHalfWinWidth = 0;
      }

      public void Run () {
         ClearScreen ();
         DisplayBoard ();
         while (!GameOver) {
            ConsoleKey key = ReadKey (true).Key;
            UpdateGameState (key);
            DisplayBoard ();
         }
         PrintResult ();
      }
      public string SecretWord {
         get => mSecWord;
         set => mSecWord = value;
      }

      // Check if the game is over
      public bool GameOver => mSucceeded || mFailed;
      bool mSucceeded;     // User succeeded in guessing the word
      bool mFailed;        // User failed to guess the word
      public bool IsTesting {
         get => mIsTest;
         set => mIsTest = value;
      }
      bool mIsTest = false;

      // Implementation ----------------------------
      // Set up suitable colors and clear the screen
      void ClearScreen () {
         BackgroundColor = Black;
         Clear ();
         GRIDX = mHalfWinWidth - 7;
         KBDX = mHalfWinWidth - 16;
         CursorVisible = false;
         OutputEncoding = System.Text.Encoding.Unicode;
      }

      // Select a word at random 
      public void GetDict () =>
         mDict = LoadStrings ("dict-5.txt");


      // Display the current state of the board
      public void DisplayBoard () {
         // First, display the game state
         for (int y = 0; y < 6; y++) {
            for (int x = 0; x < 5; x++) {
               char ch = mGuess[y][x];
               ConsoleColor color = Gray;
               if (y < mY) {
                  color = DarkGray;
                  if (SecretWord[x] == ch) color = Green;
                  else if (SecretWord.Contains (ch)) color = Blue;
               }
               if (ch == ' ') ch = '\u00b7';
               if (x == mX && y == mY) ch = '\u25cc';
               Put (x * 3 + GRIDX, y * 2 + GRIDY, color, ch);
            }
            mWriter.WriteLine ();
         }


         // Then, add the 'keyboard hint display' - this shows the keys 
         // that we've already used along with some color codes
         if (!IsTesting) Put (KBDX, KBDY - 2, DarkGray, new string ('_', 31));
         string recent = mY == 0 ? "     " : mGuess[mY - 1];
         for (int i = 0; i < 26; i++) {
            int x = i % 7, y = i / 7;
            char ch = (char)('A' + i);
            ConsoleColor color = White;                                 // Not yet used
            if (mGuess.Take (mY).Any (a => a.Contains (ch))) color = DarkGray;    // Already used
            if (recent.Contains (ch) && SecretWord.Contains (ch)) {
               color = Blue;     // Used in an incorrect position in the recent guess
               int a = recent.IndexOf (ch), b = SecretWord.IndexOf (ch);
               if (a == b) color = Green;
            }
            Put (x * 5 + KBDX, y * 1 + KBDY, color, ch);
            if ((i + 1) % 7 == 0) mWriter.WriteLine ();
         }

         // If the user has recently typed in a word that is not in the
         // dictionary, display that
         string error = (mBadWord != null) ? $"{mBadWord} is not a word" : new string (' ', 20);
         mWriter.WriteLine ();
         Put (mHalfWinWidth - 10, RESULTY + 1, Yellow, error);
      }
      int GRIDX = 3, GRIDY = 1;
      int KBDX = 3, KBDY = 14;

      // Update the game-state based on the key the user pressed
      public void UpdateGameState (ConsoleKey info) {
         mBadWord = null;
         if (info is ConsoleKey.LeftArrow or ConsoleKey.Backspace && mX > 0) {
            // First, handle left / backspace to erase the last character
            Set (--mX, mY, ' ');
            return;
         }
         if (info is ConsoleKey.Enter && mX == 5) {
            // Handle the Enter key to submit a new word
            // First, if the current word is not in the dictionar, don't 
            // accept it
            if (!mDict.Contains (mGuess[mY])) {
               mBadWord = mGuess[mY];
               return;
            }
            mX = 0;
            if (mGuess[mY++] == SecretWord) { mSucceeded = true; } else if (mY == 6) mFailed = true;
            return;
         }
         char ch = char.ToUpper ((char)info);
         if (ch is >= 'A' and <= 'Z' && mX < 5) {
            // Handle letter keys to input a new character
            Set (mX++, mY, ch);
            return;
         }

         // Set a particular character of a particular guess string
         void Set (int x, int y, char ch) {
            var array = mGuess[y].ToCharArray ();
            array[x] = ch;
            mGuess[y] = new string (array);
         }
      }

      public void PutToFile (object data, ConsoleColor color) {
         data = color switch {
            Green => $"{{{data}}}",
            Blue => $"[{data}]",
            DarkGray => $"({data})",
            _ => $" {data} ",
         };
         mWriter.Write (data);
      }

      // Print the final result
      public void PrintResult () {
         if (!IsTesting) Put (KBDX, RESULTY, DarkGray, new string ('_', 31));
         mWriter.WriteLine ();
         if (mSucceeded)
            Put (mHalfWinWidth - 15, RESULTY + 2, Green, $"You found the word in {mY} tries");
         else
            Put (mHalfWinWidth - 13, RESULTY + 2, Yellow, $"Sorry - the word was {SecretWord}");
         if (!IsTesting) {
            Put (mHalfWinWidth - 11, RESULTY + 4, White, "Press any key to quit");
            ReadKey ();
            WriteLine ();
         }
      }
      int RESULTY = 18;

      void Put (int x, int y, ConsoleColor color, object data) {
         if (IsTesting) {
            PutToFile (data, color);
            return;
         }
         CursorLeft = x; CursorTop = y; ForegroundColor = color;
         Write (data);
         ResetColor ();
      }

      // Helper routine to load strings from a assembly-manifest resource file
      string[] LoadStrings (string file) {
         using var stream = Assembly.GetExecutingAssembly ().GetManifestResourceStream ($"Training.data.{file}");
         using var reader = new StreamReader (stream);
         return reader.ReadToEnd ().Split ('\n');
      }

      // State -------------------------------------
      string[] mDict;   // The dictionary of all possible words
      string mSecWord;     // The word the computer has selected
      string[] mGuess = { "     ", "     ", "     ", "     ", "     ", "     " };   // The 6 guesses of the user
      int mY = 0;       // The word we're typing into now
      int mX = 0;       // The letter within that word we're typing in
      int mHalfWinWidth;
      string mBadWord;  // This is set if the user types in a word not in the dictionary
      StreamWriter mWriter;
   }
}