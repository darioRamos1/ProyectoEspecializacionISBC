using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEspecializacionISBC.Entidades;

namespace ProyectoEspecializacionISBC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarjetaController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;

    public TarjetaController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost("crearTarjeta")]
    public async Task<ActionResult> CrearTarjeta(TarjetaCredito tc)
    {
        try
        {
            dbContext.Add(tc);
            await dbContext.SaveChangesAsync();
            return Ok(tc);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ConsultarTarjetas")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var listTarjetas = await dbContext.TarjetaCreditos.ToListAsync();
            return Ok(listTarjetas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("ActualizarTarjeta/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
    {
        try
        {
            if (id != tarjeta.id) { return NotFound(); }
            dbContext.Update(tarjeta);
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "la tarjeta fue actualizada  con exito " });

        }


        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }

    }

    [HttpDelete("EliminarTarjeta/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var tarjeta = await dbContext.TarjetaCreditos.FindAsync(id);
            if (tarjeta == null) { return NotFound(); }
            dbContext.Remove(tarjeta);
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "la tarjeta fue eliminada con exito" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }   
    }

}
