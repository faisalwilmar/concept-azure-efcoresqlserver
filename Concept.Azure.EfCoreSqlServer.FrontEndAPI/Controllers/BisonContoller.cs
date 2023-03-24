using Concept.Azure.EfCoreSqlServer.DataAccess.DataContext;
using Concept.Azure.EfCoreSqlServer.DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Concept.Azure.EfCoreSqlServer.FrontEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BisonController : ControllerBase
    {
        private readonly ILogger<BisonController> _logger;
        private readonly SafariDataContext db;

        public BisonController(ILogger<BisonController> logger, SafariDataContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await db.Bison.ToArrayAsync();
            return new OkObjectResult(res);
        }

        [HttpGet]
        [Route("{bisonId}")]
        public async Task<IActionResult> GetById(string bisonId)
        {
            var res = await db.Bison.FindAsync(new Guid(bisonId));
            if (res != null)
            {
                return new OkObjectResult(res);
            } else
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBison([FromBody] Bison dto)
        {
            dto.Id = Guid.NewGuid();
            db.Entry<Bison>(dto).State = EntityState.Added;
            EntityEntry<Bison> entry = db.Bison.Add(dto);
            await db.SaveChangesAsync();

            return new OkObjectResult(entry.Entity);
        }

        [HttpPut]
        [Route("{bisonId}")]
        public async Task<IActionResult> UpdateBison([FromBody] Bison dto, string bisonId)
        {
            var currentBison = await db.Bison.FindAsync(new Guid(bisonId));
            if (currentBison != null)
            {
                db.Entry(currentBison).State = EntityState.Modified;

                currentBison.Name = dto.Name;

                db.Entry(currentBison).CurrentValues.SetValues(currentBison);
                await db.SaveChangesAsync();

                return new OkObjectResult(currentBison);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpDelete]
        [Route("{bisonId}")]
        public async Task<IActionResult> DeleteBisonById(string bisonId)
        {
            var currentBison = await db.Bison.FindAsync(new Guid(bisonId));
            if (currentBison != null)
            {
                EntityEntry<Bison> entry = db.Bison.Remove(currentBison);
                await db.SaveChangesAsync();

                return new OkResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
