using System;
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
        public string BuscarPaciente(Datos datos)
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    //Primera parte validar si existe metodo
                    string query = "Exec sp_Validar_Existencia_Paciente @id_paciente, @mensaje OUTPUT";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_paciente", datos.id_pacienteP);

                        SqlParameter outputParam = new SqlParameter("@mensaje", SqlDbType.VarChar, 255);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery(); 

                        string mensaje = outputParam.Value.ToString();
                        return mensaje;
                    }


                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
        public void IngresarCita(Datos datos)
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec sp_Insertar_Cita @id_paciente,@fecha_hora,@motivo_consulta,@estado,@adicionado_por";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        Console.WriteLine("Texto: "+ datos.id_pacienteC);
                        cmd.Parameters.AddWithValue("@id_paciente",Convert.ToInt32(datos.id_pacienteC));
                        cmd.Parameters.AddWithValue("@fecha_hora", Convert.ToDateTime(datos.fecha_adicionC));
                        cmd.Parameters.AddWithValue("@motivo_consulta", Convert.ToString(datos.motivo_consultaC));
                        cmd.Parameters.AddWithValue("@estado", Convert.ToString(datos.estadoC));
                        cmd.Parameters.AddWithValue("@adicionado_por", Convert.ToString("admin"));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar pedido " + ex.Message);
                }
            }
        }
        public string testeos()
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                string checkPacienteQuery = "SELECT COUNT(1) FROM Pacientes WHERE id_paciente = @id_paciente";
                SqlCommand checkPacienteCmd = new SqlCommand(checkPacienteQuery, conn);

                // Agregar el parámetro correctamente
                checkPacienteCmd.Parameters.AddWithValue("@id_paciente", 1);

                conn.Open();
                int count = (int)checkPacienteCmd.ExecuteScalar();

                if (count == 0)
                {
                    return "No existe";
                }
                else
                {
                    return "Existe";
                }
            }
                
        }
    }
}
/*string checkPacienteQuery = $"SELECT COUNT(1) FROM Pacientes WHERE id_paciente = @id_pacienteR";
                    SqlCommand checkPacienteCmd = new SqlCommand(checkPacienteQuery, conn);

                    // Agregar el parámetro correctamente
                    checkPacienteCmd.Parameters.AddWithValue("@id_pacienteR", citas.id_pacienteC);

                    conn.Open();
                    int count = (int)checkPacienteCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        throw new Exception("Error: El paciente no existe en la base de datos.");
                    }*/