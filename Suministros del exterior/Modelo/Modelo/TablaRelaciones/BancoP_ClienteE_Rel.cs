using Modelo.Modelo.TablasCatalogo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablaRelaciones
{
    [Table("BancoP_ClienteE", Schema = "PV")]
    public class BancoP_ClienteE_Rel
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
        public virtual ClienteProveedor? Cliente { get; set; }
        public virtual BancoProveedor Banco { get; set; }
    }
}
