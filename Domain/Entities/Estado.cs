using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Estado : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Contrato> Contratos { get; set; }
}
