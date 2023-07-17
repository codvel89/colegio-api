using Capacitacion.Modelos;
using Capacitacion.WebApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class AulasController : ControllerBase
{
    private readonly ColegioDbContext db;

    public AulasController(ColegioDbContext db)
    {
        this.db = db;
    }


    [HttpGet]
    public ActionResult<List<Aula>> GetAulas()
    {
        var aulas = db.Aulas.ToList();
        return Ok(aulas);
    }

    [HttpGet]
    [Route("{Id:int}")]
    public ActionResult<Aula> GetAula([FromRoute] int Id)
    {
        var aula = db.Aulas.Find(Id);
        return Ok(aula);
    }

    [HttpPost]
    public ActionResult<Aula> PostAula([FromBody] Aula aula)
    {

        db.Aulas.Add(aula);
        db.SaveChanges();
        return Ok(aula);
    }
    
    [HttpPut]
    [Route("{Id:int}")]
    public ActionResult<Aula> PutAula([FromRoute] int Id, [FromBody] Aula aula)
    {

        if(!db.Aulas.Any(x => x.Id == Id))
            return NoContent();

        aula.Id = Id;
        db.Aulas.Entry(aula).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(aula);
    }

    [HttpDelete]
    [Route("{Id:int}")]
    public ActionResult DeleteAula([FromRoute] int Id)
    {
        if(!db.Aulas.Any(x => x.Id == Id))
            return NoContent();

        var aula = db.Aulas.Find(Id)!;

        db.Aulas.Remove(aula);
        db.SaveChanges();

        return Ok();
    }

    [HttpGet]
    [Route("{Id:int}/Estudiantes")]
    public ActionResult<List<Estudiante>> ObtenerEstudiantesDeAula([FromRoute] int Id)
    {
        var aula = db.Aulas.Include(x => x.Estudiantes).Single(x => x.Id == Id)!;
        return Ok(aula.Estudiantes);
    }

}