using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente
    {
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< | SQL CLIENT | <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>GETALL<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public static ENT.Result GetAll()
        {
            ENT.Result result = new ENT.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DAL.Conexion.GetConnectionString()))
                {
                    string query = "ClienteGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ENT.Cliente cliente = new ENT.Cliente();
                                cliente.IdCliente = int.Parse(row[0].ToString());
                                cliente.Nombre = row[1].ToString();
                                cliente.ApellidoPaterno = row[2].ToString();
                                cliente.ApellidoMaterno = row[3].ToString();
                                cliente.FechaModificacion = DateTime.Parse(row[4].ToString());

                                result.Objects.Add(cliente);
                            }
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<GETBYID>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static ENT.Result GetById(ENT.Cliente cliente)
        {
            ENT.Result result = new ENT.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DAL.Conexion.GetConnectionString()))
                {
                    string query = "ClienteGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[0].Value = cliente.IdCliente;
                        cmd.Parameters.AddRange(collection);

                        DataTable tableAseguradora = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAseguradora);


                        if (tableAseguradora.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAseguradora.Rows)
                            {
                                ENT.Cliente clienteI = new ENT.Cliente();
                                clienteI.IdCliente = int.Parse(row[0].ToString());
                                clienteI.Nombre = row[1].ToString();
                                clienteI.ApellidoPaterno = row[2].ToString();
                                clienteI.ApellidoMaterno = row[3].ToString();
                                clienteI.FechaModificacion = DateTime.Parse(row[4].ToString());
                                result.Objects.Add(clienteI);
                            }
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<ENTITY FRAMEWORK<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< | USUARIO ADD EF | >>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static ENT.Result AddEF(ENT.Cliente cliente)
        {
            ENT.Result result = new ENT.Result();
            try
            {
                using (DAL.SeguritasEntities context = new DAL.SeguritasEntities())
                {
                    var query = context.ClienteAdd(cliente.IdCliente,cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno);
                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<UPDATE>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public static ENT.Result UpdateEF(ENT.Cliente cliente)
        {
            ENT.Result result = new ENT.Result();
            try
            {
                using (DAL.SeguritasEntities context = new DAL.SeguritasEntities())
                {

                    var query = context.ClienteUpdate(cliente.IdCliente, cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno);

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Sin Actualizar";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>DELETE<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        public static ENT.Result DeleteEF(ENT.Cliente cliente)
        {
            ENT.Result result = new ENT.Result();
            try
            {
                using (DAL.SeguritasEntities context = new DAL.SeguritasEntities())
                {
                    var query = context.ClienteDelete(cliente.IdCliente);

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Sin Eliminar";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
