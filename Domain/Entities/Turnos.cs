using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Turnos : BaseEntity
{
    public string NombreTurno { get; set; }
    public DateTime HoraTurnoI { get; set; }
    public DateTime HoraTurnoF { get; set; }
    public ICollection<Programacion> Programacions { get; set; }
}
