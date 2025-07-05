using System.Linq.Expressions;
using DiplomskiBackend.Database;
using DiplomskiBackend.Model.EditorEntitet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace DiplomskiBackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly DiplomskiDbContext diplomskiDbContext;

        public EditorController(DiplomskiDbContext diplomskiDbContext)
        {
            this.diplomskiDbContext = diplomskiDbContext;
        }

        [HttpGet]
        public IActionResult VratiSveEditore() { 
            
            var editori = diplomskiDbContext.Editor.ToList();
            var editoriDto = new List<EditorDto>();
            foreach (var editor in editori) {
                var editorDto = new EditorDto()
                {
                    Id = editor.Id,
                    Ime = editor.Ime,
                    Prezime = editor.Prezime,
                    Email = editor.Email,
                };
                editoriDto.Add(editorDto);
               
            }

           return Ok(editoriDto);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult VratiEditora(Guid id) {

            var editor = diplomskiDbContext.Editor.Find(id);
            if (editor == null)
            {
                return NotFound();
            }
            var editorDto = new EditorDto()
            {
                Id = editor.Id,
                Ime = editor.Ime,
                Prezime = editor.Prezime,
                Email = editor.Email,
            };
            return Ok(editorDto);

        }

        [HttpPost]
        public IActionResult DodajEditora(DodajEditoraDto dodajEditoraDto) {

            var editor = new Editor()
            {
                Ime = dodajEditoraDto.Ime,
                Prezime = dodajEditoraDto.Prezime,
                Email = dodajEditoraDto.Email
            };

            diplomskiDbContext.Editor.Add(editor);
            diplomskiDbContext.SaveChanges();


            var editorDto = new EditorDto
            {
                Id = editor.Id,
                Ime = editor.Ime,
                Prezime = editor.Prezime,
                Email = editor.Email
            };
            return CreatedAtAction(nameof(VratiEditora), new { id = editor.Id}, editorDto );
        
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult AzurirajEditora(Guid id,[FromBody] AzurirajEditoraDto azurirajEditoraDto) {

            var editor = diplomskiDbContext.Editor.Find(id);
           
            if (editor == null) { 
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(azurirajEditoraDto.Ime)) { 
                editor.Ime= azurirajEditoraDto.Ime;
            }
            if (!string.IsNullOrWhiteSpace(azurirajEditoraDto.Prezime)) { 
            
                editor.Prezime = azurirajEditoraDto.Prezime;
            }

            if (!string.IsNullOrWhiteSpace(azurirajEditoraDto.Email)) { 
                editor.Email= azurirajEditoraDto.Email;
            }


            diplomskiDbContext.SaveChanges();

            return Ok(editor);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult ObrisiEditora(Guid id)
        {
            var editor = diplomskiDbContext.Editor.Find(id);
            if (editor == null)
            {
                return NotFound();
            }
            diplomskiDbContext.Editor.Remove(editor);
            diplomskiDbContext.SaveChanges();
            return NoContent();
        }
    }
}
