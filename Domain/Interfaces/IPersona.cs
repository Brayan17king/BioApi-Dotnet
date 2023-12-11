using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersona : IGenericRepository<Persona>
    {
        Task<List<Persona>> ObtenerTodosEmpleadosAsync();
        Task<List<Persona>> ObtenerVigilantesAsync();
        Task<List<Persona>> ObtenerClientesPorCiudadAsync(string nombreCiudad);
        Task<List<Persona>> ObtenerEmpleadosPorCiudadesAsync(List<string> nombresCiudades);
        Task<List<Persona>> ObtenerClientesConAntiguedadMayorA5AniosAsync();
    }

}