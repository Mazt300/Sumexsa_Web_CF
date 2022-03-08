using AutoMapper;
using Modelo.Modelo;
using Modelo.Modelo.TablasCatalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.LinQConsultas.PV
{
    public class ClienteImportadorService
    {
        public ClienteImportadorService()
        {

        }

        public List<ClienteImportador> ObtenerClienteImportador()
        {
            using (DbContexto contexto = new DbContexto())
            {
                var clientesimportados = contexto.ClienteImportador.Where(x => x.Estado == "A").ToList();
                return clientesimportados;
            }
        }

        public bool VerificarCliente(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                return contexto.ClienteImportador.Any(x => x.Idclienteimportador == id);
            }
        }

        public ClienteImportador? OBtenerClienteImportadorXid(int? id)
        {
            try
            {
                using (DbContexto contexto = new DbContexto())
                {
                    var clienteimportador = contexto.ClienteImportador.Join(
                        contexto.PersonaContacto, x => x.PersonaContacto.IdPersonaContacto, y => y.IdPersonaContacto, (x, y) =>
                        new ClienteImportador
                        {
                            Idclienteimportador = x.Idclienteimportador,
                            Ruc_Cedula = x.Ruc_Cedula,
                            Direccion = x.Direccion,
                            Telefono = x.Telefono,
                            Nombre = x.Nombre,
                            Estado = x.Estado,
                            PersonaContacto = y
                        }).Where(ci => ci.Idclienteimportador == id && ci.Estado == "A").FirstOrDefault();

                    return clienteimportador;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool GuardarClienteImportador(ClienteImportador clienteImportador)
        {
            try
            {
                if (clienteImportador != null)
                {
                    clienteImportador.Estado = "A";
                    clienteImportador.PersonaContacto.TipoCliente = "ClienteImportador";
                    using (DbContexto contexto = new DbContexto())
                    {
                        contexto.Add(clienteImportador);
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
        public bool EditarClienteImportador(ClienteImportador clienteImportador)
        {
            if (clienteImportador != null)
            {
                using (DbContexto contexto = new DbContexto())
                {
                    contexto.Update(clienteImportador);
                    contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
