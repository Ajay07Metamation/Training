using static System.Console;

var integralList = new List<int> ();
var fractionalList = new List<int> ();
Write ("Enter a Number : ");
string decimalNum = ReadLine () ?? "";
if (decimal.TryParse (decimalNum, out decimal Num)) {
   string[] decimalArr = decimalNum.Split ('.');
   Write ("The Integral part is : ");
   GetIntArrFromInt (decimalArr);
   if (decimalNum.Contains (".")) {
      Write ("The Fractional part is : ");
      GetFracArrFromFrac (decimalArr);
   } else WriteLine ("No Fractional Part");
} else WriteLine ("Enter Valid Number");

void GetIntArrFromInt (string[] decimalArr) {
   int.TryParse (decimalArr[0], out int integralNum);
   while (integralNum != 0) {
      integralList.Add (integralNum % 10);
      integralNum /= 10;
   }
   integralList.Reverse ();
   integralList.ForEach (x => Write (x + " "));
   WriteLine ();
}

void GetFracArrFromFrac (string[] decimalArr) {
   int.TryParse (decimalArr[1], out int fractionalNum);
   while (fractionalNum != 0) {
      fractionalList.Add (fractionalNum % 10);
      fractionalNum /= 10;
   }
   fractionalList.Reverse ();
   fractionalList.ForEach (x => Write (x + " "));
}
