using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRAGO.Models
{
    [Table("Vehiculo")]
    public class Auto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [MaxLength(50)]
        public string Marca { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [MaxLength(50)]
        public string Modelo { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal Precio { get; set; }
    }
}
