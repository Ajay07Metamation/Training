// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Unary operator
// Implement unary operator in expression evaluator
// ----------------------------------------------------------------------------------------
namespace Eval;
using static System.Console;

#region Program ----------------------------------------------------------------------------------------
internal class Program {
   private static void Main (string[] args) {
      Evaluator eval = new ();
      // Infinite loop for evaluating expressions
      for (; ; ) {
         Write (">");
         string input = ReadLine () ?? "".Trim ();
         if (input == "") break;
         // Try catch statements for printing the result and exceptions
         try {
            double result = eval.Evaluate (input);
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine (Math.Round (result, 10));
         } catch (Exception e) {
            ForegroundColor = ConsoleColor.Red;
            WriteLine (e.Message);
         }
         ResetColor ();
      }
   }
}
#endregion