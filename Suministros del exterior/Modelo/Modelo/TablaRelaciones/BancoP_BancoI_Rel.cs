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
    [Table("BancoP_BancoI",Schema="PV")]
    public class BancoP_BancoI_Rel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_BancoP_BancoI { get; set; }
        public  BancoProveedor BancoP { get; set; }
        public  BancoInternacional BancoI { get; set; }
        public string Estado { get; set; }
    }
}
