using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRol
    {
        public int IdUserFk { get; set; } // 2611
        public User Users { get; set; }
        public int IdRolFk { get; set; }
        public Rol Rols { get; set; }
    }
}