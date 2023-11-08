// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// MyQueue<T>
// Create a Queue (MyQueue<T>) with underlying structure as array using property,methods and private variables
// ----------------------------------------------------------------------------------------

namespace Training {
   using static System.Console;

   #region Program ----------------------------------------------------------------------
   internal class Program {
      private static void Main (string[] args) {
         TQueue<int> queue = new TQueue<int> ();
         queue.Enqueue (1);
         queue.Enqueue (2);
         queue.Enqueue (3);
         queue.Enqueue (4);
         queue.Display ();
         queue.Dequeue ();
         queue.Display ();
         queue.Dequeue ();
         queue.Display ();
         queue.Enqueue (8);
         queue.Enqueue (9);
         queue.Enqueue (10);
         queue.Enqueue (11);
         queue.Enqueue (12);
         queue.Enqueue (13);
         queue.Enqueue (14);
         queue.Enqueue (15);
         queue.Display ();
         queue.Dequeue ();
         queue.Dequeue ();
         queue.Display ();
         Console.WriteLine ("Peek:" + queue.Peek ());
      }
   }
   #endregion

   #region Class MyQueue ---------------------------------------------------------------------
   /// <summary>Represent a first in first out principle collection of objects</summary>
   public class TQueue<T> {

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
         }
         mArrayQueue[mRear] = a;
         mRear = (mRear + 1) % Capacity;
         mCount++;
      }

      /// <summary>Delete/Dequeue the first inserted element</summary>
      /// <returns>Returns the deleted element </returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Dequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         var dequeuedElement = mArrayQueue[mFront];
         mFront = (mFront + 1) % Capacity;
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
         for (int i = 0; i < mCount; i++) Write (mArrayQueue[(i + mFront) % Capacity] + " ");
         WriteLine ();
      }

      /// <summary>Resizes the array</summary>
      void ArrayResize () {
         T[] newArray = new T[Capacity * 2];
         int j = 0;
         for (int i = 0; i < mCount; i++)
            newArray[i] = mArrayQueue[(i + mFront) % Capacity];
         mArrayQueue = newArray;
         mFront = 0;
         mRear = mCount;
      }
      #endregion

      #region Private Data ------------------------------------------
      // Private variable for initialising array and count
      T[] mArrayQueue = new T[4];
      int mCount, mFront, mRear;
      #endregion
   }
   #endregion
}