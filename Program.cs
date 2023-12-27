// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// File Parser
// Implement a file parser using state machine
// ----------------------------------------------------------------------------------------

using static State;
using static System.Console;

#region Program ----------------------------------------------------------------------------------------
internal class Program {
   private static void Main (string[] args) {
      string[] fNames = { "C:\\Users\\Username\\Documents\\file.txt","D:\\home\\user\\data\\document.pdf",
                          "D:\\Projects\\images\\photo.jpg","E:\\ProgramFiles\\Application\\app.exe",
                          "E:\\gallery\\screenshot\\photo.jpg","E\\Work\\WorkGit\\Training.exe",
                          "C:Program\\Data\\Readme.txt","D:\\program\\Readme,txt",
                          "C:Program\\Data\\Readme"};
      foreach (var f in fNames) {
         (char drive, string folder, string file, string extn) = MyFile.Parser (f.ToUpper ());
         WriteLine ($"File Path : {f}");
         if (drive is ' ') WriteLine ("Invalid file format\n");
         else WriteLine ($"Drive : {drive} " +
                         $"\nFolder : {folder}" +
                         $"\nFile name : {file} " +
                         $"\nExtension : {extn}\n");
      }
   }
}
#endregion

#region Class MyFile ---------------------------------------------------------------------
class MyFile {

   /// <summary>Parse a file using mealy state machine</summary>
   /// <param name="fileName">Input file name</param>
   /// <returns>Returns a tuple of drive,folders,file name and extension of the given file</returns>
   /// <exception cref="Exception">Throws an exception if the file name is not in correct format</exception>
   public static (char drive, string folder, string file, string extn) Parser (string fileName) {
      Action todo, none = () => { };
      char drive = ' ';
      string folders = "", fname = "", extn = "";
      int sIndex;
      State s = A;
      foreach (var part in fileName + "~") {
         (s, todo) = (s, part) switch {
            (A, >= 'A' and <= 'Z') => (B, () => drive = part),
            (B, ':') => (C, none),
            (E or C, '\\') => (D, () => folders += "\\"),
            (D or E, >= 'A' and <= 'Z') => (E, () => folders += part),
            (E, '.') => (F, () => {
               sIndex = folders.LastIndexOf ("\\");
               fname = folders[(sIndex + 1)..];
               folders = folders[1..sIndex];
            }
            ),
            (F or G, >= 'A' and <= 'Z') => (G, () => extn += part),
            (G, '~') => (I, none),
            _ => (Z, none)
         };
         todo ();
      }
      if (s == I) return (drive, folders, fname, extn);
      return (' ', "", "", "");
   }
}
#endregion

// State enumeration represents a set of states for file parsing
// see file://C:/ProgramData/statediagram.jpg
enum State { A, B, C, D, E, F, G, I, Z };