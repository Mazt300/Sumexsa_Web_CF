using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Modelo;
using Modelo.Modelo.ClasesMixtas;
using Modelo.Modelo.TablaRelaciones;
using Modelo.Modelo.TablasCatalogo;

namespace Servicio.LinQConsultas.PV
{
    public class BancoService
    {

        public BancoService()
        {

        }

       /* public List<BancoInternacional> obtenerbancos()
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    List<BancoInternacional> bancointernacional = contexto.BancoInternacional.Join(
                        contexto.BancoProveedor, x => x.Banco.IdBanco, y => y.IdBanco, (x, y) =>
                        new BancoInternacional
                        {
                            IdBancoInternacional = x.IdBancoInternacional,
                            Nombre = x.Nombre,
                            Pais = x.Pais,
                            Ciudad = x.Ciudad,
                            Estado = x.Estado,
                            Banco = y
                        }).Where(x => x.Banco.Estado == "A" && x.Estado == "A").ToList();

                    return bancointernacional;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }*/
      /*  public BancoInternacional? obtenerBancoxId(int? id)
        {
            try
            {
                using (DbContexto contexto = new DbContexto())
                {
                    var bancointernacional = contexto.BancoInternacional.Join(
                        contexto.BancoProveedor, x => x.Banco.IdBanco, y => y.IdBanco, (x, y) =>
                        new BancoInternacional
                        {
                            IdBancoInternacional = x.IdBancoInternacional,
                            Nombre = x.Nombre,
                            Pais = x.Pais,
                            Ciudad = x.Ciudad,
                            Estado = x.Estado,
                            Banco = y
                        }).Where(x => x.Banco.Estado == "A" && x.Estado == "A" && x.IdBancoInternacional == id).FirstOrDefault();

                    return bancointernacional;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }*/
        //Banco Proveedor
        public List<BancoProveedor> ObtenerBancos()
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    var bancos = contexto.BancoProveedor.Where(x => x.Estado == "A").ToList();
                    return bancos;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public BancoPBancoI? ObtenerBancoProveedorDetalles()
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    var res = from s in contexto.BancoProveedor
                              where s.Estado == "A"
                              select s;

                    //BancoPBancoI bancointernacional = contexto.BancoInternacional
                    //    .Join(
                    //    contexto.BancoProveedor, x => x.IdBancoInternacional, y => y.IdBanco, (x, y) =>
                    //    new BancoPBancoI
                    //    {
                    //        IdBancoInternacional = x.IdBancoInternacional,
                    //        Nombre = x.Nombre,
                    //        Pais = x.Pais,
                    //        Ciudad = x.Ciudad,
                    //        Estado = x.Estado,
                    //        Banco = y
                    //    }).Where(x => x.Banco.Estado == "A" && x.Estado == "A").ToList();

                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public bool ValidarBancoRelacion(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    var relacion = contexto.BancoP_BancoI.Where(x => x.IdBancoP == id && x.Estado == "A").FirstOrDefault();
                    if (relacion != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public BancoP_BancoI_Rel? ObtenerBancoProveedorXIdConRelacion(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    var var_bancoP_BancoI = contexto.BancoP_BancoI.Where(x => x.IdBancoP == id && x.Estado == "A").FirstOrDefault();
                    if (var_bancoP_BancoI != null)
                    {
                        BancoP_BancoI bancoP_BancoI = new BancoP_BancoI();
                        bancoP_BancoI = var_bancoP_BancoI;
                        if(bancoP_BancoI != null)
                        {
                            BancoProveedor bancoP = new BancoProveedor();
                            BancoInternacional bancoI = new BancoInternacional();
                            var bancobancoP = contexto.BancoProveedor.Where(x => x.IdBanco == bancoP_BancoI.IdBancoP).FirstOrDefault();
                            var bancobancoI = contexto.BancoInternacional.Where(x => x.IdBancoInternacional == bancoP_BancoI.IdBancoI && x.Estado == "A").FirstOrDefault();
                            if (bancobancoP != null && bancobancoI != null)
                            {
                                BancoP_BancoI_Rel bancoP_BancoI_Rel = new BancoP_BancoI_Rel();
                                bancoP_BancoI_Rel.Estado = var_bancoP_BancoI.Estado;
                                bancoP_BancoI_Rel.Id_BancoP_BancoI = var_bancoP_BancoI.Id_BancoP_BancoI;
                                bancoP_BancoI_Rel.BancoP = bancobancoP;
                                bancoP_BancoI_Rel.BancoI = bancobancoI;
                                if( bancoP_BancoI_Rel != null)
                                {
                                    return bancoP_BancoI_Rel;
                                }
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                    return null;
                }
                catch (Exception ex) {
                    throw new Exception(ex.Message.ToString()); 
                } 
            }
        }
        public BancoP_BancoI_Rel? ObtenerBancoProveedorXIdSinRelacion(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    var bancoP = contexto.BancoProveedor.Where(x => x.IdBanco == id).FirstOrDefault();
                    if (bancoP != null)
                    {
                        BancoP_BancoI_Rel bancoP_BancoI_Rel = new BancoP_BancoI_Rel();
                        bancoP_BancoI_Rel.BancoP = bancoP;
                        return bancoP_BancoI_Rel;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public BancoProveedor? ObtenerBancoProveedorXId(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    var bancoP = contexto.BancoProveedor.Where(x => x.IdBanco == id).FirstOrDefault();
                    if (bancoP != null)
                    {
                        return bancoP;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public bool VerificarBanco(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                return contexto.BancoProveedor.Any(x => x.IdBanco == id);
            }
        }
        public bool GuardarBancoProveedor(BancoP_BancoI_Rel bancoP_BancoI_Rel)
        {
            try
            {
                using (DbContexto contexto = new DbContexto())
                {
                    if(!string.IsNullOrEmpty(bancoP_BancoI_Rel.BancoP.Nombre))
                    {
                        contexto.BancoProveedor.Add(bancoP_BancoI_Rel.BancoP);
                        contexto.SaveChanges();
                    }
                    if (bancoP_BancoI_Rel.BancoI.IdBancoInternacional != 0)
                    {
                        bancoP_BancoI_Rel.BancoP.IdBanco = contexto.BancoProveedor.OrderByDescending(x => x.IdBanco).Select(y => y.IdBanco).FirstOrDefault();

                        BancoP_BancoI bancoP_BancoI = new BancoP_BancoI();
                        bancoP_BancoI.Estado = bancoP_BancoI_Rel.Estado;
                        bancoP_BancoI.IdBancoI = bancoP_BancoI_Rel.BancoI.IdBancoInternacional;
                        bancoP_BancoI.IdBancoP = bancoP_BancoI_Rel.BancoP.IdBanco;

                        contexto.BancoP_BancoI.Add(bancoP_BancoI);
                        contexto.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool EditarBancoProveedor(int id,BancoP_BancoI_Rel bancoP_BancoI_Rel)
        {
            try
            {
                using (DbContexto contexto = new DbContexto())
                {
                    if (!string.IsNullOrEmpty(bancoP_BancoI_Rel.BancoP.Nombre))
                    {
                        contexto.BancoProveedor.Update(bancoP_BancoI_Rel.BancoP);
                        contexto.SaveChanges();
                    }
                    if (bancoP_BancoI_Rel.BancoI.IdBancoInternacional != 0)
                    {
                        BancoP_BancoI? bancoP_BancoI_BD = contexto.BancoP_BancoI.Where(x => x.IdBancoP == id && x.Estado == "A").FirstOrDefault();

                        if (bancoP_BancoI_BD != null)
                        {
                            if(bancoP_BancoI_BD.IdBancoI != bancoP_BancoI_Rel.BancoI.IdBancoInternacional)
                            {
                                bancoP_BancoI_BD.Estado = "D";
                                contexto.BancoP_BancoI.Update(bancoP_BancoI_BD);
                                contexto.SaveChanges();
                            }
                            BancoP_BancoI bancoP_BancoI = new BancoP_BancoI();
                            bancoP_BancoI.Estado = bancoP_BancoI_Rel.Estado;
                            bancoP_BancoI.IdBancoI = bancoP_BancoI_Rel.BancoI.IdBancoInternacional;
                            bancoP_BancoI.IdBancoP = bancoP_BancoI_Rel.BancoP.IdBanco;

                            contexto.BancoP_BancoI.Add(bancoP_BancoI);
                            contexto.SaveChanges();
                        }
                        else
                        {
                            BancoP_BancoI bancoP_BancoI = new BancoP_BancoI();
                            bancoP_BancoI.Estado = bancoP_BancoI_Rel.Estado;
                            bancoP_BancoI.IdBancoI = bancoP_BancoI_Rel.BancoI.IdBancoInternacional;
                            bancoP_BancoI.IdBancoP = bancoP_BancoI_Rel.BancoP.IdBanco;

                            contexto.BancoP_BancoI.Add(bancoP_BancoI);
                            contexto.SaveChanges();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DarBajaBancoProveedor(BancoProveedor bancoProveedor)
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    contexto.BancoProveedor.Update(bancoProveedor);
                    contexto.SaveChanges();
                    var relacion = contexto.BancoP_BancoI.Where(x => x.IdBancoP == bancoProveedor.IdBanco).FirstOrDefault();
                    if (relacion != null)
                    {
                        BancoP_BancoI relacion_BP_BI = relacion;
                        relacion_BP_BI.Estado = "D";
                        contexto.BancoP_BancoI.Update(relacion_BP_BI);
                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        //Banco Internacional
        public List<BancoInternacional> ObtenerBancosInternacionales()
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    return contexto.BancoInternacional.Where(x => x.Estado == "A").ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public bool EditarBancoInternacional(BancoInternacional bancoProveedor)
        {
            try
            {
                using (DbContexto contexto = new DbContexto())
                {
                    contexto.BancoInternacional.Update(bancoProveedor);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool GuardarBancoInternacional(BancoInternacional bancoInternacional)
        {
            try
            {
                using (DbContexto contexto = new DbContexto())
                {
                    contexto.BancoInternacional.Add(bancoInternacional);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool VerificarBancoInternacional(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                return contexto.BancoInternacional.Any(x => x.IdBancoInternacional == id);
            }
        }
        public BancoInternacional? ObtenerBancoInternacionalXId(int? id)
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    var bancoP = contexto.BancoInternacional.Where(x => x.IdBancoInternacional == id).FirstOrDefault();
                    if (bancoP != null)
                    {
                        return bancoP;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public bool DarBajaBancoInternacional(BancoInternacional bancoInternacional)
        {
            using (DbContexto contexto = new DbContexto())
            {
                try
                {
                    contexto.BancoInternacional.Update(bancoInternacional);
                    contexto.SaveChanges();
                    var relacion = contexto.BancoP_BancoI.Where(x => x.IdBancoI == bancoInternacional.IdBancoInternacional && x.Estado == "A").ToList();
                    if (relacion != null)
                    {
                        for(int i = 0; i<= relacion.Count-1; i++)
                        {
                            BancoP_BancoI relacion_BP_BI = relacion[i];
                            relacion_BP_BI.Estado = "D";
                            contexto.BancoP_BancoI.Update(relacion_BP_BI);
                            contexto.SaveChanges();
                        }
                        return true;
                    }
                    else
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
