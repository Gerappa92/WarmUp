using System.Linq;
using System.Text;

namespace WarmUp
{
    public class PhraseWriter
    {
        public string CamelCase(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            var camelBuilder = new StringBuilder();
            var words = phrase.Split(' ').Where(w => !string.IsNullOrEmpty(w)).ToArray();

            foreach (var word in words)
            {
                var camelWord = word.ToLower();
                camelWord = char.ToUpper(camelWord[0]) + camelWord.Remove(0,1);
                camelBuilder.Append(camelWord);
            }

            var camelPhrase = camelBuilder.ToString();
            camelPhrase = char.ToLower(camelPhrase[0]) + camelPhrase.Remove(0, 1);
            return camelPhrase;
        }
    }
}
