namespace PSI;

// An expression evaluator, implementing using the visitor pattern
class ExprGrapher : Visitor<int> {
   public ExprGrapher (string expression) => mExpression = expression;

   public override int Visit (NLiteral literal) {
      mSB.AppendLine ($"id{++mId}[{literal.Value.Text}  {literal.Type}]");
      return mId;
   }

   public override int Visit (NIdentifier identifier) {
      mSB.AppendLine ($"id{++mId}[{identifier.Name.Text}  {identifier.Type}]");
      return mId;
   }

   public override int Visit (NUnary unary) {
      int a = unary.Expr.Accept (this);
      mSB.AppendLine ($"id{++mId}([{unary.Op.Text}  {unary.Type}]); id{mId} --> id{a}");
      return mId;
   }

   public override int Visit (NBinary binary) {
      int a = binary.Left.Accept (this), b = binary.Right.Accept (this);
      mSB.AppendLine ($"id{++mId}([{binary.Op.Text}  {binary.Type}]); id{mId} --> id{a}; id{mId} --> id{b}");
      return mId;
   }
   public void SaveTo (string file) {
      string text = $$"""
         <!DOCTYPE html>
         <head><meta charset="utf-8"></head>
         <body>
           Graph of {{mExpression}}
           <pre class="mermaid">
             graph TD
             {{mSB}}
           </pre> 
           <script type="module">
             import mermaid from 'https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs';
             mermaid.initialize({ startOnLoad: true });
           </script>  
         </body>
         """;
      File.WriteAllText (file, text);
   }

   string mExpression = "";
   public StringBuilder mSB = new ();
   int mId;
}