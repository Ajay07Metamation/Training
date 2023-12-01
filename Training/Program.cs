// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Double.Parse
// Create a class MyDouble and implement MyDouble.Parse method 
// ----------------------------------------------------------------------------------------

namespace Training {
   using static System.Console;

   #region Program ----------------------------------------------------------------------------------------
   internal class Program {
      public static void Main (string[] args) {
         //Array containing diiferent possibile representation of double precision floating point number
         string[] doubleNumberArray = {"123.45","-678.901","1.2e3","-3.4e-5","0.00789","4.56E7","9.01234e-12",
                                      "+2.345e6","-7.8E9","  45.678  ","  -0.123  ","  6.789e+4  ","  -5.6E-7  " };
         foreach (var number in doubleNumberArray)
            WriteLine (MyDouble.Parse (number));
      }
   }
   #endregion

   #region Class MyDouble ---------------------------------------------------------------------
   /// <summary>Class mDouble - Represents a double precision floating point number</summary>
   class MyDouble {

      #region Implementation ----------------------------------------
      /// <summary>Parse a given valid string into double precision floating point number</summary>
      /// <param name="number">The string to be parsed into double</param>
      /// <returns>Returns a double precision floating point number</returns>
      /// <exception cref="FormatException">Throws exception if the string provided is not in correct format</exception>
      public static double Parse (string number) {
         number = number.Trim ().ToLower ();
         double result = 0, fraction = 0.0, exp = 0, factor = 0.1;
         double sign = 1, expSign = 1;
         int process = 1;
         int expindex = number.IndexOf ('e');

         // Checks if the string is in incorrect format and throws exception
         if (string.IsNullOrWhiteSpace (number) || number.EndsWith ('+') || number.EndsWith ('-') || number.StartsWith ('e') || number.EndsWith ('e'))
            throw new FormatException ($"The input string '{number}' was not in a correct format.");
         for (int i = 0; i < number.Length; i++) {
            char ch = number[i];
            // To get sign of the number 
            if (process == 1 && (ch == '+' || ch == '-' || char.IsDigit (ch))) {
               sign = ch == '-' ? -1 : 1;
               if (char.IsDigit (ch)) i--;
               process = 2;
            }
            // To evaluate the integral part of the number
            else if (process == 2) {
               if (char.IsDigit (ch)) result = result * 10 + (ch - '0');
               else if (ch == '.') process = 3;
               else if (ch == 'e') process = 4;
               else throw new FormatException ($"The input string '{number}' was not in a correct format.");
            }
            // To evaluate the fraction part of the number
            else if (process == 3) {
               if (char.IsDigit (ch)) {
                  fraction += factor * (ch - '0');
                  factor *= 0.1;
               } else if (ch == 'e') process = 4;
               else throw new FormatException ($"The input string '{number}' was not in a correct format.");
            }
            // To get the sign of exponent and evaluate the exponential part of the number
            else {
               if (ch == '+' || ch == '-' || char.IsDigit (ch)) {
                  expSign = number[expindex + 1] == '-' ? -1 : 1;
                  if (char.IsDigit (ch)) exp = exp * 10 + (ch - '0');
               } else throw new FormatException ($"The input string '{number}' was not in a correct format.");
            }
         }
         result = sign * ((result + fraction) * (exp == 0 ? 1 : Math.Pow (10, exp * expSign)));
         return result;
      }
      #endregion
   }
   #endregion
}