namespace Eval;

/// <summary>Class Token - To classify the expression into different tokens</summary>
class Token { }

#region Class TNumber ---------------------------------------------------------------------
/// <summary>Represents a numeric token in an expression derived from base class Token</summary>
class TNumber : Token {

   /// <summary>Implements a  virtual property 'Value' that must be implemented by derived classes</summary>
   public virtual double Value { get; }
}

#region Class TLiteral ---------------------------------------------------------------------
/// <summary>Represents a literal token derived from the base class TNumber</summary>
class TLiterals : TNumber {

   /// <summary>Initialise the value of the literal</summary>
   /// <param name="f">Value of the literal</param>
   public TLiterals (double f) => mValue = f;
   public override string ToString () => $"Literal {mValue}";

   /// <summary>Gets the value of the literal</summary>
   public override double Value => mValue;

   // Stores the value of the literal
   readonly double mValue;
}
#endregion

#region Class Tvariable ---------------------------------------------------------------------
/// <summary>Represents a variable token derived from base class TNumber</summary>
class TVariable : TNumber {

   /// <summary>Initialize the variable name and evaluator class reference</summary>
   /// <param name="eval">Reference to evaluator</param>
   /// <param name="var">Variable name</param>
   public TVariable (Evaluator eval, string var) { mVar = var; mEval = eval; }

   /// <summary>Gets the value of thevariable</summary>
   public override double Value => mEval.GetVarValue (Var);
   public override string ToString () => $"Variable {mVar}";

   /// <summary>Gets the name of the variable</summary>
   public string Var => mVar;

   // Stores the variable name and evaluator reference
   readonly string mVar;
   readonly Evaluator mEval;
}
#endregion
#endregion

#region Class TOperator ---------------------------------------------------------------------
/// <summary>Represents a operator token derived from base class Token</summary>
class TOperator : Token {

   /// <summary>Implements a  virtual property 'Priority' that must be implemented by derived classes</summary>
   public virtual int Priority { get; }

   /// <summary>Get and set the final priority of the TOperator token</summary>
   public int FinalPriority { get; set; }
}

#region Class TOpFunction ---------------------------------------------------------------------
/// <summary>Represents a function token derived from base class TOperator</summary>
class TOpFunction : TOperator {
   public TOpFunction (string func) => mFunc = func;

   /// <summary>Gets the priority of functional operator</summary>
   public override int Priority => 4;

   /// <summary>Applies a corresponding mathematical function to a given input value a</summary>
   /// <param name="a">Number to be evaluated using the fucntion</param>
   /// <returns>Returns a double value</returns>
   /// <exception cref="EvalException">Throws an exception if the operator is unknown</exception>
   public double Apply (double a, Exception evalException)
       => Func switch {
          "sin" => Math.Sin (D2R (a)),
          "cos" => Math.Cos (D2R (a)),
          "tan" => Math.Tan (D2R (a)),
          "asin" => R2D (Math.Asin (a)),
          "acos" => R2D (Math.Acos (a)),
          "atan" => R2D (Math.Atan (a)),
          "sqrt" => Math.Sqrt (a),
          "log" => Math.Log (a),
          "exp" => Math.Exp (a),
          _ => throw new EvalException ("Unknown Operator")
       };
   /// <summary>Convert radians to degrees</summary>
   /// <param name="f">Value to be converted</param>
   /// <returns>Returns a double value</returns>
   double R2D (double f) => f * 180 / Math.PI;

   /// <summary>Convert degrees to radians</summary>
   /// <param name="f">Value to be converted</param>
   /// <returns>Returns a double value</returns>
   double D2R (double f) => f * Math.PI / 180;
   public override string ToString () => $"Function {mFunc}";

   /// <summary>Gets the name of the function</summary>
   public string Func => mFunc;

   // Stores the name of the fucntion
   readonly string mFunc;
}
#endregion

#region Class TOpBinary ---------------------------------------------------------------------

/// <summary>Represents a binary token derived from the base class TOperator</summary>
class TOpBinary : TOperator {

   /// <summary>Initialise the binary operator</summary>
   /// <param name="op">Binary operator</param>
   public TOpBinary (char op) => mOp = op;

   /// <summary>Gets the priority of binary operators</summary>
   public override int Priority
           => Op switch {
              '+' or '-' => 1,
              '*' or '/' => 2,
              '^' => 3,
              _ => throw new EvalException ("Unknown Operator"),
           };

   public override string ToString () => $"Operator {mOp}";

   /// <summary>Applies a binary mathematical operation to the given 2 input value</summary>
   /// <param name="a">The first operand of the binary operation</param>
   /// <param name="b">The second operand of the binary operation</param>
   /// <returns>Returns the result of the operation</returns>
   /// <exception cref="EvalException">Throws an exception if the operator is unknown</exception>
   public double Apply (double a, double b)
       => Op switch {
          '+' => a + b,
          '-' => a - b,
          '*' => a * b,
          '/' => a / b,
          '^' => Math.Pow (a, b),
          _ => throw new EvalException ("Unknown Operator"),
       };

   /// <summary>Get and set the operator</summary>
   public char Op {
      get { return mOp; }
      set { mOp = value; }
   }

   // Stores the operator
   char mOp;
}
#endregion

#region Class TOpUnary ---------------------------------------------------------------------
/// <summary>Represents a unary token derived from the base class TOperator</summary>
class TOpUnary : TOperator {

   /// <summary>Initialise the unary operator</summary>
   /// <param name="uop">Unary operator</param>
   public TOpUnary (char uop) => mUop = uop;

   /// <summary>Gets the priority of the unary operator</summary>
   public override int Priority => 4;

   /// <summary>Applies the unary mathematical operation to the given input value a</summary>
   /// <param name="a">The operand of the unary operation</param>
   /// <returns>Returns the result of the mathematical operation</returns>
   /// <exception cref="EvalException">Throws an exception if the operator is unknown</exception>
   public double Apply (double a)
       => Uop switch {
          '+' => a,
          '-' => -a,
          _ => throw new EvalException ("Unknown Operator"),
       };
   public override string ToString () => $"Unary Operator {mUop}";

   /// <summary>Gets the unary operator</summary>
   public char Uop => mUop;

   // Stores the unary operator
   readonly char mUop;

}
#endregion
#endregion

#region Class TPunctuation ---------------------------------------------------------------------
/// <summary>Represents a punctuation token derived from the base class Token</summary>
class TPunctuation : Token {

   /// <summary>Intialises the punctuation</summary>
   /// <param name="ch">Punctuation</param>
   public TPunctuation (char ch) => mPunc = ch;
   public override string ToString () => $"Punctuation {mPunc}";

   /// <summary>Gets the punctuation</summary>
   public char Punc => mPunc;

   // Stores the punctuation
   readonly char mPunc;
}
#endregion

/// <summary>Represents a end token</summary>
class TEnd : Token { }

#region Class TError ---------------------------------------------------------------------
/// <summary>Represents a error token derived from the base class Token</summary>
class TError : Token {
   /// <summary>Initialise the error msg</summary>
   /// <param name="msg">Error message</param>
   public TError (string msg) => mMessage = msg;
   public override string ToString () => $"Error : {mMessage}";

   /// <summary>Gets the error message</summary>
   public string Message => mMessage;

   // Stores the error message
   readonly string mMessage;
}
#endregion