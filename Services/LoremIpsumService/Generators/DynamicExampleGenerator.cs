using System;
using System.Text;

namespace LoremIpsumService.Generators
{
    public class DynamicExampleGenerator:ITextGenerator
    {
        private static  string[] WORDS = new string[] {"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
            "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
            "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

        public string GenerateText(int length)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var numSentences = length;
            var numWords = length;

            var result = new StringBuilder();

            for (var s = 0; s < numSentences; s++)
            {
                for (var w = 0; w < numWords; w++)
                {
                    if (w > 0)
                    {
                        result.Append(" ");
                    }

                    result.Append(WORDS[rand.Next(WORDS.Length)]);
                }

                result.Append(". ");
            }

            return result.ToString();
        }
    }
}
