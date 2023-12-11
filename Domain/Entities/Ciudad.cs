using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }
    public int IdDepartamentoFk { get; set; }
    public Departamento Departamentos { get; set; }
    public ICollection<Persona> Personas { get; set; }
}
