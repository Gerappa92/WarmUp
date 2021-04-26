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

        #region SNAKE_CASE

        [Test]
        public void SnakeCase_Return_EachLetterLower()
        {
            var letters = _phrase
                .Where(c => !char.IsWhiteSpace(c))
                .Select(c => char.ToLower(c));

            var snake = _phraseWriter.SnakeCase(_phrase);

            bool areLower = true;
            foreach (var letter in letters)
            {
                if (snake.IndexOf(letter) < 0)
                {
                    areLower = false;
                    break;
                }
            }

            Assert.IsTrue(areLower);
        }

        [Test]
        public void SnakeCase_Return_UnderscoresBetweenWords()
        {
            var underscoreCount = _phrase.Split(' ')
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Count() - 1;

            var snake = _phraseWriter.SnakeCase(_phrase);

            Assert.AreEqual(underscoreCount, snake.Where(c => c == '_').Count());
        }

        [Test]
        public void SnakeCase_Return_PhraseWithoutWhiteSpaces()
        {
            var snake = _phraseWriter.SnakeCase(_phrase);
            Assert.IsFalse(snake.Any(l => char.IsWhiteSpace(l)));
        }

        [Test]
        public void SnakeCase_Return_Empty_When_InputIsEmpty()
        {
            var snake = _phraseWriter.SnakeCase(string.Empty);
            Assert.IsEmpty(snake);
        }

        [Test]
        public void SnakeCase_Return_String_Where_LenghtIsEqual_To_InputPhrase_Without_WhiteSpaces_Plus_UnderscoreBetweenWords()
        {
            var phareseLength = _phrase.Split(' ')
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Count() - 1 +
                _phrase.Where(c => !char.IsWhiteSpace(c))
                .Count();

            var snake = _phraseWriter.SnakeCase(_phrase);

            Assert.AreEqual(phareseLength, snake.Length);
        }

        #endregion

        #region KEBAB_CASE

        [Test]
        public void KebabCase_Return_EachLetterLower()
        {
            var letters = _phrase
                .Where(c => !char.IsWhiteSpace(c))
                .Select(c => char.ToLower(c));

            var kebab = _phraseWriter.KebabCase(_phrase);

            bool areLower = true;
            foreach (var letter in letters)
            {
                if (kebab.IndexOf(letter) < 0)
                {
                    areLower = false;
                    break;
                }
            }

            Assert.IsTrue(areLower);
        }

        [Test]
        public void KebabCase_Return_HyphensBetweenWords()
        {
            var underscoreCount = _phrase.Split(' ')
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Count() - 1;

            var kebab = _phraseWriter.KebabCase(_phrase);

            Assert.AreEqual(underscoreCount, kebab.Where(c => c == '-').Count());
        }

        [Test]
        public void KebabCase_Return_PhraseWithoutWhiteSpaces()
        {
            var kebab = _phraseWriter.KebabCase(_phrase);
            Assert.IsFalse(kebab.Any(l => char.IsWhiteSpace(l)));
        }

        [Test]
        public void KebabCase_Return_Empty_When_InputIsEmpty()
        {
            var kebab = _phraseWriter.KebabCase(string.Empty);
            Assert.IsEmpty(kebab);
        }

        [Test]
        public void KebabCase_Return_String_Where_LenghtIsEqual_To_InputPhrase_Without_WhiteSpaces_Plus_HyphensBetweenWords()
        {
            var phareseLength = _phrase.Split(' ')
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Count() - 1 +
                _phrase.Where(c => !char.IsWhiteSpace(c))
                .Count();

            var kebab = _phraseWriter.KebabCase(_phrase);

            Assert.AreEqual(phareseLength, kebab.Length);
        }

        #endregion

        #region PASCAL_CASE

        [Test]
        public void PascalCase_Return_FirstLetterUpper_InEachWord()
        {
            var firstLetters = _phrase.Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => char.ToUpper(w[0]))
                .ToArray();

            var pascal = _phraseWriter.PascalCase(_phrase);

            bool areUpper = true;
            for (int i = 0; i < firstLetters.Length; i++)
            {
                if (pascal.IndexOf(firstLetters[i]) < 0)
                {
                    areUpper = false;
                    break;
                }
            }

            Assert.IsTrue(areUpper);
        }

        [Test]
        public void PascalCase_Return_EachLetterLower_WithoutFirstLetter()
        {
            var letters = _phrase.Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => w.Remove(0, 1).ToLower())
                .SelectMany(w => w);
            var pascal = _phraseWriter.PascalCase(_phrase);

            bool areLower = true;
            foreach (var letter in letters)
            {
                if (pascal.IndexOf(letter) < 0)
                {
                    areLower = false;
                    break;
                }
            }

            Assert.IsTrue(areLower);
        }

        [Test]
        public void PascalCase_Return_PhraseWithoutWhiteSpaces()
        {
            var pascal = _phraseWriter.PascalCase(_phrase);
            Assert.IsFalse(pascal.Any(l => char.IsWhiteSpace(l)));
        }

        [Test]
        public void PascalCase_Return_Empty_When_InputIsEmpty()
        {
            var pascal = _phraseWriter.PascalCase(string.Empty);
            Assert.IsEmpty(pascal);
        }

        [Test]
        public void PascalCase_Return_String_Where_LenghtIsEqual_To_InputPhrase_Without_WhiteSpaces()
        {
            var phareseLength = _phrase.Where(c => !char.IsWhiteSpace(c)).Count();
            var pascal = _phraseWriter.PascalCase(_phrase);

            Assert.AreEqual(phareseLength, pascal.Length);
        }

        #endregion

        #region CAMEL_CASE

        [Test]
        public void CamelCase_Return_FirstLetterLower()
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
        public void CamelCase_Return_PhraseWithoutWhiteSpaces()
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
