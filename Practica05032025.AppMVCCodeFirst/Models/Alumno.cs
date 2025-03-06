
namespace Practica05032025.AppMVCCodeFirst.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Direccion {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public short YearEstudio {  get; set; }
    }
}
