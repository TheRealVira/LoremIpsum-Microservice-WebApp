using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoremIpsum.Controllers
{
    [Route("interface/lorem_ipsum_generator")]
    [ApiController]
    public class LoremIpsumController : Controller
    {
        private HttpClient Client { get; }

        public LoremIpsumController()
        {
            Client = new HttpClient();
        }

        [HttpGet("{generatorType}/{count}/{length}")]
        [ActionName("GetLoremIpsumText")]
        public async Task<List<string>> GetLoremIpsumText(string generatorType, int count, int length)
        {
            var url = GetBaseUrl() + "/api/lorem_ipsum_generator/" +
                      generatorType + "/" + count + "/" + length;

            var content = JsonConvert.SerializeObject(new List<string>()
                {"The required service currently seems to be down."});

            try
            {
                content = await Client.GetStringAsync(url);
            }
            catch
            {
                // ignored
            }

            return JsonConvert.DeserializeObject<List<string>>(content);
        }

        public string GetBaseUrl()
        {
            var request = this.Request;

            var host = request.Host.ToUriComponent();

            var pathBase = request.PathBase.ToUriComponent();

            return $"{request.Scheme}://{host}{pathBase}";
        }

        public enum LoremIpsumGeneratorType
        {
            Static,
            Dynamic
        }
    }
}
