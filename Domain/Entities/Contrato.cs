using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Contrato : BaseEntity
{
    public DateOnly FechaContrato { get; set; }
    public DateOnly FechaFin { get; set; }
    public int IdClientesFk { get; set; }
    public int IdEmpleadosFk { get; set; }
    public Persona Personas { get; set; }
    public int IdEstadoFK { get; set; }
    public Estado Estados { get; set; }
    public ICollection<Programacion> Programacions { get; set; }
}
