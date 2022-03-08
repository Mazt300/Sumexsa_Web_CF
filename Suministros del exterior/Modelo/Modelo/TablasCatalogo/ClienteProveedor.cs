using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablasCatalogo
{
    [Table("ClienteProveedor", Schema = "PV")]
    public class ClienteProveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClienteProveedor { get; set; }
        [Required(ErrorMessage ="* Este valor es requerido")]
        [StringLength(100,MinimumLength =10,ErrorMessage ="El nombre debe contener entre 10 a 100 caractéres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="* El pais es clave para registrar un cliente proveedor")]
        [StringLength(50,ErrorMessage ="Se han excedido el número de caractéres permitidos")]
        [Display(Name ="País")]
        public string Pais { get; set; }
        [Required(ErrorMessage ="* La ciudad es requerida")]
        [StringLength(50, ErrorMessage = "Se han excedido el número de caractéres permitidos")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "* El telefono es requerido")]
        [StringLength(20, ErrorMessage = "Ah excedido el limite de números")]
        [Phone]
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "* La dirección es requerida")]
        [StringLength(200, ErrorMessage = "Ha excedido el número de caractéres permitidos")]
        [Display (Name ="Dirección")]
        public string Direccion { get; set; }
        public string? Estado { get; set;}   

        public virtual PersonaContacto PersonaContacto { get; set; }

    }
}
