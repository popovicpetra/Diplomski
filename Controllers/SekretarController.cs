using DiplomskiBackend.Database;
using DiplomskiBackend.Model.EditorEntitet;
using DiplomskiBackend.Model.SekretarEntitet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomskiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SekretarController : ControllerBase
    {

        private readonly DiplomskiDbContext diplomskiDbContext;

        public SekretarController(DiplomskiDbContext diplomskiDbContext)
        {
            this.diplomskiDbContext = diplomskiDbContext;
        }

        [HttpGet]
        public IActionResult VratiSveSekretare()
        {

            var sekretari = diplomskiDbContext.TehnickiSekretar.Select(sekretar => new TehnickiSekretarDto { 
             Id = sekretar.Id,
             Ime = sekretar.Ime,
             Prezime = sekretar.Prezime,
             Email = sekretar.Email,
            }).ToList();
            return Ok(sekretari);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult VratiSekretara(Guid id)
        {

            var sekretar = diplomskiDbContext.TehnickiSekretar.Find(id);
            if (sekretar == null)
            {
                return NotFound();
            }
            var sekretarDto = new TehnickiSekretarDto()
            {
                Id = sekretar.Id,
                Ime = sekretar.Ime,
                Prezime = sekretar.Prezime,
                Email = sekretar.Email,
            };
            return Ok(sekretarDto);

        }

        [HttpPost]
        public IActionResult DodajSekretara(DodajSekretaraDto dodajSekretaraDto)
        {

            var sekretar = new TehnickiSekretar()
            {
                Ime = dodajSekretaraDto.Ime,
                Prezime = dodajSekretaraDto.Prezime,
                Email = dodajSekretaraDto.Email
            };

            diplomskiDbContext.TehnickiSekretar.Add(sekretar);
            diplomskiDbContext.SaveChanges();


            var sekretarDto = new TehnickiSekretarDto
            {
                Id = sekretar.Id,
                Ime = sekretar.Ime,
                Prezime = sekretar.Prezime,
                Email = sekretar.Email
            };
            return CreatedAtAction(nameof(VratiSekretara), new { id = sekretar.Id }, sekretarDto);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult AzurirajSekretara(Guid id, [FromBody] AzurirajSekretaraDto azurirajSekretaraDto)
        {

            var sekretar = diplomskiDbContext.TehnickiSekretar.Find(id);

            if (sekretar == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(azurirajSekretaraDto.Ime))
            {
                sekretar.Ime = azurirajSekretaraDto.Ime;
            }
            if (!string.IsNullOrWhiteSpace(azurirajSekretaraDto.Prezime))
            {

                sekretar.Prezime = azurirajSekretaraDto.Prezime;
            }

            if (!string.IsNullOrWhiteSpace(azurirajSekretaraDto.Email))
            {
                sekretar.Email = azurirajSekretaraDto.Email;
            }


            diplomskiDbContext.SaveChanges();

            return Ok(sekretar);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult ObrisiSekretara(Guid id)
        {
            var sekretar = diplomskiDbContext.TehnickiSekretar.Find(id);
            if (sekretar == null)
            {
                return NotFound();
            }
            diplomskiDbContext.TehnickiSekretar.Remove(sekretar);
            diplomskiDbContext.SaveChanges();
            return NoContent();
        }
    }

}
