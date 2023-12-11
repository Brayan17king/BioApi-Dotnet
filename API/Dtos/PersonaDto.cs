using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class PersonaDto
{
    public int Id { get; set; }
    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public DateOnly DateReg { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public int IdCategoriaPersonaFk { get; set; }
    public int IdCiudadFk { get; set; }
}