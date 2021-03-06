using DTOs.Files;
using Interfaces.FileConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileConfigurationController : Controller
    {
        public readonly IFileConfigurationService _fileService;
        public FileConfigurationController(IFileConfigurationService fileService) {
            _fileService = fileService;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id) => Json(_fileService.GetConfiguration(id));

        [HttpPost]
        public JsonResult Create([FromBody]FileConfigurationDto fileConfig) => Json(_fileService.Create(fileConfig));

        [HttpPut]
        public JsonResult Update([FromBody]FileConfigurationDto fileConfig) => Json(_fileService.Update(fileConfig));

        [HttpDelete("{id}")]
        public JsonResult Delete(int id) => Json(_fileService.Delete(id));
    }
}