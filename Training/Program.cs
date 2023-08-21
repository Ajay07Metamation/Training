//Reverse num and check for pallindrome
Console.Write ("Enter a Number : ");
int.TryParse(Console.ReadLine (),out int num);
int orig = num;
int rev = 0;
while (num != 0) {
   rev = (rev * 10) + num % 10;
   num = num / 10;
}
Console.WriteLine (rev);
if (orig ==rev) Console.WriteLine ("It is a Pallindrome");
else Console.WriteLine ("It is not a pallindrome");
