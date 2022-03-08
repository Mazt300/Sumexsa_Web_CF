using Modelo.Modelo;
using Modelo.Modelo.TablasCatalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.LinQConsultas.PV
{
    public class ClienteExtranjeroService
    {
        public ClienteExtranjeroService()
        {

        }

        public List<ClienteProveedor> ObtenerClienteExtranjero()
        {
            using (DbContexto contexto = new DbContexto())
            {
                var clientesimportados = contexto.ClienteProveedor.Where(x => x.Estado == "A").ToList();
                return clientesimportados;
            }
        }

        public bool VerificarClienteExtranjero(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                return contexto.ClienteProveedor.Any(x => x.IdClienteProveedor == id);
            }
        }

        public ClienteProveedor? OBtenerClienteExtranjeroXid(int? id)
        {
            try
            {
                using (DbContexto contexto = new DbContexto())
                {
                    var clienteproveedor = contexto.ClienteProveedor.Join(
                        contexto.PersonaContacto, x => x.PersonaContacto.IdPersonaContacto, y => y.IdPersonaContacto, (x, y) =>
                        new ClienteProveedor
                        {
                            IdClienteProveedor = x.IdClienteProveedor,
                            Ciudad = x.Ciudad,
                            Pais = x.Pais,
                            Direccion = x.Direccion,
                            Telefono = x.Telefono,
                            Nombre = x.Nombre,
                            Estado = x.Estado,
                            PersonaContacto = y
                        }).Where(ce => ce.IdClienteProveedor == id && ce.Estado == "A").FirstOrDefault();

                    return clienteproveedor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool GuardarClienteExtranjero(ClienteProveedor clienteProveedor)
        {
            try
            {
                if (clienteProveedor != null)
                {
                    clienteProveedor.Estado = "A";
                    clienteProveedor.PersonaContacto.TipoCliente = "ClienteExtranjero";
                    using (DbContexto contexto = new DbContexto())
                    {
                        contexto.Add(clienteProveedor);
                        contexto.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return false;
        }
        public bool EditarClienteExtranjero(ClienteProveedor clienteProveedor)
        {
            if (clienteProveedor != null)
            {
                using (DbContexto contexto = new DbContexto())
                {
                    contexto.Update(clienteProveedor);
                    contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
