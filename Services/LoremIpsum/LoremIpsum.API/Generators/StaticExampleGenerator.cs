using LoremIpsumService.Generators;

namespace LoremIpsumService.Generators
{
    public class StaticExampleGenerator:ITextGenerator
    {
        public string GenerateText(int length)
        {
            return "This is a static example:\n"+length;
        }
    }
}
