using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ejercicio5_back.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string NumeroNomina { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public int IdEstado { get; set; }
    public virtual CatEntidadFederativa IdEstadoNavigation { get; set; } = null!;
}
