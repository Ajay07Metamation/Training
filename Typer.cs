namespace PSI.Ops;
using static Token.E;
using static NType;


// An expression evaluator, implementing using the visitor pattern
class ExprTyper : Visitor<NType> {
   public ExprTyper (Dictionary<string, NType> symbols) => mSymbols = symbols;
   Dictionary<string, NType> mSymbols;
   public override NType Visit (NLiteral literal) =>
      literal.Type = literal.Value.Kind switch {
         INTEGER => Int,
         REAL => Real,
         BOOLEAN => Boolean,
         STRING => String,
         CHAR => Char,
         _ => Error
      };

   public override NType Visit (NIdentifier identifier) =>
      identifier.Type = mSymbols[identifier.Name.Text];

   public override NType Visit (NUnary unary) => unary.Type = unary.Expr.Accept (this);

   public override NType Visit (NBinary binary) {
      NType a = binary.Left.Accept (this), b = binary.Right.Accept (this);
      return binary.Type = (binary.Op.Kind, a, b) switch {
         (ADD or SUB or MUL or DIV, Int or Real, Int or Real) when a == b => a,
         (ADD or SUB or MUL or DIV, Int, Real) => Real,
         (ADD or SUB or MUL or DIV, Real, Int) => Real,
         (LT or LEQ or GT or GEQ, Int or Real, Int or Real) => Boolean,
         (EQ or NEQ, Int or Real, Int or Real) => Boolean,
         _ => Error
      };
   }
}