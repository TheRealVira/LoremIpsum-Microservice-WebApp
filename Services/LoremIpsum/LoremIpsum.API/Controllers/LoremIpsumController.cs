using System;
using System.Collections.Generic;
using LoremIpsumService.Generators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoremIpsumService.Controllers
{
    [Route("api/lipsum_generator")]
    [ApiController]
    [Produces("application/json")]
    public class LoremIpsumController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{generatorType}/{count}/{length}")]
        public ActionResult<string> Get(string generatorType,int count, int length)
        {
            var toRet = new List<object>();
            if (!Enum.TryParse(generatorType, true, out LoremIpsumGeneratorType currentGeneratorType))
                return BadRequest(toRet);

            for (var i = 0; i < count; i++)
            {
                switch (currentGeneratorType)
                {
                    case LoremIpsumGeneratorType.Static:
                        toRet.Add(JsonConvert.SerializeObject(new StaticExampleGenerator().GenerateText(length)));
                        break;
                    case LoremIpsumGeneratorType.Dynamic:
                        toRet.Add(JsonConvert.SerializeObject(
                            new DynamicExampleGenerator().GenerateText(length)));
                        break;
                    default:
                        break;
                }
            }

            return Ok(JsonConvert.SerializeObject(toRet));
        }
    }
}
