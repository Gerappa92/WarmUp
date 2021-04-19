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
    }
}
