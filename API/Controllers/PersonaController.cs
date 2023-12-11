using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistance.Data;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PersonaController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly BackEndContext _context;

    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper, BackEndContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
    {
        var result = await _unitOfWork.Personas.GetAllAsync();
        return _mapper.Map<List<PersonaDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> Get(int id)
    {
        var result = await _unitOfWork.Personas.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersonaDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Post(PersonaDto resultDto)
    {
        var result = _mapper.Map<Persona>(resultDto);
        _unitOfWork.Personas.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto resultDto)
    {
        if (resultDto.Id == 0)
        {
            resultDto.Id = id;
        }
        if (resultDto.Id != id)
        {
            return NotFound();
        }
        var result = _mapper.Map<Persona>(resultDto);
        resultDto.Id = result.Id;
        _unitOfWork.Personas.Update(result);
        await _unitOfWork.SaveAsync();
        return resultDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Personas.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Personas.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("Empleados")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<Persona>>> ObtenerTodosEmpleados()
    {
        try
        {
            var empleados = await _unitOfWork.Personas.ObtenerTodosEmpleadosAsync();

            if (empleados == null || empleados.Count == 0)
            {
                return NotFound("No se encontraron empleados.");
            }

            return Ok(empleados);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("vigilantes")]
    public async Task<ActionResult<List<Persona>>> ObtenerVigilantes()
    {
        try
        {
            var vigilantes = await _unitOfWork.Personas.ObtenerVigilantesAsync();

            if (vigilantes == null || vigilantes.Count == 0)
            {
                return NotFound("No se encontraron vigilantes.");
            }

            return Ok(vigilantes);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("clientes/{ciudad}")]
    public async Task<ActionResult<List<Persona>>> ObtenerClientesPorCiudad(string ciudad)
    {
        try
        {
            var clientes = await _unitOfWork.Personas.ObtenerClientesPorCiudadAsync(ciudad);

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound($"No se encontraron clientes en la ciudad {ciudad}.");
            }

            return Ok(clientes);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("empleados/ciudades")]
    public async Task<ActionResult<List<Persona>>> ObtenerEmpleadosEnGironYPiedecuesta()
    {
        try
        {
            var ciudades = new List<string> { "Giron", "Piedecuesta" };

            var empleados = await _unitOfWork.Personas.ObtenerEmpleadosPorCiudadesAsync(ciudades);

            if (empleados == null || empleados.Count == 0)
            {
                return NotFound($"No se encontraron empleados en las ciudades especificadas.");
            }

            return Ok(empleados);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("clientes-antiguedad")]
    public async Task<IActionResult> ObtenerClientesAntiguedadMayorA5Anios()
    {
        try
        {
            var clientes = await _unitOfWork.Personas.ObtenerClientesConAntiguedadMayorA5AniosAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound("No se encontraron clientes con más de 5 años de antigüedad.");
            }

            return Ok(clientes);
        }
        catch (Exception ex)
        {
            // Manejar errores según tus necesidades
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}