using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejercicio5_back.Models;
using Ejercicio5_back.DTO;
using AutoMapper;

namespace Ejercicio5_back.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly Practica5Context _context;
        private readonly IMapper mapper;

        public EmpleadosController(Practica5Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet("obtenerEmpleados")]
        public async Task<ActionResult<EmpleadoDTO>> ObtenerEmpleados()
        {
            EmpleadoDTO objDto = new EmpleadoDTO();
            List<Empleado> empleados = new List<Empleado>();

            empleados = await _context.Empleados.Include(e => e.IdEstadoNavigation).ToListAsync();
            objDto.data = empleados;

            return objDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Empleado>> ObtenerEmpleado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpPost("registrarEmpleado")]
        public async Task<ActionResult> RegistrarEmpleado([Bind("Id,NumeroNomina,Nombre,ApellidoPaterno,ApellidoMaterno,IdEstado")] Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //empleado.IdEstado(g => _context.Entry(g).State = EntityState.Unchanged);
                    _context.Entry(empleado.IdEstadoNavigation).State = EntityState.Unchanged;

                    _context.Add(empleado);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Empleado>> Editar(int id, [Bind("Id,NumeroNomina,Nombre,ApellidoPaterno,ApellidoMaterno,IdEstado")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return empleado;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> EliminarRegistro(int id)
        {
            if (!EmpleadoExists(id))
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
