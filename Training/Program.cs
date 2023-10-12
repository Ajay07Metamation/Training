// MyList<T>
// Create a list (MyList<T>) with underlying structure as array using property,methods and private variables

// TEST CASE

MyList<int> list = new ();
list.Add (1);
list.Add (2);
list.Add (3);
list.Add (4);
list.Add (5);
list.Add (6);
list.Add (7);
list.Add (8);
list.PrintList ();
list.Insert (4, 9);
list.PrintList ();
list.Remove (4);
list.PrintList (); ;
list.RemoveAt (2);
list.PrintList ();
list.Clear ();
list.PrintList ();

/// <summary>Creating a class MyList with underlying structure as array</summary>
class MyList<T> {
   // Private variables for creating array and int variable for count
   T[] marrayList;
   int mcount;
   public MyList () {
      marrayList = new T[4];
      mcount = 0;
   }

   /// <summary>Creating property for getting count and capacity</summary>
   public int Count => mcount;
   public int Capacity => marrayList.Length;

   /// <summary>public T this[int index] is a property used to get a element at a index or set it</summary>
   /// <returns>returns the element at the specified index</returns>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public T this[int index] {
      get {
         if (index < 0 || index > Capacity) throw new IndexOutOfRangeException ();
         return marrayList[index];
      }
      set {
         if (index < 0 || index > Capacity) throw new IndexOutOfRangeException ();
         marrayList[index] = value;
      }
   }

   /// <summary>Method Add to add an element in the list at the end</summary>
   /// <param name="a">It is the element to be added to the list</param>
   public void Add (T a) {
      if (a == null) throw new ArgumentNullException ();
      if (mcount == Capacity) Array.Resize (ref marrayList, Capacity * 2);
      marrayList[mcount++] = a;
   }

   /// <summary>Method remove to remove a particular element</summary>
   /// <param name="a">The element in the list to be removed</param>
   /// <exception cref="InvalidOperationException"></exception>
   public bool Remove (T a) {
      if (Array.IndexOf (marrayList, a) == -1) throw new InvalidOperationException ();
      int index = Array.IndexOf (marrayList, a, 0, mcount);
      for (int i = index; i < mcount; i++) marrayList[i] = marrayList[i + 1];
      mcount--;
      return true;
   }

   /// <summary>Method clear to clear the list</summary>
   /// <exception cref="InvalidOperationException"></exception>
   public void Clear () {
      if (marrayList.Length <= 0) throw new InvalidOperationException ();
      Array.Clear (marrayList, 0, mcount);
      mcount = 0;
   }

   /// <summary>Method Insert to insert a specified element at a specified index</summary>
   /// <param name="index">The index where the element should be inserted</param>
   /// <param name="a">The element to be inserted</param>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void Insert (int index, T a) {
      if (a == null) throw new ArgumentNullException ();
      if (index < 0 || index > mcount) throw new IndexOutOfRangeException ();
      if (mcount == marrayList.Length) Array.Resize (ref marrayList, Capacity * 2);
      for (int i = mcount; i > index; i--) marrayList[i] = marrayList[i - 1];
      marrayList[index] = a;
      mcount++;
   }

   /// <summary>Method RemoveAt to remove the element at a particular index</summary>
   /// <param name="index">The index at which the element is to be removed</param>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void RemoveAt (int index) {
      if (index < 0 || index > mcount) throw new IndexOutOfRangeException ();
      if (mcount == marrayList.Length) Array.Resize (ref marrayList, Capacity * 2);
      for (int i = index; i < mcount; i++) marrayList[i] = marrayList[i + 1];
      mcount--;
   }

   /// <summary>Method to print the list</summary>
   public void PrintList () {
      Console.Write ("List : ");
      for (int i = 0; i < mcount; i++) {
         Console.Write (marrayList[i] + " ");
      }
      Console.WriteLine ();
   }
}
