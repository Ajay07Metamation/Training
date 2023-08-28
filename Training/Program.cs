//Reverse num and check for pallindrome
Console.Write ("Enter a Number : ");
if (int.TryParse (Console.ReadLine (), out int num)) {
   int orig = num;
   int rev = 0;
   while (num != 0) {
      rev = (rev * 10) + num % 10;
      num = num / 10;
   }
   Console.WriteLine ("It is " + (orig == rev ? "a Palindrome" : "not a Palindrome"));
} else Console.WriteLine ("Enter valid Number");