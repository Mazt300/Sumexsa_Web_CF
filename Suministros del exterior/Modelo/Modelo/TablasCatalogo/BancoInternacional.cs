using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablasCatalogo
{

    [Table("BancoInternacional", Schema = "PV")]
    public class BancoInternacional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBancoInternacional { get; set; }
        //public int IdBanco { set; get; }
        [Required(ErrorMessage = "* El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Se a excedido el número de caractéres ")]
        public string Nombre { set; get; }
        [Required(ErrorMessage = "* El pais es requerido")]
        [StringLength(50, ErrorMessage = "Se a excedido el número de caractéres")]
        public string Pais { set; get; }
        [Required(ErrorMessage = "* La ciudad es requerida")]
        [StringLength(50, ErrorMessage = "Se a excedido el número de caractéres")]
        public string Ciudad { set; get; }
        public string? Estado { set; get; }
    }
}
