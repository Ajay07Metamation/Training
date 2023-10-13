// Chess Board Program
using System.Text;
using static System.Console;

OutputEncoding = new UnicodeEncoding ();

// Array containing White and Black coins
string[] white = new[] { "\u2656", "\u2658", "\u2657", "\u2654", "\u2655", "\u2657", "\u2658", "\u2656", "\u2659" };
string[] black = new[] { "\u265C", "\u265E", "\u265D", "\u265B", "\u265A", "\u265D", "\u265E", "\u265C", "\u265F" };
WriteLine ("\u250F" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u2533", 7)) +
                   "\u2501\u2501\u2501\u2501\u2501\u2513");
DrawLines ('V');
PrintCoins (white, 'M');
WriteLine ();
DrawLines ('H');
PrintCoins (white, 'P');
WriteLine ();
for (int i = 0; i < 5; i++) {
   DrawLines ('V');
   DrawLines ('H');
   DrawLines ('V');
}
PrintCoins (black, 'P');
WriteLine ();
DrawLines ('H');
DrawLines ('V');
PrintCoins (black, 'M');
WriteLine ();
WriteLine ("\u2517" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u253B", 7)) +
           "\u2501\u2501\u2501\u2501\u2501\u251B");

/// <summary>Method to print the coins</summary>
/// <param name="piece">Indicates the colour of coins</param>
/// <param name="type">Main coins (M) or Pawn (P)</param>
void PrintCoins (string[] pieces, char type) {
   Write ("\u2503");
   if (type == 'M')
      for (int i = 0; i < 8; i++)
         Write ($"  {pieces[i]}  \u2503");
   if (type == 'P')
      Write (String.Concat (Enumerable.Repeat ($"  {pieces[8]}  \u2503", 8)));
}

/// <summary>Print Horizontal and vertical lines for grid</summary>
/// <param name="line">Horizontal (H) or vetrical (v) Grid</param>
void DrawLines (char line) => WriteLine (line == 'H' ? "\u2523" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u252b", 8))
                                                     : String.Concat (Enumerable.Repeat ("\u2503     ", 9)));