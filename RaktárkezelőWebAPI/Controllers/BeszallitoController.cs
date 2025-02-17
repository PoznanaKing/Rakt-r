using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaktárkezelőWebAPI.Models;

namespace RaktárkezelőWebAPI.Controllers
{
    [Route("Beszallito")]
    [ApiController]
    public class BeszallitoController : ControllerBase
    {
        private readonly RaktarContext _context;

        public BeszallitoController(RaktarContext context)
        {
            _context = context;
        }

        [HttpPost("UploadBeszallito")]
        public async Task<ActionResult> UploadBeszallito(UploadBeszallitoDTO uploadBeszallitoDTO)
        {
            var beszallito = new Beszallito
            {
                Nev=uploadBeszallitoDTO.name,
            };
            if (beszallito!=null)
            {
                await _context.Beszallitos.AddAsync(beszallito);
                await _context.SaveChangesAsync();
                return StatusCode(201, beszallito);
            }
            return BadRequest();
        }
        [HttpGet("GetBeszallitok")]
        public async Task<ActionResult> GetBeszallitok()
        {
            var beszallitok = await _context.Beszallitos.ToListAsync();
            if (beszallitok != null)
            {
                return Ok(new { result = beszallitok });
            }
            return NotFound(new { result = beszallitok, message = "Üres az adatbázis." });
        }
        [HttpDelete("DeleteBeszallito")]
        public async Task<ActionResult> DeleteBeszallito(DeleteBeszallitoDTO deleteBeszallitoDTO)
        {
            var deleting = await _context.Beszallitos.FirstOrDefaultAsync(x=>x.BeszallitoId==deleteBeszallitoDTO.id);
            if (deleting != null)
            {
                _context.Beszallitos.Remove(deleting);
                await _context.SaveChangesAsync();
                return StatusCode(201, new { message = "Sikeres törlés" });
            }
            return BadRequest(new {message="Sikertelen törlés"});
        }
        [HttpPut("EditBeszallito")]
        public async Task<ActionResult> EditBeszallito(EditBeszallitoDTO editBeszallitoDTO)
        {
            var beszallito = await _context.Beszallitos.FirstOrDefaultAsync(x => x.BeszallitoId == editBeszallitoDTO.id);
            if(beszallito != null)
            {
                beszallito.Nev=editBeszallitoDTO.name;
                _context.Beszallitos.Update(beszallito);
                await _context.SaveChangesAsync();
                return Ok(new {result=beszallito,message="Sikeres módosítás."});
            }
            return NotFound(new {message="Sikertelen módosítás."});
        }
    }
}
