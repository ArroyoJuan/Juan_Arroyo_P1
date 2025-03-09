using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace Juan_Arroyo_P1.Models
{
    public class AccesoDatos
    {
        private readonly string _conexion;
        public AccesoDatos(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("DefaultConnection");
        }
        public void BuscarPaciente(Pacientes paciente)
        {
            using(SqlConnection conn=new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec sp_Validar_Existencia_Paciente @id_paciente";
                    using(SqlCommand cmd=new SqlCommand(query,conn))
                    {
                        cmd.Parameters.AddWithValue("@id_paciente",paciente.cedula);
                        
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar paciente " + ex.Message);
                }
            }
        }
        public string BuscarPaciente_v2(String Id)
        {
            string mensaje="No existe";
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    /*
                    string query = "sp_Validar_Existencia_Paciente";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType=System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id_paciente", Id));

                        SqlDataAdapter dataAdapter=new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);

                        foreach (DataRow dr in dt.Rows)
                        {
                            if (Id.ToString() == dr["id_paciente"].ToString())
                            {
                                mensaje = "Paciente encontrado.";
                            }
                        }
                    }*/
                    conn.Open();
                    string query = "sp_Validar_Existencia_Paciente";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_paciente", Convert.ToInt32(Id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(Id) == Convert.ToInt32(reader["id_paciente"]))
                        {
                            mensaje = "Paciente encontrado.";
                        } 
                    }
                    return mensaje;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar paciente test " + ex.Message);
                }
            }
            return mensaje;
        }
        /*public void IngresarPaciente(Pacientes paciente)
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    //Cambiar
                    string query = "Exec IngresarPedido @Fecha,@Cliente,@Total,@Estado";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fecha", paciente.Fecha);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar pedido " + ex.Message);
                }
            }
        }*/
    }
}
