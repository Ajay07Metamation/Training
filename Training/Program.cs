using static System.Console;
Write ("Enter a string : ");
var word = (ReadLine () ?? "").ToLower ().Replace (" ", "") ;
var revword = "";
for(int i = word.Length-1;i>=0;i--)
   revword += word[i];
if (Enumerable.SequenceEqual (word, revword)) WriteLine ("It is a Palindrome");
else WriteLine ("It is not a palindrome");