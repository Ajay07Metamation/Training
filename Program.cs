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
      string input = ReadLine ().Trim ().ToUpper ();
      WriteLine (input);
      if (!string.IsNullOrEmpty (input)) {
         (char drive, string folder, string filename, string extension) = MyFile.Parser (input);
         WriteLine ($"Drive : {drive} " +
                    $"\nFolders : {folder} " +
                    $"\nFile name : {filename} " +
                    $"\nExtension : {extension}");
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
      Action todo;
      Action none = () => { };
      char drive = ' ';
      string folders = " ";
      string fname = " ";
      string extn = "";
      State s = A;
      foreach (var part in fileName + "~") {
         (s, todo) = (s, part) switch {
            (A, >= 'A' and <= 'Z') => (B, () => drive = part),
            (B, ':') => (C, none),
            (C or E, '\\') => (D, () => folders += " "),
            (D or E, >= 'A' and <= 'Z') => (E, () => folders += part),
            (E, '.') => (F, () => {
               fname = folders[folders.LastIndexOf (" ")..];
               folders = folders[..folders.LastIndexOf (" ")];
            }
            ),
            (F or G, >= 'A' and <= 'Z') => (G, () => extn += part),
            (G, '~') => (I, none),
            _ => (Z, none)
         };
         todo ();
      }
      if (s == I) return (drive, folders, fname, extn);
      throw new Exception ($"Invalid file format {fileName}");
   }
}
#endregion

// State enumeration represents a set of states for file parsing
// see file://C:/ProgramData/statediagram.jpg
enum State { A, B, C, D, E, F, G, I, Z };