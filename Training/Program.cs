using static System.Console;

var integralList = new List<int> ();
var fractionalList = new List<int> ();
Write ("Enter a Number : ");
string decimalNum = ReadLine () ?? "";
if (decimal.TryParse (decimalNum, out decimal Num)) {
   string[] decimalArr = decimalNum.Split ('.');
   Write ("The Integral part is : ");
   GetIntListFromInt (decimalArr);
   if (decimalNum.Contains (".")) {
      Write ("The Fractional part is : ");
      GetFracListFromFrac (decimalArr);
   } else WriteLine ("No Fractional Part");
} else WriteLine ("Enter Valid Number");

void GetIntListFromInt (string[] decimalArr) {
   int.TryParse (decimalArr[0], out int integralNum);
   if (integralNum == 0) WriteLine (decimalArr[0]);
   while (integralNum != 0) {
      integralList.Add (integralNum % 10);
      integralNum /= 10;
   }
   integralList.Reverse ();
   integralList.ForEach (x => Write (x + " "));
   WriteLine ();
}

void GetFracListFromFrac (string[] decimalArr) {
   int.TryParse (decimalArr[1], out int fractionalNum);
   if (fractionalNum == 0) WriteLine (decimalArr[1]);
   while (fractionalNum != 0) {
      fractionalList.Add (fractionalNum % 10);
      fractionalNum /= 10;
   }
   fractionalList.Reverse ();
   fractionalList.ForEach (x => Write (x + "  "));
}
