//MyStack<T>
//To create a Stack using array as underlying structure 

//Test Case

TStack<char> ajay = new ();
Console.WriteLine (ajay.IsEmpty);
ajay.Push ('a');
ajay.Push ('b');
ajay.Push ('c');
ajay.Push ('d');
ajay.Push ('e');
ajay.Push ('f');
ajay.Push ('g');
ajay.Push ('h');
ajay.Display ();
Console.WriteLine (ajay.IsEmpty);
Console.WriteLine (ajay.Pop ());
ajay.Display ();
Console.WriteLine (ajay.Peek ());
ajay.Display ();

/// <summary>MyStack class for creating a stack using array as underlying structure </summary>
class TStack<T> {
   // Private variable for creating array and for getting count of elements
   private T[] arrayStack;
   private int count;

   //Constructor initialising the array and count variable
   public TStack () {
      arrayStack = new T[4];
      count = 0;
   }

   /// <summary>Property to get capacity of the list </summary>
   public int Capacity => arrayStack.Length;

   /// <summary>Property to get count of elements in a list </summary>
   public int Count => count;

   /// <summary>Method to add/push elements into the stack </summary>
   /// <param name="a">It is the element to be pushed into the stack</param>
   public void Push (T a) {
      if (count == Capacity) Array.Resize (ref arrayStack, Capacity * 2);
      arrayStack[count] = a;
      count++;
   }
   /// <summary>Method to Delete/Pop the last inserted element in the stack</summary>
   /// <returns>Returns the popped Element</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Pop () {
      if (IsEmpty) throw new InvalidOperationException ();
      var poppedItem = arrayStack[count - 1];
      Array.Clear (arrayStack, count - 1, 1);
      count--;
      Console.Write ("Popped element : ");
      return poppedItem;
   }

   /// <summary> Method to peek the last element inserted at the top of the stack </summary>
   /// <returns>return the top element in the stack</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ();
      Console.Write ("Peek element : ");
      return arrayStack[count - 1];
   }

   /// <summary> Method to print the stack </summary>
   public void Display () {
      Console.Write ("Stack : ");
      for (int i = 0; i < count; i++) { Console.Write (arrayStack[i] + " "); }
      Console.WriteLine ();
   }

   /// <summary>Property to check the whether the list is empty or not</summary>
   public bool IsEmpty => count == 0;
}