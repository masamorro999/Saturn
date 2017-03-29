using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Saturn.Models
{
    public class Poliza
    {
        [Key]
        public int PolizaID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(50, ErrorMessage = "The field {0} must be below 50 caracters")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]        
        [DataType(DataType.Date)]
        public DateTime FechaIni { get; set; }

        public int ContratoID { get; set; }

        [ForeignKey("ContratoID")]
        public virtual Contrato Contrato { get; set; }

        //public virtual List<Contrato> Contratos { get; set; }
    }
}