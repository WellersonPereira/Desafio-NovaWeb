using Desafio_Backend_Novaweb.Data;
using Desafio_Backend_Novaweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio_Backend_Novaweb.Controllers
{
    [Route("api/Contato")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Contato>>> TodosContatos (
            [FromServices]ContatoContext context)
        {
            var contatos = await context.Contatos
                .ToListAsync();
            return contatos;
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> CriarContato (
            [FromServices]ContatoContext context, 
            [FromBody] Contato model)
        {
            if (ModelState.IsValid)
            {
                context.Contatos.Add(model);
                await context.SaveChangesAsync();
                return Ok(model.ContatoID);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contato>> ObterContatoPorId(
            [FromServices] ContatoContext context
            , int id)
        {
            var contato = await context.Contatos
                .FirstOrDefaultAsync(x => x.ContatoID == id);
            if (contato != null)
            {
                return Ok(contato);
            }
            else
                return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Contato>> ApagarContatoPorId(int id,
            [FromServices] ContatoContext context)
        {
            try
            {
                var contato = await context.Contatos
                    .FirstOrDefaultAsync(x => x.ContatoID == id);
                context.Remove(contato);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception)
            {
                return NotFound();
                throw;
            }

        }

        [HttpPut]
        public async Task<ActionResult<Contato>> AlterarContato(
            [FromServices] ContatoContext context,
            [FromBody] Contato model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Contatos.Update(model);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                    return BadRequest(ModelState);
            }
            catch
            {
                return NotFound();
                throw;
            }
        }
    }
}
