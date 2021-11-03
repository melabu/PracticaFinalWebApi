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
        [HttpGet("Getbymodelo/{modelo}")]//endpoint
        public IEnumerable<Auto> Getbymodelo(string modelo)
        {
            var vehiculo = (from auto in context.Vehiculo
                           where auto.Modelo == modelo
                           select auto).ToList();
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
