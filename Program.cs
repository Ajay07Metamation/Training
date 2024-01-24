// Complex Numbers
class ComplexNumbers {
   public ComplexNumbers (double real, double imaginary) {
      mReal = real;
      mImaginary = imaginary;
   }
   public string GetNum => "(" + mReal.ToString () + ")+(" + mImaginary.ToString () + "i)";
   public double Norm =>
           Math.Sqrt (mReal * mReal + mImaginary * mImaginary);
   public (double, double) Add (ComplexNumbers a) =>
                      (a.mReal + this.mReal, a.mImaginary + this.mImaginary);

   public (double, double) Sub (ComplexNumbers a, ComplexNumbers b) =>
                      (a.mReal - b.mReal, a.mImaginary - b.mImaginary);

   double mReal;
   double mImaginary;
}