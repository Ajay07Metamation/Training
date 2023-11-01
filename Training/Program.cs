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
      TQueue<int> queue = new ();
      queue.Enqueue (1);
      queue.Enqueue (2);
      queue.Enqueue (3);
      queue.Enqueue (4);
      queue.Display ();
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      queue.Display ();
      queue.Enqueue (8);
      WriteLine ("The peek element is : " + queue.Peek ());
      queue.Display ();
      queue.Enqueue (9);
      queue.Enqueue (10);
      queue.Enqueue (11);
      queue.Enqueue (12);
      queue.Enqueue (13);
      queue.Enqueue (14);
      queue.Enqueue (15);
      queue.Display ();
      WriteLine ("The peek element is : " + queue.Peek ());
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      WriteLine ("The dequeued element is : " + queue.Dequeue ());
      queue.Enqueue (23);
      WriteLine ("The peek element is : " + queue.Peek ());
      queue.Display ();
   }
}
#endregion

#region Class MyStack ---------------------------------------------------------------------
/// <summary>Represent a first in first out principle collection of objects</summary>
class TQueue<T> {

   #region Constructor -------------------------------------------
   // Constructor for initializing the array and count
   public TQueue () {
      mArrayQueue = new T[4];
      mCount = 0;
      mFront = 0;
      mRear = -1;

   }
   #endregion

   #region Properties --------------------------------------------
   /// <summary>Returns the number of elements in the queue</summary>
   public int Count => mCount;

   /// <summary>Returns the capacity of the queue</summary>
   public int Capacity => mArrayQueue.Length;

   /// <summary>Returns true or false after checking the Queue is empty or not</summary>
   public bool IsEmpty => mCount == 0;
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>Add/Enqueue an element to the queue</summary>
   /// <param name="a">Element to be added</param>
   public void Enqueue (T a) {
      if (mCount == Capacity) {
         ArrayResize ();
         Array.Resize (ref mArrayQueue, Capacity * 2);
      }
      mRear = (mRear + 1) % Capacity;
      mArrayQueue[mRear] = a;
      mCount++;
   }

   /// <summary>Delete/Dequeue the first inserted element</summary>
   /// <returns>Returns the deleted element </returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      var dequeuedElement = mArrayQueue[mFront];
      mFront = (mFront + 1) % Capacity;
      if (mFront == mRear) {
         mRear = -1;
         mFront = 0;
      }
      mCount--;
      return dequeuedElement;
   }

   /// <summary>Returns the peek element in the queue</summary>
   /// <returns>Returns the first element of the queue</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ();
      return mArrayQueue[mFront];
   }

   /// <summary>Print the elements of the queue</summary>
   public void Display () {
      if (IsEmpty) return;
      Write ("QUEUE : ");
      int i = mFront;
      for (; i != mRear; i = (i + 1) % Capacity) Write (mArrayQueue[i] + " ");
      Write (mArrayQueue[i]);
      WriteLine ();
   }

   /// <summary>Resizes the array</summary>
   void ArrayResize () {
      T[] newArray = new T[Capacity];
      int j = 0;
      do {
         newArray[j] = mArrayQueue[mFront];
         mFront = (mFront + 1) % Capacity;
         j++;
      } while (mFront != (mRear + 1) % Capacity);
      mArrayQueue = newArray;
      mFront = 0;
      mRear = Capacity - 1;
   }
   #endregion

   #region Private Data ------------------------------------------
   // Private variable for initialising array and count
   T[] mArrayQueue;
   int mCount, mFront, mRear;
   #endregion
}
#endregion