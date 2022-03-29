using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelo.ClasesMixtas
{
    public class BancoPBancoI
    {
        //Propierdades de la tabla Banco Proveedor
        public int IdBancoP { get; set; }
        public string Nombre { get; set; }
        //Propierdades de la tabla Banco Internacional
        public int IdBancoInternacional { get; set; }
        public string NombreBancoInternacional { set; get; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
    }
}
