using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.TablasCatalogo
{
    [Table("BancoP_BancoI", Schema = "PV")]
    public class BancoP_BancoI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_BancoP_BancoI { get; set; }
        [ForeignKey("BancoProveedor")]
        public int IdBancoP { get; set; }
        [ForeignKey("BancoInternacional")]
        public int IdBancoI { get; set; }
        public string Estado { get; set; }
    }
}
