using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class DireccionPersonaDto
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public int IdPersonaFK { get; set; }
    public int IdTipoDireccionFk { get; set; }
}