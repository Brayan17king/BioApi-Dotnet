using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ContactoPersonaDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int IdPersonaFK { get; set; }
    public int IdTipoContactoFk { get; set; }
}