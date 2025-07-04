using DiplomskiBackend.Database;
using DiplomskiBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomskiBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LektorController : ControllerBase
    {
        private readonly DiplomskiDbContext dbContext;

        public LektorController(DiplomskiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]   

        public IActionResult VratiSveLektore()
        {
            var sviLektori=dbContext.Lektor.ToList();

            return Ok(sviLektori);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult vratiLektoraId(Guid id)
        {
            var lektor=dbContext.Lektor.Find(id);

            if(lektor is null)
            {
                return NotFound();
            }
            return Ok(lektor);
        }

        [HttpPost]
        public IActionResult DodajLektora(DodajLektoraDto dodajLektoraDto)
        {

            var lektorEntity = new Lektor()
            {
                Ime = dodajLektoraDto.Ime,
                Prezime = dodajLektoraDto.Prezime,
                Email = dodajLektoraDto.Email
            };

            dbContext.Lektor.Add(lektorEntity);
            dbContext.SaveChanges();

            return Ok(lektorEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult AzurirajLektora(Guid id,AzurirajLektoraDto azurirajLektoraDto)
        {
            var lektor = dbContext.Lektor.Find(id);

            if(lektor is null)
            {
                return NotFound();
            }

            lektor.Ime = azurirajLektoraDto.Ime;
            lektor.Prezime = azurirajLektoraDto.Prezime;
            lektor.Email = azurirajLektoraDto.Email;

            dbContext.SaveChanges();
            return Ok(lektor);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult obrisiLektora(Guid id)
        {
            var lektor = dbContext.Lektor.Find(id);

            if(lektor is null)
            {
                return NotFound();
            }

            dbContext.Lektor.Remove(lektor);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
