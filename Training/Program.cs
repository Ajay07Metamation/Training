// Program for checking Valid Password 
using static System.Console;
Write ("Enter your Password : ");
string pass = Console.ReadLine () ?? "";
WriteLine (valid (pass));
String valid (string s) {
   String result = "";
   String spl = "!@#$%^&*()-+";
   if (s.Length >= 6) {
      if (!s.Any (char.IsDigit)) result += "Password should contain atleast 1 numerical \n";
      if (!s.Any (char.IsUpper)) result += "Password should contain atleast 1 Upper case \n";
      if (!s.Any (char.IsLower)) result += "Password should contain atleast 1 Lower case \n";
      if (!s.Any (spl.Contains)) result += "Password should contain atleast 1 special character \n";
      if (result == "") result = "Your Password is Strong";
   } else result = "Password should contain atleast 6 characters";
   return result;
}