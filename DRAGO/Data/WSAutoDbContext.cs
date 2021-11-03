using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DRAGO.Models;

namespace DRAGO.Data
{
    public class WSAutoDbContext: DbContext
    {
        //constructor con parámetro
        public WSAutoDbContext(DbContextOptions<WSAutoDbContext> options) : base(options) { }

        public DbSet<Auto> Vehiculo { get; set; }
    }
}
