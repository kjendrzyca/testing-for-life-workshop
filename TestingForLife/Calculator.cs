namespace TestingForLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // very stupid and incomplete calculator, at that!
    public class Calculator
    {
        private readonly ITimeMaster _time;

        public Calculator(ITimeMaster time)
        {
            _time = time;
        }

        public decimal Add(decimal a, decimal b)
        {
            ExamCheck();
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

        public decimal Add(IEnumerable<decimal> coll)
        {
            return coll.Sum();
        }

        public void ExamCheck()
        {
            if (_time.Now().Hour == 8 && _time.Now().Minute <= 45)
            {
                throw new ExamException();
            }
        }
    }

    public interface ITimeMaster
    {
        DateTime Now();
    }

    public class TheTimeMaster : ITimeMaster
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }

    public class ExamException : Exception
    {
    }
}
