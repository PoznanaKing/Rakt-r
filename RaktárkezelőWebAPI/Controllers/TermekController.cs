using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaktárkezelőWebAPI.Models;

namespace RaktárkezelőWebAPI.Controllers
{
    [Route("Termek")]
    [ApiController]
    public class TermekController : ControllerBase
    {
        private readonly RaktarContext _context;

        public TermekController(RaktarContext context)
        {
            _context = context;
        }

        [HttpPost("UploadTermek")]
        public async Task<ActionResult> UploadTermek(UploadTermekDTO uploadTermekDTO)
        {
            var newTermek = new Termek
            {
                Nev = uploadTermekDTO.name,
                Ar = uploadTermekDTO.ar,
                BeszallitoId = uploadTermekDTO.beszallitoid,
            };
            if (newTermek != null)
            {
                _context.Termeks.Add(newTermek);
                await _context.SaveChangesAsync();
                return StatusCode(201, new { message = "Sikeres feltöltés." });
            }
            return BadRequest(new { message = "Sikertelen feltöltés" });
        }
        [HttpGet("GetAllTermekWithBeszallito")]
        public async Task<ActionResult> GetTermekWithBeszallito()
        {
            var termekek= await _context.Termeks.ToListAsync();
            if (termekek != null)
            {
                return Ok(termekek);
            }
            return NotFound(new { message = "Üres az adatbázis" });
        }
        [HttpDelete("DeleteTermek")]
        public async Task<ActionResult> DeleteTermek(DeleteTermekDTO deleteTermekDTO)
        {
            var deleting = await _context.Termeks.FirstOrDefaultAsync(x=>x.TermekId==deleteTermekDTO.id);
            if (deleting != null)
            {
                _context.Termeks.Remove(deleting);
                await _context.SaveChangesAsync();
                return StatusCode(201, new { message = "Sikeres törlés!" });
            }
            return NotFound(new { message = "Sikertelen törlés" });
        }
        [HttpPut("EditTermek")]
        public async Task<ActionResult> EditTermek(EditTermekDTO editTermekDTO)
        {
            var edit = await _context.Termeks.FirstOrDefaultAsync(x=>x.TermekId==editTermekDTO.id);
            if (edit!=null)
            {
                edit.Ar = editTermekDTO.ar;
                edit.Nev=editTermekDTO.name;
                edit.BeszallitoId = editTermekDTO.beszallitoid;
                _context.Termeks.Update(edit);
                await _context.SaveChangesAsync();
                return Ok(edit);
            }
            return NotFound(new {message="Sikertelen módosítás"});
        }
    }
}
