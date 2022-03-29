using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Modelo.TablasCatalogo
{
    [Table("BancoProveedor", Schema = "PV")]
    public class BancoProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBanco { get; set; }
        [Required(ErrorMessage = "* El nombre es requerido")]
        [StringLength(100,ErrorMessage ="Se ha excedido el limite de caractéres en este campo")]
        [Display(Name ="Nombre de Banco")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="* La dirección es requerida")]
        [StringLength(200,ErrorMessage ="Se ha excedido de caractéres")]
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }
        public string? Estado { get; set; }
        
    }
}
