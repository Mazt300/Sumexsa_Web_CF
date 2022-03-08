using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablasCatalogo
{
    [Table("BancoProveedor", Schema = "PV")]
    public class BancoProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBanco { get; set; }
        [Required(ErrorMessage = "* No se ha seleccionado el tipo de banco")]
        [StringLength(50)]
        [Display(Name ="Tipo de banco")]
        public string TipoBanco { get; set; }
        [Required(ErrorMessage ="* La dirección es requerida")]
        [StringLength(200,ErrorMessage ="Se ha excedido de caractéres")]
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage ="* El número de cuenta bancaria es requerido")]
        [StringLength(50,ErrorMessage ="Número de cuenta excede los 50 caractéres")]
        [Display(Name ="Nº de cuenta bancaria")]
        public string Cuenta { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(20,ErrorMessage ="Se han excedido los 50 caractéres")]
        [Display(Name ="Tipo de moneda")]
        public string Modena { get; set; }
        [Required(ErrorMessage ="* Nº Swift es necesario")]
        [Display(Name ="Nº SWIFT")]
        public string Swift { get; set; }
        public string? Estado { get; set; }
    }

    [Table("BancoInternacional", Schema = "PV")]
    public class BancoInternacional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBancoInternacional { get; set; }
        //public int IdBanco { set; get; }
        [Required(ErrorMessage ="* El nombre es requerido")]
        [StringLength(100,ErrorMessage ="Se a excedido el número de caractéres ")]
        public string Nombre { set; get; }
        [Required(ErrorMessage ="* El pais es requerido")]
        [StringLength(50, ErrorMessage ="Se a excedido el número de caractéres")]
        public string Pais { set; get; }
        [Required(ErrorMessage ="* La ciudad es requerida")]
        [StringLength(50, ErrorMessage ="Se a excedido el número de caractéres")]
        public string Ciudad { set; get; }
        public string? Estado { set; get; }
        public virtual BancoProveedor Banco { get; set; }
    }
}
