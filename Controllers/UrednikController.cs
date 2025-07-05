using DiplomskiBackend.Database;
using DiplomskiBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomskiBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrednikController : ControllerBase
    {
        private readonly DiplomskiDbContext dbContext;
        public UrednikController(DiplomskiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult VratiSveUrednike()
        {
            var sviUrednici = dbContext.TehnickiUrednik.ToList();

            return Ok(sviUrednici);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult vratiUrednikaId(Guid id)
        {
            var urednik = dbContext.TehnickiUrednik.Find(id);

            if (urednik is null)
            {
                return NotFound();
            }
            return Ok(urednik);
        }

        [HttpPost]
        public IActionResult DodajUrednika(DodajUrednikaDto dodajUrednikaDto)
        {

            var urednikEntity = new TehnickiUrednik()
            {
                Ime = dodajUrednikaDto.Ime,
                Prezime = dodajUrednikaDto.Prezime,
                Email = dodajUrednikaDto.Email
            };

            dbContext.TehnickiUrednik.Add(urednikEntity);
            dbContext.SaveChanges();

            return Ok(urednikEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult AzurirajUrednika(Guid id, AzurirajUrednikaDto azurirajUrednikaDto)
        {
            var urednik = dbContext.TehnickiUrednik.Find(id);

            if (urednik is null)
            {
                return NotFound();
            }

            urednik.Ime = azurirajUrednikaDto.Ime;
            urednik.Prezime = azurirajUrednikaDto.Prezime;
            urednik.Email = azurirajUrednikaDto.Email;

            dbContext.SaveChanges();
            return Ok(urednik);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult obrisiUrednika(Guid id)
        {
            var urednik = dbContext.TehnickiUrednik.Find(id);

            if (urednik is null)
            {
                return NotFound();
            }

            dbContext.TehnickiUrednik.Remove(urednik);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
