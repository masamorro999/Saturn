using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Saturn.Models
{
    public class Prorroga
    {
        [Key]
        public int ProrrogaID { set; get; }

        //[Required]
        //public uint IdContrato { set; get; }        

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(100, ErrorMessage = "The field {0} must be between 3 and 100 caracters", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Descripcion { set; get; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [DataType(DataType.Date)]
        public DateTime FechaIni { set; get; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [DataType(DataType.Date)]
        public DateTime? FechaFin { set; get; }

        public int ContratoID { get; set; }

        [ForeignKey("ContratoID")]
        public virtual Contrato Contrato { get; set; }
    }
}