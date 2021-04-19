using System.Linq;
using NUnit.Framework;

namespace WarmUp.Tests.Unit
{
    [TestFixture]
    public class CapitalLettersServiceTest
    {
        private string _text;
        private CapitalLettersService _capitalLettersService;

        [SetUp]
        public void SetUp()
        {
            _text = "SimPle TeXt To TESt";
            _capitalLettersService = new CapitalLettersService();
        }

        #region TOGGLE

        [Test]
        public void Toggle_Change_LowerCase_To_UpperCase()
        {
            var uppers = _text.Where(c => char.IsUpper(c) && !char.IsWhiteSpace(c)).ToArray();
            var toggled = _capitalLettersService.Toggle(_text);

            var lowersToggled = toggled.Where(c => !char.IsUpper(c) && !char.IsWhiteSpace(c)).ToArray();

            var isToggled = true;

            for (int i = 0; i < uppers.Length; i++)
            {
                if(uppers[i] == lowersToggled[i])
                {
                    isToggled = false;
                    break;
                }
            }

            Assert.IsTrue(isToggled);
        }

        [Test]
        public void Toggle_Change_UpperCase_To_LowerCase()
        {
            var lowers = _text.Where(c => !char.IsUpper(c) && !char.IsWhiteSpace(c)).ToArray();

            var toggled = _capitalLettersService.Toggle(_text);

            var uppersToggled = toggled.Where(c => char.IsUpper(c) && !char.IsWhiteSpace(c)).ToArray();

            var isToggled = true;

            for (int i = 0; i < lowers.Length; i++)
            {
                if (lowers[i] == uppersToggled[i])
                {
                    isToggled = false;
                    break;
                }
            }

            Assert.IsTrue(isToggled);
        }

        [Test]
        public void Toggle_Return_String_With_The_Same_Length()
        {
            var toggled = _capitalLettersService.Toggle(_text);

            Assert.AreEqual(_text.Length, toggled.Length);
        }

        [Test]
        public void Toggle_Return_TheSameText_When_Ignore_Case()
        {
            var toggled = _capitalLettersService.Toggle(_text);

            StringAssert.AreEqualIgnoringCase(_text, toggled);
        }
        
        #endregion
    }
}
