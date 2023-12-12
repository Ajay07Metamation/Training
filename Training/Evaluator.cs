namespace Eval;
#region Class EvalException ---------------------------------------------------------------------
/// <summary>EvalException class derived from base class Exception</summary>
class EvalException : Exception {

   /// <summary>Constructor to initialize the message in base class</summary>
   /// <param name="message">Error message</param>
   public EvalException (string message) : base (message) { }

}
#endregion

#region Class Evaluator ---------------------------------------------------------------------
/// <summary>class Evaluator - To evaluate the given expession </summary>
class Evaluator {
   #region Implementation ----------------------------------------

   /// <summary>Evaluate the tokens returned from tokenizer</summary>
   /// <param name="input">Expression to be evaluated</param>
   /// <returns>returns a double value after evaluating the expression</returns>
   /// <exception cref="EvalException">Throws an exception if the input string is of incorrent format</exception>
   public double Evaluate (string input) {
      Reset ();
      if (input == "CRASH") throw new EvalException ("Invalid entry");
      var tokenizer = new Tokenizer (this, input);
      List<Token> tokens = new ();
      for (; ; ) {
         var token = tokenizer.GetNext ();
         if (token is TEnd) break;
         tokens.Add (token);
      }
      TVariable var = null;
      if (tokens.Count > 1 && tokens[0] is TVariable tv && tokens[1] is TOpBinary bin && bin.Op == '=') {
         var = tv;
         tokens.RemoveRange (0, 2);
      }
      for (int i = 0; i < tokens.Count; i++) {
         if (tokens[i] is TOpBinary binary && binary.Op is '+' or '-' && tokens[i + 1] is TOpUnary unary) {
            binary.Op = binary.Op == unary.Uop ? '+' : '-';
            tokens.Remove (unary);
         }
         Process (tokens[i]);
      }
      while (mOperator.Count > 0)
         ApplyOperator ();
      if (mBasePriority != 0) Error ("Too many Punctuations");
      if (mOperator.Count > 0) Error ("Too many operators");
      if (mOperand.Count != 1) Error ("Too many operands");
      double f = mOperand.Pop ();
      if (var != null) mVariables[var.Var] = f;
      return f;
   }

   /// <summary>Evaluates the operands and operators in the stack</summary>
   void ApplyOperator () {
      var op = mOperator.Pop ();
      if (op is TOpBinary binary) {
         if (mOperand.Count < 2) Error ("Too few operands");
         double f1 = mOperand.Pop (), f2 = mOperand.Pop ();
         mOperand.Push (binary.Apply (f2, f1));
      }
      if (op is TOpUnary unary) {
         if (mOperand.Count < 1) Error ("Too few operands");
         double f = mOperand.Pop ();
         mOperand.Push (unary.Apply (f));
      }
      if (op is TOpFunction func) {
         if (mOperand.Count < 1) Error ("Too few operands");
         double f = mOperand.Pop ();
         mOperand.Push (func.Apply (f, new EvalException ("Unknown function")));
      }
   }

   /// <summary>Process the given token and updates it into respective stacks</summary>
   /// <param name="token"></param>
   /// <exception cref="NotImplementedException"></exception>
   void Process (Token token) {
      switch (token) {
         case TNumber num:
            mOperand.Push (num.Value);
            break;
         case TOperator op:
            op.FinalPriority = mBasePriority + op.Priority;
            while (!OkToPush (op))
               ApplyOperator ();
            mOperator.Push (op);
            break;
         case TPunctuation punc:
            if (punc.Punc is '(') mBasePriority += 10;
            else mBasePriority -= 10;
            break;
         default: throw new NotImplementedException ();
      }
   }
   /// <summary>Gets the value of the variable form the dictionary</summary>
   /// <param name="name">Name of the variable</param>
   /// <returns>Returns a double value corresponding to the variable</returns>
   /// <exception cref="EvalException">Throws an exception if variable is unknown</exception>
   public double GetVarValue (string name) {
      if (mVariables.TryGetValue (name, out double f)) return f;
      Error ($"Unknown Variable {name}");
      return 0;
   }
   /// <summary>Checks whether the operator can be pushed into the stack</summary>
   /// <param name="op">Operator to be checked</param>
   /// <returns>Returns true if it can be pushed else returns false </returns>
   bool OkToPush (TOperator op) {
      if (mOperator.Count == 0) return true;
      TOperator prev = mOperator.Peek ();
      return prev.FinalPriority <= op.FinalPriority;
   }

   /// <summary>Reset the state of expression evaluator by clearing the operand and operator stack and resetting basepriority</summary>
   void Reset () {
      mOperator.Clear ();
      mOperand.Clear ();
      mBasePriority = 0;
   }

   /// <summary>Throw new EvalException</summary>
   /// <param name="msg">Error message</param>
   /// <exception cref="EvalException"></exception>
   void Error (string msg) {
      throw new EvalException (msg);
   }
   #endregion
   #region Private data ------------------------------------------
   Dictionary<string, double> mVariables = new ();
   Stack<double> mOperand = new ();
   Stack<TOperator> mOperator = new ();
   int mBasePriority = 0;
   #endregion
}
#endregion