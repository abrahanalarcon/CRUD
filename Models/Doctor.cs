using System;
using System.Collections.Generic;

namespace CRUDPRUEBA3.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public string Hospital { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
