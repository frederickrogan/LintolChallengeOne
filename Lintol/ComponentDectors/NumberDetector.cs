using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class NumberDetector : IDetectComponents
    {
        public Component Detect(Word word)
        {
            return int.TryParse(word.Content, out int _)
                ? new Component(word, ComponentType.Number)
                : null;
        }
    }
}