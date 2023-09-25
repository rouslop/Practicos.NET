using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EFModels
{
    public class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Marca { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Modelo { get; set; }

        [MaxLength(9), MinLength(6), Required]
        public string Matricula { get; set; }

        [ForeignKey("IdPropietario")]
        public Personas Propietario { get; set; }

        
    }
}
