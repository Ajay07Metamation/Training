// Tic-Tac-Toe Game

using System.Text;
using static System.Console;
Encoding unicode = new UnicodeEncoding ();
var entry = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
WriteLine ("Tic-Tac-Toe game");
DispBoard ();
for (int i = 0; i < entry.Length; i++) entry[i] = ' ';
for (int tries = 0; tries < 9; tries++) {
   WriteLine ("Enter the position from 0 to 8");
   var key = ReadLine ();
   if (int.TryParse (key, out int pos)) {
      if (tries % 2 == 0) {
         WriteLine ("Player 1 : X");
         entry[pos] = 'X';
      } else {
         WriteLine ("Player 2 : Y");
         entry[pos] = 'O';
      }
      DispBoard ();
   } else {
      WriteLine ("Enter a valid position");
      tries--;
   }
   if (tries >= 4) {
      (bool game, int player) = IsGameOver ();
      if (game) {
         WriteLine ($"The winner is Player {player}");
         break;
      }
   }
}
if (IsGameOver ().game == false)
   WriteLine ("Match Draw");

void DispBoard () {
   for (int i = 0; i < 9; i++) {
      Write (entry[i] + "\u2502");
      if ((i + 1) % 3 == 0) {
         WriteLine ();
         Write (string.Concat (Enumerable.Repeat ("─╉", 3)) + "\n");
      }
   }
}

(bool game, int player) IsGameOver () {
   int player = 0;
   for (int i = 0; i < 9; i += 3) {
      if (entry[i] != ' ') {
         if (entry[i] == entry[i + 1] && entry[i + 1] == entry[i + 2]) {
            player = entry[i] == 'X' ? 1 : 2;
            return (true, player);
         } else if (entry[i] == entry[i + 3] && entry[i + 3] == entry[i + 6]) {
            player = entry[i] == 'X' ? 1 : 2;
            return (true, player);
         }
      }
   }
   for (int i = 0; i < 9; i += 6) {
      if (entry[i] != ' ') {
         if (entry[i] == entry[i + 4] && entry[i + 4] == entry[i + 8]) {
            player = entry[i] == 'X' ? 1 : 2;
            return (true, player);
         }
         if (i == 6 && entry[i] == entry[i - 2] && entry[i - 2] == entry[i - 4]) {
            player = entry[i] == 'X' ? 1 : 2;
            return (true, player);
         }
      }
   }
   return (false, player);
}