using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRAGO.Data;
using DRAGO.Models;
using Microsoft.EntityFrameworkCore;

namespace DRAGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WSAutoController : ControllerBase
    {
        private readonly WSAutoDbContext context;
        public WSAutoController(WSAutoDbContext context)
        {
            this.context = context;
        }

        // GET: Traer todos los autos
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return context.Vehiculo.ToList();
        }

        //GET: Traer auto por modelo
        [HttpGet("GetByModelo/{modelo}")]//endpoint
        public IEnumerable<Auto> GetByModelo(string modelo)
        {
            var vehiculo = (from m in context.Vehiculo
                           where m.Modelo == modelo
                           select m).ToList();
            return vehiculo;
        }

        //POST: Insertar un auto
        [HttpPost]
        public ActionResult Post(Auto auto)
        {
            context.Vehiculo.Add(auto);
            context.SaveChanges();
            return Ok();
        }
    }
}
