using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejercicio5_back.Models;
using Ejercicio5_back.DTO;

namespace Ejercicio5_back.Controllers
{
    [ApiController]
    [Route("api/catEntFederativas")]
    public class CatEntidadesFederativasController : ControllerBase
    {
        private readonly Practica5Context _context;

        public CatEntidadesFederativasController(Practica5Context context)
        {
            _context = context;
        }

        // GET: CatEntidadesFederativas
        [HttpGet("obtenerEntFederativas")]
        public async Task<List<CatEntidadFederativa>> ObtenerEntFederativas()
        {
            CatEntFederativasDTO objCatEntFedDTO = new CatEntFederativasDTO();
            List<CatEntidadFederativa> listEntFed = new List<CatEntidadFederativa>();
            
            listEntFed = await _context.CatEntidadFederativas.OrderBy(e => e.Estado).ToListAsync();

            objCatEntFedDTO.data = listEntFed;

            return listEntFed;
        }
    }
}
