using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablasCatalogo
{
    [Table("ClienteImportador",Schema ="PV")]
    public class ClienteImportador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idclienteimportador { get; set; }
        [Required(ErrorMessage ="El número identificador es requerido")]
        [Display(Name ="Nº Ruc o Cédula")]
        public string Ruc_Cedula { get; set; }
        [Required(ErrorMessage ="La dirección es requerida")]
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage ="Debe tener un teléfono contacto")]
        [Display(Name ="Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="Por favor ingresar nombre")]
        [StringLength(100,MinimumLength =10, ErrorMessage ="El nombre debe ser mayor a 10 caractéres y menor a 100")]
        public string Nombre { get; set; }
        public string? Estado { get; set; }
        public virtual PersonaContacto PersonaContacto { get; set; }
        
    }
}
