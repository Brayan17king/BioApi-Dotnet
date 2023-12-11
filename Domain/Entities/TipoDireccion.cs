using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TipoDireccion : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<DireccionPersona> DireccionPersonas { get; set; }
}
