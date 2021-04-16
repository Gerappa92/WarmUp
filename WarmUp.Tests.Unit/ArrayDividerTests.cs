using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace WarmUp.Tests
{
    [TestFixture]
    public class ArrayDividerTests
    {
        Fixture _fixture = new Fixture();
        ArrayDivider _arrayDivider;

        [SetUp]
        public void SetUp()
        {
            _arrayDivider = new ArrayDivider();
        }

        #region DIVIDE TO EVEN AND ODD

        [Test]
        public void DivideToEvenAndOdd_Return_OnlyEven_InFirstArray()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (even, _) = _arrayDivider.DivideToEvenAndOdd(array);
            Assert.IsFalse(even.Any(e => e % 2 == 1));
        }

        [Test]
        public void DivideToEvenAndOdd_Return_OnlyOdd_InSecondArray()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (_, odd) = _arrayDivider.DivideToEvenAndOdd(array);
            Assert.IsFalse(odd.Any(e => e % 2 == 0));
        }

        [Test]
        public void DivideToEvenAndOdd_Return_Arrays_ThatLenghtsAreEqual_InputArrayLength()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (even, odd) = _arrayDivider.DivideToEvenAndOdd(array);
            Assert.AreEqual(array.Count(), even.Length + odd.Length);
        }

        [Test]
        public void DivideToEvenAndOdd_Return_Arrays_WhereNumbers_ExistInInputArray()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (even, odd) = _arrayDivider.DivideToEvenAndOdd(array);

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
        public void DivideToEvenAndOdd_Return_Empty_Odd_Array_When_Are_Only_Even_Numbers()
        {
            var array = new long[] { 2, 16, 24, 100, 6, 8, 88, 1542 };
            var (even, odd) = _arrayDivider.DivideToEvenAndOdd(array);

            Assert.AreEqual(0, odd.Length);
        }

        [Test]
        public void DivideToEvenAndOdd_Return_Empty_Even_Array_When_Are_Only_Odd_Numbers()
        {
            var array = new long[] { 3, 15, 27, 127, 9, 555, 6521 };
            var (even, odd) = _arrayDivider.DivideToEvenAndOdd(array);

            Assert.AreEqual(0, even.Length);
        }
        #endregion

        #region DIVIDE ARRAY ON HALFS

        [Test]
        public void DivideOnHalfs_Return_Arrays_With_Equal_Length_When_ArrayLengthIsEven()
        {
            var array =_fixture.CreateMany<long>(16).ToArray();
            var (left, right) = _arrayDivider.DivideOnHalfs(array);

            Assert.AreEqual(left.Length, right.Length);
        }

        [Test]
        public void DivideOnHalfs_Return_Arrays_Length_DiffrentByOneNumber_When_ArrayLengthIsOdd()
        {
            var array = _fixture.CreateMany<long>(15).ToArray();
            var (left, right) = _arrayDivider.DivideOnHalfs(array);

            Assert.AreEqual(left.Length, right.Length+1);
        }

        [Test]
        public void DivideOnHalfs_Return_Second_Array_Empty_When_ArrayHas_Only_One_Element()
        {
            var array = _fixture.CreateMany<long>(1).ToArray();
            var (left, right) = _arrayDivider.DivideOnHalfs(array);

            Assert.AreEqual(0, right.Length);
        }

        [Test]
        public void DivideOnHalfs_Return_Two_Arrays_Where_Left_Has_Half_Elements_From_Array_And_Right_Has_SecondHalfElements()
        {
            var array = _fixture.CreateMany<long>().ToArray();
            var (left, right) = _arrayDivider.DivideOnHalfs(array);

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

        #endregion

        #region DIVIDE TO POSITIVE AND NEGATIVE
        [Test]
        public void In_PositiveArray_Are_Only_Positive()
        {
            var array = new long[] { 0, 12, -52, 63, 126, -89, 465, -6714, 5654 };
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(array);

            Assert.IsFalse(positive.Any(p => p < 0));
        }

        [Test]
        public void In_NegativeArray_Are_Only_Negative()
        {
            var array = new long[] { 0, 12, -52, 63, 126, -89, 465, -6714, 5654 };
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(array);

            Assert.IsFalse(negative.Any(p => p >= 0));
        }

        [Test]
        public void LengthOfTwoReturnedArrays_Are_Equal_InputArrayLength()
        {
            var array = new long[] { 0, 12, -52, 63, 126, -89, 465, -6714, 5654 };
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(array);

            Assert.AreEqual(array.Length, positive.Length + negative.Length);
        }

        [Test]
        public void NumbersInReturnedArrays_Exist_InInputArray()
        {
            var array = new long[] { 0, 12, -52, 63, 126, -89, 465, -6714, 5654 };
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(array);

            Assert.IsTrue(positive.Any(p => array.Any(a => a == p)));
            Assert.IsTrue(negative.Any(p => array.Any(a => a == p)));
        }

        #endregion
    }
}
