using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ContactoPersona : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdPersonaFK { get; set; }
    public Persona Personas { get; set; }
    public int IdTipoContactoFk { get; set; }
    public TipoContacto TipoContactos { get; set; }
}
