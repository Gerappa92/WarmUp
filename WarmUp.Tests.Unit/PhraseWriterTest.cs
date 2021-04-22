﻿using NUnit.Framework;
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