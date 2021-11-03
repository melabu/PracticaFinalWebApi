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
    public class AutoController : ControllerBase
    {
        private readonly WSAutoDbContext context;
        public AutoController(WSAutoDbContext context)
        {
            this.context = context;
        }

        //GET: Traer auto por Id
        [HttpGet("{id}")]
        public ActionResult<Auto> Get(int id)
        {
            return context.Vehiculo.Find(id);
        }

        //PUT: Modificar un auto
        [HttpPut("{id}")]
        public ActionResult Put(int id, Auto auto)
        {
            if (id != auto.Id)
            {
                return BadRequest();
            }
            context.Entry(auto).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        // DELETE: Eliminar un auto
        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            Auto auto = context.Vehiculo.Find(id);
            if (auto == null)
            {
                return NotFound();
            }
            context.Vehiculo.Remove(auto);
            context.SaveChanges();
            return auto;
        }

        //GET: Traer auto por marca y modelo
        [HttpGet("getbymarcaymodelo/{marca}/{modelo}")]//endpoint
        public IEnumerable<Auto> getbymarcaymodelo(string marca, string modelo)
        {
            var vehiculo = (from auto in context.Vehiculo
                            where auto.Marca == marca&&auto.Modelo==modelo
                            select auto).ToList();
            return vehiculo;
        }

        //GET: Traer auto por color
        [HttpGet("getbyColor/{color}")]
        public IEnumerable<Auto> getbyolor(string color)
        {
            var vehiculo = (from auto in context.Vehiculo
                           where auto.Color == color
                           select auto).ToList();
            return vehiculo;
        }
    }  
}
