using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Agregue Descripcion del Articulo")]
        public string Descripcion { get; set; }
        [Range(minimum:1,maximum: 100000)]
        public int Existencia { get; set; }
        public double Costo { get; set; }
        public double ValorInventario { get; set; }
    }
}
