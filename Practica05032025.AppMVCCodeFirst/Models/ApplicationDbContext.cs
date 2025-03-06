using Microsoft.EntityFrameworkCore;

namespace Practica05032025.AppMVCCodeFirst.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
