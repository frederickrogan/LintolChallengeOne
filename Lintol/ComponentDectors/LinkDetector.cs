using System;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class LinkDetector : IDetectComponents
    {
        public Component Detect(Word word)
        {
            return Uri.TryCreate(word.Content, UriKind.Absolute, out Uri _) 
                ? new Component(word, ComponentType.Link) 
                : null;
        }
    }
}