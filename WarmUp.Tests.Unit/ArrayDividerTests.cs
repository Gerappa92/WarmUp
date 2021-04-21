using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace WarmUp.Tests.Unit
{
    [TestFixture]
    public class ArrayDividerTests
    {
        private Fixture _fixture = new Fixture();
        private ArrayDivider _arrayDivider;
        private long[] _array;
        private int _divideIndex;

        [SetUp]
        public void SetUp()
        {
            _arrayDivider = new ArrayDivider();
            _array = new long[] { 0, 123, 65, 58, 6, -77, 6669, -56, 657, -5, 874, -645, -1, 1, 8, 78 };
            _divideIndex = 4;
        }

        #region DIVIDE

        [Test]
        public void Devide_ReturnNumbers_Which_Exist_In_IputArray()
        {
            var (left, rigth) = _arrayDivider.Divide(_array, _divideIndex);
            
            Assert.IsFalse(left.Any(l => !_array.Any(a => l == a)));
            Assert.IsFalse(rigth.Any(l => !_array.Any(a => l == a)));
        }

        [Test]
        public void Devide_ReturnArrays_Which_Lenght_Are_Equal_InputArrayLength()
        {
            var (left, right) = _arrayDivider.Divide(_array, _divideIndex);

            Assert.AreEqual(_array.Length, left.Length + right.Length);
        }

        [Test]
        public void Devide_ReturnLeftArray_Where_Length_Is_Equal_DevideIndexPlusOne()
        {
            var (left, right) = _arrayDivider.Divide(_array, _divideIndex);

            Assert.AreEqual(_divideIndex + 1, left.Length);
        }

        [Test]
        public void Devide_ReturnRightArray_Where_Length_Is_Equal_InputArrayLength_Minus_DevideIndex_Minus_One()
        {
            var (left, right) = _arrayDivider.Divide(_array, _divideIndex);

            Assert.AreEqual(_array.Length - _divideIndex - 1, right.Length);
        }

        [Test]
        public void Devide_ReturnEmptyRigtArray_When_DivideIndex_IsGreaterThan_InputArrayLength()
        {
            int divideIndex = _array.Length + 10;
            var (left, right) = _arrayDivider.Divide(_array, divideIndex);

            Assert.AreEqual(0, right.Length);
        }

        #endregion

        #region DIVIDE TO EVEN AND ODD

        [Test]
        public void DivideToEvenAndOdd_Return_OnlyEven_InFirstArray()
        {
            var (even, _) = _arrayDivider.DivideToEvenAndOdd(_array);
            Assert.IsFalse(even.Any(e => e % 2 == 1));
        }

        [Test]
        public void DivideToEvenAndOdd_Return_OnlyOdd_InSecondArray()
        {
            var (_, odd) = _arrayDivider.DivideToEvenAndOdd(_array);
            Assert.IsFalse(odd.Any(e => e % 2 == 0));
        }

        [Test]
        public void DivideToEvenAndOdd_Return_Arrays_ThatLenghtsAreEqual_InputArrayLength()
        {
            var (even, odd) = _arrayDivider.DivideToEvenAndOdd(_array);
            Assert.AreEqual(_array.Length, even.Length + odd.Length);
        }

        [Test]
        public void DivideToEvenAndOdd_Return_Arrays_WhereNumbers_ExistInInputArray()
        {
            var (even, odd) = _arrayDivider.DivideToEvenAndOdd(_array);

            Assert.IsFalse(even.Any(e => !_array.Any(a => e == a)));
            Assert.IsFalse(odd.Any(o => !_array.Any(a => o == a)));
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
            var array = new long[] { 5 };
            var (left, right) = _arrayDivider.DivideOnHalfs(array);

            Assert.AreEqual(0, right.Length);
        }

        [Test]
        public void DivideOnHalfs_Return_Two_Arrays_Where_Left_Has_Half_Elements_From_Array_And_Right_Has_SecondHalfElements()
        {
            var (left, right) = _arrayDivider.DivideOnHalfs(_array);

            bool isLeftEqual = true;
            bool isRightEqual = true;
            var halfIndex = (_array.Length / 2) + _array.Length % 2;

            for (int i = 0; i < _array.Length; i++)
            {
                if(i < halfIndex)
                {
                    if(_array[i] != left[i])
                    {
                        isLeftEqual = false;
                    }
                }
                else
                {
                    var rightIndex = i - halfIndex;
                    if (_array[i] != right[rightIndex])
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
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(_array);

            Assert.IsFalse(positive.Any(p => p < 0));
        }

        [Test]
        public void In_NegativeArray_Are_Only_Negative()
        {
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(_array);

            Assert.IsFalse(negative.Any(p => p >= 0));
        }

        [Test]
        public void LengthOfTwoReturnedArrays_Are_Equal_InputArrayLength()
        {
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(_array);

            Assert.AreEqual(_array.Length, positive.Length + negative.Length);
        }

        [Test]
        public void NumbersInReturnedArrays_Exist_InInputArray()
        {
            var (positive, negative) = _arrayDivider.DivideToPositiveAndNegative(_array);

            Assert.IsFalse(positive.Any(p => !_array.Any(a => a == p)));
            Assert.IsFalse(negative.Any(p => !_array.Any(a => a == p)));
        }

        #endregion
    }
}
