using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Saturn.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [Index("Client_Nit_Index", IsUnique = true)]
        public int Nit { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be below 30 caracters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a {0}")]
        [DataType(DataType.PhoneNumber)]
        public int Cellphone { get; set; }

        [DataType(DataType.Text)]
        public string Addres { get; set; }

        public virtual List<Contrato> Contratos { get; set; }
    }
}