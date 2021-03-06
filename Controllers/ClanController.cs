using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClanController : ControllerBase
    {
        public BibliotekaContext Context { get; set ;}
        public ClanController(BibliotekaContext context)
        {
            Context=context;
        }

        [Route("PreuzmiClana/{clanskaKarta}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClana (int clanskaKarta)
        {
            if(clanskaKarta < 100 || clanskaKarta > 999)
                return BadRequest("Pogresna vrednost clanske karte");

            var x = Context.Clanovi.Where(p => p.ClanskaKarta == clanskaKarta).FirstOrDefault();
            if(x == null)
                return BadRequest("Ne postoji clan sa izabranom clanskom kartom");

            var clanovi = Context.Clanovi
            .Include(p => p.Biblioteka)
            .Where(p => p.ClanskaKarta == clanskaKarta);

            var clan = await clanovi.ToListAsync();
            return Ok(
                clan.Select(p =>
                new
                { 
                    ID=p.ID,
                    ClanskaKarta = p.ClanskaKarta,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Biblioteka=p.Biblioteka
                }).ToList()
            );


        }

        [Route("DodajClana/{clKarta}/{ime}/{prezime}/{biblioteka}")]
        [HttpPost]
        public async Task<ActionResult> DodajClana(int clKarta, string ime, string prezime, int biblioteka)
        {
            bool isDigitPresent = ime.Any(c => char.IsDigit(c));
            bool isDigitPresent2 = prezime.Any(c => char.IsDigit(c));

            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 30 || isDigitPresent==true)
                return BadRequest("Pogresno ime");

            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 30  || isDigitPresent2==true)
                return BadRequest("Pogresno prezime");  

            if(clKarta < 100 || clKarta > 999)
                return BadRequest("Pogresna vrednost clanske karte");    

            var bibl = await Context.Biblioteke.Where(p => p.ID == biblioteka).FirstOrDefaultAsync();
            if(bibl == null)
                    return BadRequest("Biblioteka ne postoji");

            try{
                Clan c = new Clan
                {
                    ClanskaKarta = clKarta,
                    Ime = ime,
                    Prezime = prezime,
                    Biblioteka = bibl
                };
                Context.Clanovi.Add(c);
                await Context.SaveChangesAsync();
                return Ok("Clan je dodat");    
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }

        }
        [Route("PromeniClana")]
        [HttpPut]
        public async Task<ActionResult> PromeniClana(int clKarta, string ime, string prezime, int biblioteka)
        {
            bool isDigitPresent = ime.Any(c => char.IsDigit(c));
            bool isDigitPresent2 = prezime.Any(c => char.IsDigit(c));

            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 30 || isDigitPresent==true)
                return BadRequest("Pogresno ime");

            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 30  || isDigitPresent2==true)
                return BadRequest("Pogresno prezime");  

            if(clKarta < 100 || clKarta > 999)
                return BadRequest("Pogresna vrednost clanske karte");    

            var bibl = await Context.Biblioteke.Where(p => p.ID == biblioteka).FirstOrDefaultAsync();
            if(bibl == null)
                    return BadRequest("Biblioteka ne postoji");

            try
            {
                var clan = Context.Clanovi.Where( p => p.ClanskaKarta == clKarta ).FirstOrDefault();
                if(clan != null)
                {
                    clan.Ime=ime;
                    clan.Prezime=prezime;
                    clan.Biblioteka=bibl;
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno promenjen clan sa ID: "+clan.ID);
                }
                else
                    return BadRequest("Clan nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("IzbrisiClana/{ClanskaKarta}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiClana(int ClanskaKarta)
        {
            if(ClanskaKarta < 100 || ClanskaKarta > 999)
                return BadRequest("Pogresna vrednost clanske karte");  

            var clan = Context.Clanovi.Where( p => p.ClanskaKarta == ClanskaKarta ).FirstOrDefault();
            try
            {
                if(clan != null)
                {
                    Context.Clanovi.Remove(clan);
                    await Context.SaveChangesAsync();
                    return Ok("Izbrisan clan sa ID: "+clan.ID);

                }
                else   
                    return BadRequest("Clan nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
