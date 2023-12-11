using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Interfaces;
using Persistance.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BackEndContext _context;
        private ICiudad _Ciudades; 
        private ICategoriaPersona _CategoriaPersonas;
        private IContactoPersona _ContactoPersonas;
        private IContrato _Contratos;
        private IDepartamento _Departamentos;
        private IEstado _Estados;
        private IDireccionPersona _DireccionPersonas;
        private IPersona _Personas;
        private IProgramacion _Programacions;
        private ITipoContacto _TipoContactos;
        private IPais _Paises;
        private ITipoDireccion _TipoDireccions;
        private ITipoPersona _TipoPersonas;
        private IRefreshToken _RefreshTokens;
        private ITurnos _Turnos;
        private IRol _Rols;
        private IUser _Users;

        public UnitOfWork(BackEndContext context)
        {
            _context = context;
        }

        public ICiudad Ciudades 
        {
            get
            {
                if (_Ciudades == null)
                {
                    _Ciudades = new CiudadRepository(_context);
                }
                return _Ciudades;
            }
        }
        public ICategoriaPersona CategoriaPersonas 
        {
            get
            {
                if (_CategoriaPersonas == null)
                {
                    _CategoriaPersonas = new CategoriaPersonaRepository(_context);
                }
                return _CategoriaPersonas;
            }
        }
        public IContactoPersona ContactoPersonas 
        {
            get
            {
                if (_ContactoPersonas == null)
                {
                    _ContactoPersonas = new ContactoPersonaRepository(_context);
                }
                return _ContactoPersonas;
            }
        }
        public IContrato Contratos 
        {
            get
            {
                if (_Contratos == null)
                {
                    _Contratos = new ContratoRepository(_context);
                }
                return _Contratos;
            }
        }
        public IProgramacion Programacions 
        {
            get
            {
                if (_Programacions == null)
                {
                    _Programacions = new ProgramacionRepository(_context);
                }
                return _Programacions;
            }
        }
        public IEstado Estados 
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(_context);
                }
                return _Estados;
            }
        }
        public IDepartamento Departamentos 
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(_context);
                }
                return _Departamentos;
            }
        }
        public IDireccionPersona DireccionPersonas 
        {
            get
            {
                if (_DireccionPersonas == null)
                {
                    _DireccionPersonas = new DireccionPersonaRepository(_context);
                }
                return _DireccionPersonas;
            }
        }

        public ITurnos Turnos
        {
            get
            {
                if (_Turnos == null)
                {
                    _Turnos = new TurnosRepository(_context);
                }
                return _Turnos;
            }
        }
        public ITipoContacto TipoContactos 
        {
            get
            {
                if (_TipoContactos == null)
                {
                    _TipoContactos = new TipoContactoRepository(_context);
                }
                return _TipoContactos;
            }
        }
        public ITipoDireccion TipoDireccions 
        {
            get
            {
                if (_TipoDireccions == null)
                {
                    _TipoDireccions = new TipoDireccionRepository(_context);
                }
                return _TipoDireccions;
            }
        }

        public ITipoPersona TipoPersonas 
        {
            get
            {
                if (_TipoPersonas == null)
                {
                    _TipoPersonas = new TipoPersonaRepository(_context);
                }
                return _TipoPersonas;
            }
        }
        public IPais Paises 
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(_context);
                }
                return _Paises;
            }
        }
        public IPersona Personas 
        {
            get
            {
                if (_Personas == null)
                {
                    _Personas = new PersonaRepository(_context);
                }
                return _Personas;
            }
        }
       
        public IRefreshToken RefreshTokens
        {
            get
            {
                if (_RefreshTokens == null)
                {
                    _RefreshTokens = new RefreshTokenRepository(_context);
                }
                return _RefreshTokens;
            }
        }

        public IRol Rols
        {
            get
            {
                if (_Rols == null)
                {
                    _Rols = new RolRepository(_context);
                }
                return _Rols;
            }
        }

        public IUser Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(_context);
                }
                return _Users;
            }
        }

        public Task<int> SaveAsync() 
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}