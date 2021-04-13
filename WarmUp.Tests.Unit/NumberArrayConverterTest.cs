using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace WarmUp.Tests
{
    [TestFixture]
    public class NumberArrayConverterTest
    {
        Fixture _fixture = new Fixture();
        NumberArrayConverter _numberArrayConverter;

        [SetUp]
        public void SetUp()
        {
            _numberArrayConverter = new NumberArrayConverter();
        }

        [Test]
        public void SplitToEvenAndOdd_Return_OnlyEven_InFirstArray()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (even, _) = _numberArrayConverter.SplitToEvenAndOdd(array);
            Assert.IsFalse(even.Any(e => e % 2 == 1));
        }

        [Test]
        public void SplitToEvenAndOdd_Return_OnlyOdd_InSecondArray()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (_, odd) = _numberArrayConverter.SplitToEvenAndOdd(array);
            Assert.IsFalse(odd.Any(e => e % 2 == 0));
        }

        [Test]
        public void SplitToEvenAndOdd_Return_Arrays_ThatLenghtsAreEqual_InputArrayLength()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (even, odd) = _numberArrayConverter.SplitToEvenAndOdd(array);
            Assert.AreEqual(array.Count(), even.Length + odd.Length);
        }

        [Test]
        public void SplitToEvenAndOdd_Return_Arrays_WhereNumbers_ExistInInputArray()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (even, odd) = _numberArrayConverter.SplitToEvenAndOdd(array);

            bool numberNotExist = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (!even.Any(e => e == array[i]) && !odd.Any(o => o == array[i]))
                {
                    numberNotExist = true;
                    break;
                }
            }
            Assert.IsFalse(numberNotExist);
        }
    }
}
