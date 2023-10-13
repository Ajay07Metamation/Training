// Chess Board Program
using System.Text;
using static System.Console;

OutputEncoding = new UnicodeEncoding ();

// Array containing White and Black coins
string[] white = new[] { "\u2656", "\u2658", "\u2657", "\u2654", "\u2655", "\u2657", "\u2658", "\u2656", "\u2659" };
string[] black = new[] { "\u265C", "\u265E", "\u265D", "\u265B", "\u265A", "\u265D", "\u265E", "\u265C", "\u265F" };
WriteLine ("\u250F" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u2533", 7)) +
                   "\u2501\u2501\u2501\u2501\u2501\u2513");
HorizontalVerticalLines ('V');
Write ("\u2503");
PrintCoins (white);
WriteLine ();
HorizontalVerticalLines ('H');
Write ("\u2503");
Write (String.Concat (Enumerable.Repeat ($"  {white[8]}  \u2503", 8)));
WriteLine ();
for (int i = 0; i < 5; i++) {
   HorizontalVerticalLines ('V');
   HorizontalVerticalLines ('H');
   HorizontalVerticalLines ('V');
}
Write ("\u2503");
Write (String.Concat (Enumerable.Repeat ($"  {black[8]}  \u2503", 8)));
WriteLine ();
HorizontalVerticalLines ('H');
HorizontalVerticalLines ('V');
Write ("\u2503");
PrintCoins (black);
WriteLine ();
WriteLine ("\u2517" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u253B", 7)) +
           "\u2501\u2501\u2501\u2501\u2501\u251B");


/// <summary>Method to print the coins</summary>
/// <param name="piece">Indicates the colour of coins</param>
void PrintCoins (string[] piece) {
   for (int i = 0; i < 8; i++)
      Write ($"  {piece[i]}  \u2503");
}

/// <summary>Print Horizontal and vertical lines for grid</summary>
/// <param name="code">Horizontal (H) or vetrical (v) Grid</param>
void HorizontalVerticalLines (char code) => WriteLine (code == 'H' ? "\u2523" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u252b", 8)) :
                                            String.Concat (Enumerable.Repeat ("\u2503     ", 9)));


