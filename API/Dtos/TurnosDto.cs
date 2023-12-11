using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class TurnosDto
{
    public int Id { get; set; }
    public string NombreTurno { get; set; }
    public DateTime HoraTurnoI { get; set; }
    public DateTime HoraTurnoF { get; set; }
}