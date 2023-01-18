using BlockbusterApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics.Metrics;

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



            //var movies = await (from mo in context.Movies
            //                    join re in context.Rental on mo.Id equals re.MovieId
            //                    where mo.Id == re.MovieId
            //                    select new
            //                    {
            //                        Id = mo.Id,
            //                        Titulo = mo.titulo,
            //                        Diretor = mo.diretor,
            //                        estoque = mo.estoque,                                        
            //                    })

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

        [HttpGet]
        [Route("availability/{id}")]
        public async Task<IActionResult> GetAvailability(
        [FromServices] AppDataContext context,
        [FromRoute] int id)
        {
            var availability = await context
                .Movies
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var count = await context
                .Rental
                .Where(x => x.MovieId == id)
                .CountAsync();

            return availability == null
                ? NotFound()
                : Ok(availability.estoque - count);
        }

    }
}
