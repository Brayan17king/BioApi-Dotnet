using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ContratoDto
{
    public int Id { get; set; }
    public DateOnly FechaContrato { get; set; }
    public DateOnly FechaFin { get; set; }
    public int IdClientesFk { get; set; }
    public int IdEmpleadosFk { get; set; }
    public int IdEstadoFK { get; set; }
}