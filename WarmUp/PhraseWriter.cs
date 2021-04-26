using System.Linq;
using System.Text;

namespace WarmUp
{
    public class PhraseWriter
    {
        public string PascalCase(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            var camelBuilder = new StringBuilder();
            var words = phrase.Split(' ')
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w => w.ToLower())
                .Select(w => char.ToUpper(w[0]) + w.Remove(0, 1));

            return string.Join(null, words);
        }

        public string CamelCase(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }
            var pascal = PascalCase(phrase);
            var camel = char.ToLower(pascal[0]) + pascal.Remove(0, 1);
            return camel;
        }

        public string SnakeCase(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            var words = phrase.Split(' ')
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w => w.ToLower());

            return string.Join('_', words);
        }

        public string KebabCase(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            var words = phrase.Split(' ')
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w => w.ToLower());

            return string.Join('-', words);
        }
    }
}
