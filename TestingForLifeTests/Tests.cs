namespace TestingForLifeTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using FakeItEasy;
    using Xunit;
    using TestingForLife;

    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, -1, 0)]
        public void ShouldAddTwoDigits(int a, int b, int expected)
        {
            // given
            var calculator = new Calculator(new TheTimeMaster());

            // when
            var actual = calculator.Add(a, b);

            // then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldNotDivideByZero()
        {
            // given
            var calculator = new Calculator(new TheTimeMaster());

            // when
            Action divisionByZero = () => calculator.Divide(1, 0);

            // then
            Assert.Throws(typeof(CannotDivideByZeroException), divisionByZero);
        }

        [Theory]
        [MemberData(nameof(AddCollectionTestCase))]
        public void ShouldAddCollection(IEnumerable<decimal> coll, decimal result)
        {
            // given
            var calc = new Calculator(new TheTimeMaster());

            // when
            var actual = calc.Add(coll);

            // then
            Assert.Equal(result, actual);
        }

        private static IEnumerable<object[]> AddCollectionTestCase()
        {
            yield return new object[] {new[] { 2.0m, 1.0m }, 3.0m };
        }

        [Fact]
        public void ShouldNotAllowUsingStuffWhenExamIsGoingOn()
        {
            // given
            // when hour is between 8:00AM and 8:45AM
            // throw exception
            var dateTimeTimeMaster = A.Fake<ITimeMaster>();
            A.CallTo(() => dateTimeTimeMaster.Now()).Returns(new DateTime(2016, 3, 3, 8, 23, 9));

            // when
            var calculator = new Calculator(dateTimeTimeMaster);
            Assert.Throws(typeof(ExamException), () => calculator.Add(1, 1));
        }
    }
}
