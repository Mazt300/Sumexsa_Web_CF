using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablasCatalogo
{

    [Table("PersonaContacto", Schema = "PV")]
    public class PersonaContacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersonaContacto { get; set; }
        public string TipoCliente { get; set; }
        [Required(ErrorMessage = "Debe ingresar nombre")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "El nombre debe estar entre 10 a 100 caractéres, por favor revisar")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="El correo es necesario")]
        [EmailAddress(ErrorMessage ="dirección de correo invalida")]
        public string Correo { get; set; }

    }
}
