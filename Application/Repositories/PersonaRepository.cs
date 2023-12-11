using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using Persistence.Data;

namespace Application.Repositories
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly BackEndContext _context;

        public PersonaRepository(BackEndContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Persona>> ObtenerTodosEmpleadosAsync()
        {
            return await _context.Personas
                .Where(p => p.TipoPersonas.Descripcion == "Empleado")
                .ToListAsync();
        }

        public async Task<List<Persona>> ObtenerVigilantesAsync()
        {
            return await _context.Personas
                .Where(p => p.TipoPersonas.Descripcion == "Empleado" && p.CategoriaPersonas.NombreCategoria == "Vigilante")
                .ToListAsync();
        }

        public async Task<List<Persona>> ObtenerClientesPorCiudadAsync(string nombreCiudad)
        {
            return await _context.Personas
                .Where(p => p.TipoPersonas.Descripcion == "Clientes" && p.Ciudades.NombreCiudad == "Bucaramanga")
                .ToListAsync();
        }

        public async Task<List<Persona>> ObtenerEmpleadosPorCiudadesAsync(List<string> nombresCiudades)
        {
            return await _context.Personas
                .Where(p => p.TipoPersonas.Descripcion == "Empleado" && nombresCiudades.Contains(p.Ciudades.NombreCiudad, StringComparer.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<List<Persona>> ObtenerClientesConAntiguedadMayorA5AniosAsync()
        {
            var fechaLimite = DateOnly.FromDateTime(DateTime.Now.AddYears(-5));

            return await _context.Personas
                .Where(p => p.TipoPersonas.Descripcion == "Cliente" &&
                            (DateOnly)p.DateReg < fechaLimite)
                .ToListAsync();
        }
    }
}