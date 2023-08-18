//Reverse num and check for pallindrome
Console.Write ("Enter a Number : ");
string num = Console.ReadLine ();
Console.WriteLine ($"Original Number  : {num}");
var ori = num.ToCharArray ();
var rev = num.ToCharArray ();
Array.Reverse (rev);
Console.Write ("Reversed String : ");
Console.WriteLine (rev);
if (Enumerable.SequenceEqual (ori, rev)) Console.WriteLine ("It is a Pallindrome");
else Console.WriteLine ("It is not a pallindrome");
