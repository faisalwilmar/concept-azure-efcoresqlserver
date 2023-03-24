using Concept.Azure.EfCoreSqlServer.DataAccess.DataContext;
using Concept.Azure.EfCoreSqlServer.DataAccess.Model;
using Concept.Azure.EfCoreSqlServer.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Concept.Azure.EfCoreSqlServer.FrontEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BiomeController : ControllerBase
    {
        // This controller is example for Repository Pattern

        private readonly ILogger<BiomeController> _logger;
        private readonly IRepository<BiomeCategory> repo;

        public BiomeController(ILogger<BiomeController> logger, SafariDataContext db)
        {
            _logger = logger;
            this.repo = new BiomeCategoryRepository(db);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBiome()
        {
            var res = await repo.GetItems();
            return new OkObjectResult(res);
        }

        [HttpGet]
        [Route("{biomeId}")]
        public async Task<IActionResult> GetBiomeById(string biomeId)
        {

            var res = await repo.GetItemsById(biomeId);
            return new OkObjectResult(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBiome([FromBody] BiomeCategory dto)
        {
            repo.InsertItem(dto);
            await repo.Save();
            return new OkResult();
        }

        [HttpPut]
        [Route("{biomeId}")]
        public async Task<IActionResult> UpdateBiome([FromBody] BiomeCategory dto, string biomeId)
        {
            try
            {
                dto.Id = new Guid(biomeId);
                await repo.UpdateItem(dto);
                await repo.Save();

                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("{biomeId}")]
        public async Task<IActionResult> DeleteBiomeById(string biomeId)
        {
            try
            {
                await repo.DeleteItem(biomeId);
                await repo.Save();

                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
