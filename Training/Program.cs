﻿// MyStack<T>
// Implementation of stack using array
// Test case
using static System.Console;

MyStack<char> stack = new ();
WriteLine (stack.IsEmpty);
stack.Push ('a');
stack.Push ('b');
stack.Push ('c');
stack.Push ('d');
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

/// <summary>Represents a variable size last in first out collection of instances of same specified type</summary>
class MyStack<T> {

   // Constructor initialising the array and count variable
   public MyStack () {
      mArrayStack = new T[4];
      mCount = 0;
   }

   /// <summary>Returns the capacity of the stack</summary>
   public int Capacity => mArrayStack.Length;

   /// <summary>Returns the number of elements in the stack</summary>
   public int Count => mCount;

   /// <summary>Push elements into the stack </summary>
   /// <param name="a">It is the element to be pushed into the stack</param>
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

   /// <summary>Print the last element inserted at the top of the stack</summary>
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

   /// <summary>Returns true or false after checking the list is empty or not</summary>
   public bool IsEmpty => mCount == 0;

   // Private variable for creating array and for getting count of elements
   T[] mArrayStack;
   int mCount;
}