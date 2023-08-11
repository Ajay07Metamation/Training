using System.Text;
using static System.Console;
OutputEncoding = new UnicodeEncoding ();
string[] white = new[] { "\u2656", "\u2658", "\u2657", "\u2654", "\u2655", "\u2657", "\u2658", "\u2656", "\u2659" };
string[] black = new[] { "\u265C", "\u265E", "\u265D", "\u265B", "\u265A", "\u265D", "\u265E", "\u265C", "\u265F" };
WriteLine ("\u250F" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u2533", 7)) +
                   "\u2501\u2501\u2501\u2501\u2501\u2513");
WriteLine (String.Concat (Enumerable.Repeat ("\u2503     ", 9)));
Write ("\u2503");
for (int i = 0; i < 8; i++) {
   Write ($"  {white[i]}  \u2503");
}
WriteLine ();
WriteLine ("\u2523" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u252b", 8)));
Write ("\u2503");
for (int i = 0; i < 8; i++)
   Write ($"  {white[8]}  \u2503");
WriteLine ();
for (int i = 0; i < 5; i++) {
   WriteLine (String.Concat (Enumerable.Repeat ("\u2503     ", 9)));
   WriteLine ("\u2523" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u252b", 8)));
   WriteLine (String.Concat (Enumerable.Repeat ("\u2503     ", 9)));
}
Write ("\u2503");
for (int i = 0; i < 8; i++)
   Write ($"  {black[8]}  \u2503");
WriteLine ();
WriteLine ("\u2523" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u252b", 8)));
WriteLine (String.Concat (Enumerable.Repeat ("\u2503     ", 9)));
Write ("\u2503");
for (int i = 0; i < 8; i++) {
   Write ($"  {black[i]}  \u2503");
}
WriteLine ();
WriteLine ("\u2517" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u253B", 7)) +
           "\u2501\u2501\u2501\u2501\u2501\u251B");