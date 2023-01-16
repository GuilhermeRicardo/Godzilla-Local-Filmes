using BlockbusterApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlockbusterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        // GET

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetMoviesAsync(
            [FromServices] AppDataContext context)
        {
            var movies = await context
                .Movies
                .AsNoTracking()
                .ToListAsync();
            return movies == null
                ? NotFound() 
                : Ok(movies);
        }

        // GET - Search

        [HttpGet]
        [Route("search/{keyword}")]
        public async Task<IActionResult> GetSearch(
            [FromServices] AppDataContext context,
            [FromRoute] string keyword)
        {
            var search = await context
                .Movies
                .Where(x => x.titulo.Contains(keyword))
                .AsNoTracking()
                .ToListAsync();
            return search == null
                ? NotFound()
                : Ok(search);
        }

    }
}
