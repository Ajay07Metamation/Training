// MyStack<T>
// To create a Stack using array as underlying structure 

// Test Case
using static System.Console;

MyStack<char> stack = new ();
WriteLine (stack.IsEmpty);
stack.Push ('a');
stack.Push ('b');
stack.Push ('c');
stack.Push ('d');
stack.Push ('e');
stack.Push ('f');
stack.Push ('g');
stack.Push ('h');
stack.Display ();
WriteLine (stack.IsEmpty);
WriteLine (stack.Pop ());
stack.Display ();
WriteLine (stack.Peek ());
stack.Display ();

/// <summary>MyStack class for creating a stack using array as underlying structure </summary>
class MyStack<T> {
   // Private variable for creating array and for getting count of elements
   private T[] mArrayStack;
   private int mCount;

   // Constructor initialising the array and count variable
   public MyStack () {
      mArrayStack = new T[4];
      mCount = 0;
   }

   /// <summary>Property to get capacity of the list </summary>
   public int Capacity => mArrayStack.Length;

   /// <summary>Property to get count of elements in a list </summary>
   public int Count => mCount;

   /// <summary>Push elements into the stack </summary>
   /// <param name="a">It is the element to be pushed into the stack</param>
   public void Push (T a) {
      if (mCount == Capacity) Array.Resize (ref mArrayStack, Capacity * 2);
      mArrayStack[mCount] = a;
      mCount++;
   }
   /// <summary>Pop the last inserted element in the stack</summary>
   /// <returns>Returns the popped Element</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Pop () {
      if (IsEmpty) throw new InvalidOperationException ();
      var poppedItem = mArrayStack[mCount - 1];
      Array.Clear (mArrayStack, mCount - 1, 1);
      mCount--;
      Write ("Popped element : ");
      return poppedItem;
   }

   /// <summary>Print the last element inserted at the top of the stack</summary>
   /// <returns>return the top element in the stack</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ();
      Write ("Peek element : ");
      return mArrayStack[mCount - 1];
   }

   /// <summary>Print the stack</summary>
   public void Display () {
      Write ("Stack : ");
      for (int i = 0; i < mCount; i++) { Write (mArrayStack[i] + " "); }
      WriteLine ();
   }

   /// <summary>Property to check the whether the list is empty or not</summary>
   public bool IsEmpty => mCount == 0;
}