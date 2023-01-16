using BlockbusterApi.Data;
using BlockbusterApi.Models;
using BlockbusterApi.Models.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BlockbusterApi.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        // GET

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDataContext context)
        {
            var rental = await context
                .Rental
                .AsNoTracking()
                .ToListAsync();

            return rental == null
                ? NotFound() 
                : Ok(rental);
        }

        // POST

        [HttpPost]
        [Route("rent")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDataContext context,
            [FromBody] RentInformationDTO Model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Modelo Invalido"
                    }
                });

            var rent = new Rental
            {
                MovieId = Model.MovieId,
                UserId = Model.UserId,
            };


            var availability = await context
                .Movies
                .Where(x => x.Id == rent.MovieId)
                .FirstOrDefaultAsync();


            var count = await context
                .Rental
                .Where(x => x.MovieId == rent.MovieId)
                .CountAsync();


            if (count >= availability.estoque)
            {
                return Forbid();

            }

            //    return BadRequest(new AuthResult()
            //    {
            //        Errors = new List<string>()
            //        {
            //            "Contagem: " + count + ", Estoque: " + availability.estoque
            //        }
            //    });
            //}

            try
            {
                await context.Rental.AddAsync(rent);
                await context.SaveChangesAsync();
                return Created("[controller]/rent", rent);

            }
            catch (System.Exception)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Catch BadRequest"
                    }
                });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var rent = await context
                .Rental
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            try
            {
                context.Rental.Remove(rent);
                await context.SaveChangesAsync();
                return Ok();
            }

            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
