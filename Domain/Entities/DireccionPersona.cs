using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class DireccionPersona : BaseEntity
{
    public string Direccion { get; set; }
    public int IdPersonaFK { get; set; }
    public Persona Personas { get; set; }
    public int IdTipoDireccionFk { get; set; }
    public TipoDireccion TipoDirecciones { get; set; }
}
