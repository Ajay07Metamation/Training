using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eval;

#region Class Tokenizer ---------------------------------------------------------------------
class Tokenizer {

   #region Constructor -------------------------------------------
   /// <summary>Initialize reference of evaluator class and input text</summary>
   /// <param name="eval">Refernece of the evaluator class</param>
   /// <param name="input">Expression to be evaluated</param>
   public Tokenizer (Evaluator eval, string input) {
      mText = input; mN = 0; mEval = eval;
   }
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>Identifies the type of token</summary>
   /// <returns>Returns the type of token</returns>
   public Token GetNext () {
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is ' ') continue;
         if (ch is '+' or '-' or '*' or '/' or '^' or '=') return GetOperator ();
         if (ch is >= '0' and <= '9') return GetLiteral ();
         if (ch is '(' or ')') return new TPunctuation (ch);
         if (ch is >= 'a' and <= 'z') return GetVariable ();
         return new TError ("Unexpected character");
      }
      return new TEnd ();
   }

   /// <summary>Gets the literal token from the expression</summary>
   /// <returns>Returns a TLiteral token</returns>
   Token GetLiteral () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= '0' and <= '9') or '.') continue;
         mN--; break;
      }
      double number = double.Parse (mText.Substring (start, mN - start));
      return new TLiterals (number);
   }

   /// <summary>Gets the operator token from expression</summary>
   /// <returns>Returns a TOpUnary token if is a unary operator else returns TOpBinary token</returns>
   Token GetOperator () {
      int start = mN - 1;
      var ch = mText[start];
      if (ch is '+' or '-' && (start is 0 || mText[start - 1] is '+' or '-' or '*' or '/' or '(' or '=' or ' ')) return new TOpUnary (ch);
      //if (ch is '+' or '-' && mText[mN] is '+' or '-') {
      //    char newCh = ch == mText[mN] ? '+' : '-';
      //    mN++;
      //    return new TOpBinary (newCh);
      //}
      return new TOpBinary (ch);
   }

   /// <summary>Gets a variable token from the expression</summary>
   /// <returns>Returns a TOpFunction token if it is a function else returns a TVariable token</returns>
   Token GetVariable () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= 'a' and <= 'z') or (>= '0' and <= '9')) continue;
         mN--; break;
      }
      string variable = mText.Substring (start, mN - start);
      if (mFunctions.Contains (variable)) return new TOpFunction (variable);
      else return new TVariable (mEval, variable);
   }
   #endregion

   #region Private data ------------------------------------------
   readonly string mText;
   readonly Evaluator mEval;
   int mN;
   string[] mFunctions = { "sin", "cos", "tan", "asin", "acos", "atan", "sqrt", "log", "exp" };
   #endregion
}
#endregion