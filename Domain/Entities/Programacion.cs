using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Programacion : BaseEntity
{
    public int IdContratoFk { get; set; }
    public Contrato Contratos { get; set; }
    public int IdTurnoFk { get; set; }
    public Turnos Turnos { get; set; }
    public int IdPersonaFk { get; set; }
    public Persona Personas { get; set; }
}
