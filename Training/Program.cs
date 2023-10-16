// Chess Board Program
using System.Text;
using static System.Console;

OutputEncoding = new UnicodeEncoding ();

// Array containing White coins
string[] white = new[] { "\u2656", "\u2658", "\u2657", "\u2654",
                         "\u2655", "\u2657", "\u2658", "\u2656", "\u2659" };
// Array containing black coins
string[] black = new[] { "\u265C", "\u265E", "\u265D", "\u265B", "\u265A",
                         "\u265D", "\u265E", "\u265C", "\u265F" };
WriteLine ("\u250F" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u2533", 7)) +
                   "\u2501\u2501\u2501\u2501\u2501\u2513");
DrawLines ('V');
PrintCoins (white, 'M');
DrawLines ('H');
PrintCoins (white, 'P');
for (int i = 0; i < 5; i++) {
    DrawLines ('V');
    DrawLines ('H');
    DrawLines ('V');
}
PrintCoins (black, 'P');
DrawLines ('H');
DrawLines ('V');
PrintCoins (black, 'M');
WriteLine ("\u2517" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u253B", 7)) +
           "\u2501\u2501\u2501\u2501\u2501\u251B");

// To print the coins</summary>
// name="pieces" Indicates the colour of coins
// name="type" Main coins (M) or Pawn (P)
void PrintCoins (string[] pieces, char type) {
    Write ("\u2503");
    if (type == 'M')
        foreach (var piece in pieces)
            Write ($"  {piece}  \u2503");
    if (type == 'P')
        Write (String.Concat (Enumerable.Repeat ($"  {pieces[8]}  \u2503", 8)));
    WriteLine ();
}

// Print Horizontal and vertical lines for grid
// name = line" Horizontal (H) or vetical (v) Grid
void DrawLines (char line) => WriteLine (line == 'H' ? "\u2523" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u252b", 8))
                                                     : String.Concat (Enumerable.Repeat ("\u2503     ", 9)));