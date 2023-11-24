// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Eight Queens
// To print all valid solutions or 12 unique solutions of eight queens problem
// ----------------------------------------------------------------------------------------

using System.Text;
using static System.Console;

#region Program ----------------------------------------------------------------------------------------
internal class Program {
   public static void Main (string[] args) {
      Console.WriteLine (" Print \n 1. All Solutions \n 2. Unique Solutions");
      var choice = ReadKey ().Key;
      if (choice == ConsoleKey.D1) {
         EightQueens (0);
         PrintSolution ();
      } else if (choice == ConsoleKey.D2) {
         EightQueens (0, true);
         PrintSolution ();
      } else
         WriteLine ("Enter valid input");
   }

   #region Private data ------------------------------------------
   //Array to store the position of Queens
   static int[] sPosition = new int[8];
   //List to store the possible solutions 
   static List<int[]> sSolutions = new ();
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>Method to get all valid solutions of eight queens using backtracking</summary>
   /// <param name="r">Row of the chess board where queen is to placed</param>
   /// <param name="unique">To store the choice of required type of solution</param>
   static void EightQueens (int r, bool unique = false) {
      for (sPosition[r] = 0; sPosition[r] < 8; sPosition[r]++) {
         if (!IsSafe (r)) continue;
         if (r == 7) {
            if (unique == true && IsUniqueSolution (sPosition.ToArray ())) return;
            sSolutions.Add (sPosition.ToArray ());
         } else EightQueens (r + 1, unique);
      }
   }

   /// <summary>Method to get position of the queen</summary>
   /// <param name="r">Row of the chess board</param>
   /// <returns>Return true if safe and false if not safe</returns>
   static bool IsSafe (int r) {
      for (int i = 0; i < r; i++) {
         int x = r - i, y = Math.Abs (sPosition[r] - sPosition[i]);
         if (y == 0 || x - y == 0) return false;
      }
      return true;
   }

   /// <summary>Method to check whether the solution obtained is unique</summary>
   /// <param name="position">The array to be checked</param>
   /// <returns>Returns true if the solution is not unique and false if unique</returns>
   static bool IsUniqueSolution (int[] position) {
      for (int i = 0; i < 4; i++) {
         position = Rotate (position);
         if (sSolutions.Any (s => s.SequenceEqual (position) || s.SequenceEqual (Mirror (position)))) return true;
      }
      return false;
   }

   /// <summary>Method to rotate the given array</summary>
   /// <param name="position">The array to be rotated</param>
   /// <returns>Returns the rotated array</returns>
   static int[] Rotate (int[] position) {
      int[] rotated = new int[8];
      for (int i = 0; i < 8; i++)
         rotated[position[i]] = 7 - i;
      return rotated;
   }

   /// <summary>Method to mirror the given array</summary>
   /// <param name="position">The array to be mirrored</param>
   /// <returns>Returns the mirrored array</returns>
   static int[] Mirror (int[] position) => position.Select (p => 7 - p).ToArray ();

   /// <summary>Method to print the solutions</summary>
   static void PrintSolution () {
      OutputEncoding = new UnicodeEncoding ();
      for (int i = 0; i < sSolutions.Count; i++) {
         WriteLine ($"\nSolution {i + 1} :");
         WriteLine ("┏" + String.Concat (Enumerable.Repeat ("━━━┳", 7)) + "━━━┓");
         for (int r = 0; r < 8; r++) {
            for (int c = 0; c <= 8; c++)
               Write ($"{(sSolutions[i][r] == c ? "┃ ♕ " : "┃   ")}");
            WriteLine ("\n" + (r < 7 ? ("┣" + String.Concat (Enumerable.Repeat ("━━━┫", 8)))
                                     : ("┗" + String.Concat (Enumerable.Repeat ("━━━┻", 7)) + "━━━┛")));
         }
      }
   }
   #endregion
}
#endregion