using Capacitacion.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Capacitacion.WebApi.Context;

public class ColegioDbContext : DbContext
{
    public required DbSet<Estudiante> Estudiantes { get; set; }
    public required DbSet<Aula> Aulas { get; set; }

    public ColegioDbContext(DbContextOptions options) : base(options)
    {
        
    }



}