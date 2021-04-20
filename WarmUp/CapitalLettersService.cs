using System.Collections.Generic;
using System.Text;

namespace WarmUp
{
    public class CapitalLettersService
    {
        public string Toggle(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var letter in text)
            {
                var toggledLetter = char.IsUpper(letter) ? char.ToLower(letter) : char.ToUpper(letter);
                stringBuilder.Append(toggledLetter);
            }
            return stringBuilder.ToString();
        }

        public string Pokemon(string text)
        {
            var words = text.Split(' ');
            var pokemonWords = new List<string>();
            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    pokemonWords.Add(word);
                    continue;
                }
                var pokemonWord = new StringBuilder();
                pokemonWord.Append(char.ToUpper(word[0]));
                for (int i = 1; i < word.Length; i++)
                {
                    if(i%2 == 0)
                    {
                        pokemonWord.Append(char.ToUpper(word[i]));
                    }
                    else
                    {
                        pokemonWord.Append(char.ToLower(word[i]));
                    }
                }
                pokemonWords.Add(pokemonWord.ToString());
            }

            return string.Join(' ', pokemonWords);
        }
    }
}
