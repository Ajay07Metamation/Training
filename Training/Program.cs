using static System.Console;
Write ("Enter a string : ");
var word = ReadLine ().ToLower ().Replace (" ", "");
var orig = word.ToCharArray ();
var rev = word.ToCharArray ();
Array.Reverse (rev);
if (Enumerable.SequenceEqual (orig, rev)) WriteLine ("It is a Pallindrome");
else WriteLine ("It is not a pallindrome");