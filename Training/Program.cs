using static System.Console;

Write ("Enter the character array : ");
var chArr = ReadLine ().ToCharArray ();
Write ("Enter the Special Character : ");
var splCh = char.ToLower (ReadKey ().KeyChar);
Write ("\nEnter the order of sorting (D)escending or (O) for Optional Parameter (Ascending) : ");
var sortOrder = char.ToLower (ReadKey ().KeyChar);

if (chArr.Length > 0 && chArr.All (char.IsLetter) && char.IsLetter (splCh) && (sortOrder == 'd' || sortOrder == 'o')) {
   WriteLine ("\nThe Final Array is : ");
   var result = sortOrder == 'o' ? GetSortArray (chArr, splCh) : GetSortArray (chArr, splCh, sort: sortOrder);
   foreach (var ch in result) { Write (ch + " "); }
} else WriteLine ("\nEnter Valid Input");
char[] GetSortArray (in char[] charr, char splch, char sort = 'a') {
   var SortArr = charr.Where (c => c != splch);
   SortArr = (sort == 'a') ? SortArr.Order () : SortArr.OrderDescending ();
   return charr.Contains (splch) ? SortArr.Concat (charr.Where (c => c == splch)).ToArray () : SortArr.ToArray ();
}




