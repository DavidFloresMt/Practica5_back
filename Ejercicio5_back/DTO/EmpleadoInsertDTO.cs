using Ejercicio5_back.Models;

namespace Ejercicio5_back.DTO
{
    public class EmpleadoInsertDTO
    {
        public string NumeroNomina { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public int IdEstado { get; set; }
        public CatEntidadFederativa Id { get; set; }
    }
}
