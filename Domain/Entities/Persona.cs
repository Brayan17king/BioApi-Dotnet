using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Persona : BaseEntity
{
    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public DateOnly DateReg { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersona TipoPersonas { get; set; }
    public int IdCategoriaPersonaFk { get; set; }
    public CategoriaPersona CategoriaPersonas { get; set; }
    public int IdCiudadFk { get; set; }
    public Ciudad Ciudades { get; set; }
    public ICollection<ContactoPersona> ContactoPersonas { get; set; }
    public ICollection<DireccionPersona> DireccionPersonas { get; set; }
    public ICollection<Programacion> Programacions { get; set; }
    public ICollection<Contrato> Contratos { get; set; }
}
