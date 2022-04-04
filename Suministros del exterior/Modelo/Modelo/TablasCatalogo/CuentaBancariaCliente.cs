using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablasCatalogo
{
    [Table("CuentaBancariaCliente", Schema = "PV")]
    public class CuentaBancariaCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBancoP_ClienteE { get; set; }
        [Required(ErrorMessage = "* El número de cuenta bancaria es requerido")]
        [StringLength(50, ErrorMessage = "Número de cuenta excede los 50 caractéres")]
        [Display(Name = "Nº de cuenta bancaria")]
        public string Cuenta { get; set; }
        [Required(ErrorMessage = "* Nº de cuenta es requerido")]
        [StringLength(20, ErrorMessage = "Se han excedido los 50 caractéres")]
        [Display(Name = "Tipo de moneda")]
        public string Moneda { get; set; }
        [Required(ErrorMessage = "* Nº Swift es necesario")]
        [Display(Name = "Nº SWIFT")]
        public string Swift { get; set; }
        public string Estado { get; set; }
        [ForeignKey("ClienteProveedor")]
        public int IdCliente { get; set; }
        [ForeignKey("BancoProveedor")]
        public int IdBanco { get; set; }
    }
}
