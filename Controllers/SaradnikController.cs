using DiplomskiBackend.Database;
using DiplomskiBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomskiBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaradnikController : ControllerBase
    {
        private readonly DiplomskiDbContext dbContext;
        public SaradnikController(DiplomskiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult VratiSveSaradnike()
        {
            var sviSaradnici = dbContext.TehnickiSaradnik.ToList();

            return Ok(sviSaradnici);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult vratiSaradnikaId(Guid id)
        {
            var saradnik = dbContext.TehnickiSaradnik.Find(id);

            if (saradnik is null)
            {
                return NotFound();
            }
            return Ok(saradnik);
        }

        [HttpPost]
        public IActionResult DodajSaradnika(DodajSaradnikaDto dodajSaradnikaDto)
        {

            var saradnikEntity = new TehnickiSaradnik()
            {
                Ime = dodajSaradnikaDto.Ime,
                Prezime = dodajSaradnikaDto.Prezime,
                Email = dodajSaradnikaDto.Email
            };

            dbContext.TehnickiSaradnik.Add(saradnikEntity);
            dbContext.SaveChanges();

            return Ok(saradnikEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult AzurirajSaradnika(Guid id, AzurirajSaradnikaDto azurirajSaradnikaDto)
        {
            var saradnik = dbContext.TehnickiSaradnik.Find(id);

            if (saradnik is null)
            {
                return NotFound();
            }

            saradnik.Ime = azurirajSaradnikaDto.Ime;
            saradnik.Prezime = azurirajSaradnikaDto.Prezime;
            saradnik.Email = azurirajSaradnikaDto.Email;

            dbContext.SaveChanges();
            return Ok(saradnik);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult obrisiSaradnika(Guid id)
        {
            var saradnik = dbContext.TehnickiSaradnik.Find(id);

            if (saradnik is null)
            {
                return NotFound();
            }

            dbContext.TehnickiSaradnik.Remove(saradnik);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
