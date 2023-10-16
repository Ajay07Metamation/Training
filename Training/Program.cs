// MyList<T>
// Create a list (MyList<T>) with underlying structure as array using property,methods and private variables

// TEST CASE
using static System.Console;

internal class Program {
   private static void Main (string[] args) {
      MyList<int> list = new ();
      list.Add (1);
      list.Add (2);
      list.Add (3);
      list.Add (4);
      list.PrintList ();
      WriteLine (list.Capacity);
      list.Remove (3);
      list.PrintList ();
      list.Add (5);
      list.Add (6);
      list.Add (7);
      list.Add (8);
      list.PrintList ();
      WriteLine (list.Count);
      list.Insert (4, 9);
      list.PrintList ();
      list.Remove (4);
      list.PrintList (); ;
      list.RemoveAt (2);
      list.PrintList ();
      list.Clear ();
      list.PrintList ();
      WriteLine (list.Count);
   }
}

/// <summary>Represents a strongly typed list of objects accessed using index</summary>
class MyList<T> {
   // Private variables for creating array and int variable for count
   T[] mArrayList;
   int mCount;
   public MyList () {
      mArrayList = new T[4];
      mCount = 0;
   }

   /// <summary>Returns the number of elements in the list</summary>
   public int Count => mCount;

   /// <summary>Returns the capacity of the list</summary>
   public int Capacity => mArrayList.Length;

   /// <summary>Get a element at a index or set it</summary>
   /// <returns>returns the element at the specified index</returns>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public T this[int index] {
      get {
         if (index < 0 || index > Capacity) throw new IndexOutOfRangeException ();
         return mArrayList[index];
      }
      set {
         if (index < 0 || index > Capacity) throw new IndexOutOfRangeException ();
         mArrayList[index] = value;
      }
   }

   /// <summary>Adds an element at the end of the list</summary>
   /// <param name="a">It is the element to be added to the list</param>
   public void Add (T a) {
      if (a == null) throw new ArgumentNullException ();
      if (mCount == Capacity) Array.Resize (ref mArrayList, Capacity * 2);
      mArrayList[mCount++] = a;
   }

   /// <summary>Remove a particular element given</summary>
   /// <param name="a">The element in the list to be removed</param>
   /// <exception cref="InvalidOperationException"></exception>
   public bool Remove (T a) {
      var elementPositon = Array.IndexOf (mArrayList, a, 0, mCount - 1);
      if (elementPositon == -1) throw new InvalidOperationException ();
      for (int i = elementPositon; i < mCount - 1; i++) mArrayList[i] = mArrayList[i + 1];
      mCount--;
      return true;
   }

   /// <summary>Clears the list</summary>
   /// <exception cref="InvalidOperationException"></exception>
   public void Clear () {
      if (mArrayList.Length <= 0) throw new InvalidOperationException ();
      Array.Clear (mArrayList, 0, mCount - 1);
      mCount = 0;
   }

   /// <summary>Insert a specified element at a specified index</summary>
   /// <param name="index">The index where the element should be inserted</param>
   /// <param name="a">The element to be inserted</param>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void Insert (int index, T a) {
      if (a == null) throw new ArgumentNullException ();
      if (index < 0 || index > mCount - 1) throw new IndexOutOfRangeException ();
      if (mCount == mArrayList.Length) Array.Resize (ref mArrayList, Capacity * 2);
      for (int i = mCount; i > index; i--) mArrayList[i] = mArrayList[i - 1];
      mArrayList[index] = a;
      mCount++;
   }

   /// <summary>Removes the element at a particular index</summary>
   /// <param name="index">The index at which the element is to be removed</param>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void RemoveAt (int index) {
      if (index < 0 || index > mCount - 1) throw new IndexOutOfRangeException ();
      for (int i = index; i < mCount - 1; i++) mArrayList[i] = mArrayList[i + 1];
      mCount--;
   }

   /// <summary>Prints the list</summary>
   public void PrintList () {
      Write ("List : ");
      for (int i = 0; i < mCount; i++)
         Write (mArrayList[i] + " ");
      WriteLine ();
   }
}

