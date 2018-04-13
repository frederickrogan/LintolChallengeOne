using System.Text.RegularExpressions;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class RegexDetector : IDetectComponents
    {
        private readonly string pattern;
        private readonly ComponentType type;

        public RegexDetector(string pattern, ComponentType type)
        {
            this.pattern = pattern;
            this.type = type;
        }

        public Component Detect(Word word)
        {
            return Regex.IsMatch(word.Content, pattern)
                ? new Component(word, type)
                : null;
        }
    }

    public class WordDetector : IDetectComponents
    {
        private readonly string wordToCheckAgainst;
        private readonly ComponentType type;

        public WordDetector(string wordToCheckAgainst, ComponentType type)
        {
            this.wordToCheckAgainst = wordToCheckAgainst.ToLower();
            this.type = type;
        }

        public Component Detect(Word word)
        {
            return wordToCheckAgainst == word.Content.ToLower()
                ? new Component(word, type)
                : null;
        }
    }
}