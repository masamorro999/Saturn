using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Saturn.Models
{
    public class Contrato
    {
        [Key]
        public int ContratoID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(20, ErrorMessage = "The field {0} must be below 20 caracters")]
        [DataType(DataType.Text)]
        public string CodContrato { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(50, ErrorMessage = "The field {0} must be below 50 caracters")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIni { get; set; }

        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        public virtual List<Prorroga> Prorrogas { get; set; }
    }
}