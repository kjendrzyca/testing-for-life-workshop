namespace TestingForLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // very stupid and incomplete calculator, at that!
    public class Calculator
    {
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Divide(decimal a, decimal b)
        {
            if (b == 0)
            {
                throw new CannotDivideByZeroException();
            }

            return a / b;
        }

        public IEnumerable<decimal> LookAtMyAbs(IEnumerable<decimal> a)
        {
            return a.Select(Math.Abs);
        }
    }
}
