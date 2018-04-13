using System;
using System.Collections.Generic;
using System.Text;
using Lintol.ComponentDectors;
using Xunit;

namespace Lintol.Test.ComponentDectors
{
    public class LinkDetectorTests
    {
        [Fact]
        public void Detect_WorksOnFacebookLinks()
        {

            var detector = new LinkDetector();
            
            var word = new Word(0, "https://www.facebook.com/Conall.Newman");

            var component = detector.Detect(word);

            Assert.NotNull(component);

            // https://twitter.com/realDonaldTrump
            //
        }
    }
}
