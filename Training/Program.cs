// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// MyStack<T>
// Create a stack (MyStack<T>) with underlying structure as array using property,methods and private variables
// ----------------------------------------------------------------------------------------
using static System.Console;

#region Program ----------------------------------------------------------------------
internal class Program {
   private static void Main (string[] args) {
      // Test case
      MyStack<char> stack = new ();
      WriteLine (stack.IsEmpty);
      stack.Push ('a');
      stack.Push ('b');
      stack.Push ('c');
      stack.Push ('d');
      stack.Push ('e');
      stack.Push ('f');
      stack.Display ();
      WriteLine ("The popped element is : " + stack.Pop ());
      stack.Display ();
      stack.Push ('e');
      stack.Push ('f');
      stack.Push ('g');
      stack.Push ('h');
      stack.Display ();
      WriteLine (stack.IsEmpty);
      WriteLine ("The popped element is : " + stack.Pop ());
      stack.Display ();
      WriteLine ("The peek element is : " + stack.Peek ());
      stack.Display ();
   }
}
#endregion

#region Class MyStack ---------------------------------------------------------------------
/// <summary>Represents a last in first out principle (LIFO) collection of instances of same specified type</summary>
class MyStack<T> {

   #region Constructor -------------------------------------------
   // Constructor initialising the array and count variable
   public MyStack () {
      mArrayStack = new T[4];
      mCount = 0;
   }
   #endregion

   #region Property --------------------------------------------
   /// <summary>Returns the capacity of the stack</summary>
   public int Capacity => mArrayStack.Length;

   /// <summary>Returns the number of elements in the stack</summary>
   public int Count => mCount;

   /// <summary>Returns true or false after checking the list is empty or not</summary>
   public bool IsEmpty => mCount == 0;
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>Push elements into the stack </summary>
   /// <param name="a">Element to be pushed into the stack</param>
   public void Push (T a) {
      if (mCount == Capacity) Array.Resize (ref mArrayStack, Capacity * 2);
      mArrayStack[mCount] = a;
      mCount++;
   }

   /// <summary>Pop the last inserted element in the stack</summary>
   /// <returns>Returns the popped element</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Pop () {
      if (IsEmpty) throw new InvalidOperationException ();
      var poppedItem = mArrayStack[mCount - 1];
      Array.Clear (mArrayStack, mCount - 1, 1);
      mCount--;
      return poppedItem;
   }

   /// <summary>Returns the element at the top of the stack withour removing it</summary>
   /// <returns>Returns the top element in the stack</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ();
      return mArrayStack[mCount - 1];
   }

   /// <summary>Print the stack</summary>
   public void Display () {
      Write ("Stack : ");
      for (int i = 0; i < mCount; i++) Write (mArrayStack[i] + " ");
      WriteLine ();
   }
   #endregion

   #region Private Data ------------------------------------------
   // Private variable for creating array and for getting count of elements
   T[] mArrayStack;
   int mCount;
   #endregion
}
#endregion

