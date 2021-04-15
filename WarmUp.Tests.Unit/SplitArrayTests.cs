using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace WarmUp.Tests
{
    [TestFixture]
    public class SplitArrayTests
    {
        Fixture _fixture = new Fixture();
        SplitArray _numberArrayConverter;

        [SetUp]
        public void SetUp()
        {
            _numberArrayConverter = new SplitArray();
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

        [Test]
        public void SplitToEvenAndOdd_Return_Empty_Odd_Array_When_Are_Only_Even_Numbers()
        {
            var array = new long[] { 2, 16, 24, 100, 6, 8, 88, 1542 };
            var (even, odd) = _numberArrayConverter.SplitToEvenAndOdd(array);

            Assert.AreEqual(0, odd.Length);
        }

        [Test]
        public void SplitToEvenAndOdd_Return_Empty_Even_Array_When_Are_Only_Odd_Numbers()
        {
            var array = new long[] { 3, 15, 27, 127, 9, 555, 6521 };
            var (even, odd) = _numberArrayConverter.SplitToEvenAndOdd(array);

            Assert.AreEqual(0, even.Length);
        }

        //SPLIT ARRAY ON HALFS

        [Test]
        public void SplitOnHalfs_Return_Arrays_With_Equal_Length_When_ArrayLengthIsEven()
        {
            var array =_fixture.CreateMany<long>(16).ToArray();
            var (left, right) = _numberArrayConverter.SplitOnHalfs(array);

            Assert.AreEqual(left.Length, right.Length);
        }

        [Test]
        public void SplitOnHalfs_Return_Arrays_Length_DiffrentByOneNumber_When_ArrayLengthIsOdd()
        {
            var array = _fixture.CreateMany<long>(15).ToArray();
            var (left, right) = _numberArrayConverter.SplitOnHalfs(array);

            Assert.AreEqual(left.Length, right.Length+1);
        }

        [Test]
        public void SplitOnHalfs_Return_Second_Array_Empty_When_ArrayHas_Only_One_Element()
        {
            var array = _fixture.CreateMany<long>(1).ToArray();
            var (left, right) = _numberArrayConverter.SplitOnHalfs(array);

            Assert.AreEqual(0, right.Length);
        }

        [Test]
        public void SplitOnHalfs_Return_Two_Arrays_Where_Left_Has_Half_Elements_From_Array_And_Right_Has_SecondHalfElements()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (left, right) = _numberArrayConverter.SplitOnHalfs(array);

            bool isLeftEqual = true;
            bool isRightEqual = true;
            var halfIndex = (array.Length / 2) + array.Length % 2;

            for (int i = 0; i < array.Length; i++)
            {
                if(i < halfIndex)
                {
                    if(array[i] != left[i])
                    {
                        isLeftEqual = false;
                    }
                }
                else
                {
                    var rightIndex = i - halfIndex;
                    if (array[i] != right[rightIndex])
                    {
                        isRightEqual = false;
                    }
                }
            }

            Assert.IsTrue(isLeftEqual);
            Assert.IsTrue(isRightEqual);
        }
    }
}
