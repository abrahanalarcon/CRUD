using System;
using System.Collections.Generic;

namespace CRUDPRUEBA3.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int? IdDoctor { get; set; }

    public int Edad { get; set; }

    public string Genero { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual Doctor? IdDoctorNavigation { get; set; }
}
