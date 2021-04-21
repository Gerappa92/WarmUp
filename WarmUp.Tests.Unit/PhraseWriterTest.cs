using NUnit.Framework;
using System.Linq;

namespace WarmUp.Tests.Unit
{
    [TestFixture]
    public class PhraseWriterTest
    {
        private PhraseWriter _phraseWriter;
        private string _phrase;

        [SetUp]
        public void SetUp()
        {
            _phraseWriter = new PhraseWriter();
            _phrase = "Some Phrase tO    tEsT 123";
        }

        #region CAMEL_CASE

        [Test]
        public void CamelCase_Return_FirstLetter_Lower()
        {
            var camel = _phraseWriter.CamelCase(_phrase);
            Assert.IsTrue(char.IsLower(camel[0]));
        }

        [Test]
        public void CamelCase_Return_EachWordBeginningOnUpper_WithoutFirstWord()
        {
            var firstLetters = _phrase.Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => char.ToUpper(w[0]))
                .ToArray();

            var camel = _phraseWriter.CamelCase(_phrase);

            bool areUpper = true;
            for(int i = 1; i < firstLetters.Length; i++)
            {
                if(camel.IndexOf(firstLetters[i]) < 0)
                {
                    areUpper = false;
                    break;
                }
            }            

            Assert.IsTrue(areUpper);
        }

        [Test]
        public void CamelCase_Return_EachWordHasLowerCase_WithoutFirstLetter()
        {
            var letters = _phrase.Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => w.Remove(0, 1).ToLower())
                .SelectMany(w => w);
            var camel = _phraseWriter.CamelCase(_phrase);

            bool areLower = true;
            foreach (var letter in letters)
            {
                if(camel.IndexOf(letter) < 0)
                {
                    areLower = false;
                    break;
                }
            }

            Assert.IsTrue(areLower);
        }

        [Test]
        public void CamelCase_Return_Phrase_Without_WhiteSpaces()
        {
            var camel = _phraseWriter.CamelCase(_phrase);
            Assert.IsFalse(camel.Any(l => char.IsWhiteSpace(l)));
        }

        [Test]
        public void CamelCase_Return_Empty_When_InputIsEmpty()
        {
            var camel = _phraseWriter.CamelCase(string.Empty);
            Assert.IsEmpty(camel);
        }

        [Test]
        public void CamelCase_Return_String_Where_LenghtIsEqual_To_InputPhrase_Without_WhiteSpaces()
        {
            var phareseLength = _phrase.Where(c => !char.IsWhiteSpace(c)).Count();
            var camel = _phraseWriter.CamelCase(_phrase);

            Assert.AreEqual(phareseLength, camel.Length);
        }

        #endregion
    }
}
