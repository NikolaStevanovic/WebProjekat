using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotekaController : ControllerBase
    {
        public BibliotekaContext Context { get; set ;}
        public BibliotekaController(BibliotekaContext context)
        {
            Context=context;
        }

        
        //[EnableCors("CORS")]
        [Route("PreuzmiBiblioteke")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi()
        {
            try
            {
                return Ok(await Context.Biblioteke.Select( p => new{ p.ID, p.Naziv }).ToListAsync() );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
