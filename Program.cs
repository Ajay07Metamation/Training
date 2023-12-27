// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Double Ended Queue
// Implement a double ended queue with array as underlying structure
// ----------------------------------------------------------------------------------------

namespace Training {
   internal class Program {
      private static void Main (string[] args) {
      }
   }

   #region Class MyDeQueue ---------------------------------------------------------------------
   /// <summary>Represent a queue with insertion and deletion at both the ends</summary>
   public class MyDeQueue<T> {

      #region Constructor -------------------------------------------
      // Constructor for initializing the array and count
      public MyDeQueue () {
         mArray = new T[4];
         mCount = 0;
         mRear = -1;
      }
      #endregion

      #region Properties --------------------------------------------
      /// <summary>Returns the number of elements in the double ended queue</summary>
      public int Count => mCount;

      /// <summary>Returns the capacity of the queue</summary>
      public int Capacity => mArray.Length;

      /// <summary>Returns true if the queue is empty else returns false</summary>
      bool IsEmpty => Count == 0;

      /// <summary>Returns true if the queue is full else returns false</summary>
      bool IsFull => Count == Capacity;
      #endregion

      #region Implementation ----------------------------------------
      /// <summary>Add/Enqueue an element at the front end of the queue</summary>
      /// <param name="a">Element to be added</param>
      public void FEnqueue (T a) {
         if (IsFull) ArrayResize ();
         mFront = (mFront + Capacity - 1) % Capacity;
         mArray[mFront] = a;
         mCount++;
      }

      /// <summary>Delete/Dequeue the element at the front end of the queue</summary>
      /// <returns>Returns the deleted element</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T FDequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         var dequeuedElement = mArray[mFront];
         if (mFront == mRear && Count == 1) {
            mRear = -1;
            mFront = 0;
         } else mFront = (mFront + 1) % Capacity;
         mCount--;
         return dequeuedElement;
      }

      /// <summary>Add/Enqueue an element at the rear end of the queue</summary>
      /// <param name="a">Element to be added</param>
      public void REnqueue (T a) {
         if (IsFull) ArrayResize ();
         mRear = (mRear + 1) % Capacity;
         mArray[mRear] = a;
         mCount++;
      }

      /// <summary>Delete/Dequeue the element at the rear end of the queue</summary>
      /// <returns>Returns the deleted element</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T RDequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         if (mRear == -1) mRear = Capacity - 1;
         var dequeuedElement = mArray[mRear];
         if (mFront == mRear && Count == 1) {
            mRear = -1;
            mFront = 0;
         } else mRear = (mRear + Capacity - 1) % Capacity;
         mCount--;
         return dequeuedElement;
      }

      /// <summary>Returns the peek element at the front end of the queue</summary>
      /// <returns>Returns the first element at the front end of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T FPeek () {
         if (IsEmpty) throw new InvalidOperationException ();
         return mArray[mFront];
      }

      /// <summary>Returns the peek element at the rear end of the queue</summary>
      /// <returns>Returns the first element at the rear end of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T RPeek () {
         if (IsEmpty) throw new InvalidOperationException ();
         if (mRear == -1) mRear = Capacity - 1;
         return mArray[mRear];
      }

      /// <summary>Resizes the array</summary>
      void ArrayResize () {
         T[] newArray = new T[Capacity];
         int j = 0;
         while (j < mCount) {
            newArray[j++] = mArray[mFront];
            mFront = (mFront + Capacity + 1) % Capacity;
         }
         mArray = newArray;
         Array.Resize (ref mArray, Capacity * 2);
         mFront = 0;
         mRear = mCount-1;
      }

      /// <summary>Displays the double ended queue</summary>
      /// <exception cref="InvalidOperationException"></exception>
      public void Display () {
         if (IsEmpty) throw new InvalidOperationException ();
         for (int i = 0; i < Count; i++) {
            Console.WriteLine (mArray[(mFront + i) % Capacity]);
         }
      }
      #endregion

      #region Private Data ------------------------------------------
      // Private variable for initialising array,count,front and rear
      T[] mArray;
      int mCount, mFront, mRear;
      #endregion
   }
   #endregion
}