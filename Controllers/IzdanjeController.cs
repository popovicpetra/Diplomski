using DiplomskiBackend.Database;
using DiplomskiBackend.Model.IzdanjeEntitet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomskiBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IzdanjeController : ControllerBase
    {
        private readonly DiplomskiDbContext diplomskiDbContext;

        public IzdanjeController(DiplomskiDbContext diplomskiDbContext)
        {
            this.diplomskiDbContext = diplomskiDbContext;
        }

        [HttpGet]
        public IActionResult VratiSvaIzdanja()
        {

            var izdanjaDto = diplomskiDbContext.Izdanje.Select(izdanje => new IzdanjeDto
            {
                Id = izdanje.Id,
                Naziv = izdanje.Naziv,
                Datum = izdanje.Datum,
                BrojIzdanja = izdanje.BrojIzdanja,
                Cena = izdanje.Cena

            }).ToList();

            return Ok(izdanjaDto);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult VratiIzdanje(Guid id)
        {

            var izdanje = diplomskiDbContext.Izdanje.Find(id);
            if (izdanje == null)
            {
                return NotFound();
            }
            var izdanjeDto = new IzdanjeDto()
            {
                Id = izdanje.Id,
                Naziv = izdanje.Naziv,
                Datum = izdanje.Datum,
                BrojIzdanja = izdanje.BrojIzdanja,
                Cena = izdanje.Cena
            };
            return Ok(izdanjeDto);

        }

        [HttpPost]
        public IActionResult DodajIzdanje(DodajIzdanjeDto dodajIzdanjeDto)
        {

            var izdanje = new Izdanje()
            {
                Naziv = dodajIzdanjeDto.Naziv,
                Datum = dodajIzdanjeDto.Datum,
                BrojIzdanja = dodajIzdanjeDto.BrojIzdanja,
                Cena = dodajIzdanjeDto.Cena
            };

            diplomskiDbContext.Izdanje.Add(izdanje);
            diplomskiDbContext.SaveChanges();


            var izdanjeDto = new IzdanjeDto
            {
                Id = izdanje.Id,
                Naziv = izdanje.Naziv,
                Datum = izdanje.Datum,
                BrojIzdanja = izdanje.BrojIzdanja,
                Cena = izdanje.Cena
            };
            return CreatedAtAction(nameof(VratiIzdanje), new { id = izdanje.Id }, izdanjeDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult AzurirajIzdanje(Guid id, [FromBody] AzurirajIzdanjeDto azurirajIzdanjeDto)
        {

            var izdanje = diplomskiDbContext.Izdanje.Find(id);

            if (izdanje == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(azurirajIzdanjeDto.Naziv))
            {
                izdanje.Naziv = azurirajIzdanjeDto.Naziv;
            }
            if (azurirajIzdanjeDto.Datum.HasValue)
            {

                izdanje.Datum = azurirajIzdanjeDto.Datum.Value;
            }

            if (azurirajIzdanjeDto.Cena.HasValue)
            {
                izdanje.Cena = azurirajIzdanjeDto.Cena.Value;
            }

            if (azurirajIzdanjeDto.BrojIzdanja.HasValue) {
                izdanje.BrojIzdanja = azurirajIzdanjeDto.BrojIzdanja.Value;
            }


            diplomskiDbContext.SaveChanges();

            return Ok(izdanje);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult ObrisiIzdanje(Guid id)
        {
            var izdanje = diplomskiDbContext.Izdanje.Find(id);
            if (izdanje == null)
            {
                return NotFound();
            }
            diplomskiDbContext.Izdanje.Remove(izdanje);
            diplomskiDbContext.SaveChanges();
            return NoContent();
        }
    }
}
