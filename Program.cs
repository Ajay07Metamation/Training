// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Wordle Game
// Implement a wordle game
// ----------------------------------------------------------------------------------------

using System.Text;
using static System.Console;
internal class Program {
   private static void Main (string[] args) {
      OutputEncoding = new UnicodeEncoding ();
      Wordle w = new Wordle ();
      w.Run ();
   }
}

#region Class Wordle ---------------------------------------------------------------------
class Wordle {

   #region Implementation ----------------------------------------
   /// <summary>Run the wordle game</summary>
   public void Run () {
      CursorVisible = false;
      Clear ();
      SelectWord ();
      InitializeBoard ();
      DisplayBoard ();
      while (!GameOver) {
         ConsoleKey Key = ReadKey (true).Key;
         UpdateGameState (Key);
         DisplayBoard ();
         if (j == 0) check = "";
      }
      ExitGame ();
   }

   /// <summary>Update the game states after each entry</summary>
   /// <param name="Key">Letter entered by the user</param>
   void UpdateGameState (ConsoleKey Key) {
      var key = (char)Key;
      if (char.IsLetter (key)) {
         check += key.ToString ().ToUpper ();
         game[i, j] = check[j++];
         if (j <= 4) game[i, j] = '◌';
         if (j == 5) {
            DisplayBoard ();
            if (Submit (check)) {
               for (int index = 0; index < 5; index++)
                  colours[index] = check[index] == secWord[index]
                                 ? ConsoleColor.Green
                                 : secWord.Contains (check[index])
                                 && check[..index].Count (x => x == check[index]) < 1
                                 ? ConsoleColor.Blue : ConsoleColor.DarkGray;
               alph += check;
               DisplayBoard ();
               if (i < 5) {
                  game[++i, 0] = '◌';
                  j = 0;
               }
            }
         }
      } else if (Key is ConsoleKey.Backspace or ConsoleKey.LeftArrow) {
         check = check[..(j - 1)];
         game[i, j--] = '·';
         game[i, j] = '◌';
      }
   }

   /// <summary>Displays game status message for the user</summary>
   void DispMsg () {
      string msg = check == secWord ? "Hurray correct answer. Winner !!"
                                    : (i == 5) ? $"The answer is {secWord}!! Better luck next time!!"
                                    : $"Try again! {5 - i} attempts remaining";
      GameOver = check == secWord || (check != secWord && i == 5) ? true : false;
      SetCursorPosition ((WindowWidth - msg.Length) / 2, CursorTop + 1);
      WriteLine (msg);
      return;
   }

   /// <summary>Selects the secret word</summary>
   void SelectWord () {
      dict = File.ReadAllLines ("C:/Users/nehrujiaj/dict-5.txt");
      puzzles = File.ReadAllLines ("C:/Users/nehrujiaj/puzzle-5.txt");
      Random r = new Random ();
      secWord = puzzles[r.Next (5)];
   }

   /// <summary>Displays the board</summary>
   void DisplayBoard () {
      int x;
      SetCursor (15);
      (x, _) = GetCursorPosition ();
      // Displays the dots and letters
      for (int row = i; row <= 5; row++) {
         for (int col = 0; col < 5; col++) {
            if (row == i && alph.Length == 5 * (i + 1))
               ForegroundColor = colours[col];
            Write (" " + game[row, col] + " ");
            ResetColor ();
         }
         WriteLine ();
         CursorLeft = x;
      }
      CursorLeft = x - 8;
      // Displays the separator line
      WriteLine (string.Concat (Enumerable.Repeat ("_", 31)) + "\n");
      if (i == 0 || alph.Length == 5 * (i + 1)) {
         int k = 0;
         CursorLeft = x - 10;
         // Displays the virtual keyboard
         for (char ch = 'A'; ch <= 'Z'; ch++) {
            ForegroundColor = alph.Contains (ch) ? (check.Contains (ch) && secWord.Contains (ch)
                                                 ? check.IndexOf (ch) == secWord.IndexOf (ch)
                                                 ? ConsoleColor.Green : ConsoleColor.Blue : ConsoleColor.DarkGray)
                                                 : ConsoleColor.White;
            Write ("  " + ch + "  ");
            ResetColor ();
            k++;
            if (k % 7 == 0) {
               WriteLine ();
               CursorLeft = x - 10;
            }
         }
      }
      WriteLine ();
      if (alph.Length == 5 * (i + 1)) DispMsg ();
   }

   /// <summary>Initialises the board with dots</summary>
   void InitializeBoard () {
      for (int i = 0; i <= 5; i++)
         for (int j = 0; j < 5; j++)
            game[i, j] = (i == 0 && j == 0) ? '◌' : '·';
   }

   /// <summary>Submit the word entered and check if it is valid</summary>
   /// <param name="check">Word entered by the user</param>
   /// <returns>Returns true if the word is valid else returns false</returns>
   bool Submit (string check) {
      var control = ReadKey (true).Key;
      if (control == ConsoleKey.Enter) {
         if (!Array.Exists (dict, element => element.Equals (check))) {
            for (int j = 0; j < 5; j++)
               game[i, j] = j == 0 ? '◌' : '·';
            j = 0;
            return false;
         }
         return true;
      } else if (control is ConsoleKey.Backspace or ConsoleKey.LeftArrow) {
         check = check[..(j - 1)];
         game[i, --j] = '◌';
      }
      return false;
   }

   /// <summary>Exits the game</summary>
   void ExitGame () {
      CursorTop = 14;
      WriteLine ("Enter any key to exit");
      ReadKey (true);
   }

   /// <summary>Sets the cursor at the required positon</summary>
   /// <param name="l">position of cursor</param>
   void SetCursor (int l) => SetCursorPosition ((WindowWidth - l) / 2, i);
   #endregion

   #region Private Data ------------------------------------------
   char[,] game = new char[6, 5];
   string[] puzzles, dict;
   string secWord = "", check = "", alph = "";
   int i, j;
   bool GameOver;
   ConsoleColor[] colours = new ConsoleColor[5];
   #endregion
}
#endregion