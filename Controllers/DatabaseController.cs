using Capacitacion.WebApi.Context;
using Microsoft.AspNetCore.Mvc;

namespace Capacitacion.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly ColegioDbContext db;

    public DatabaseController(ColegioDbContext db)
    {
        this.db = db;
    }


    
    [HttpPost]
    public ActionResult CrearBaseDatos()
    {

        if(db.Database.CanConnect())
        {
            db.Database.EnsureDeleted();
        }

        db.Database.EnsureCreated();

        return Ok();
    }
     
}
