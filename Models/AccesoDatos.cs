using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Numerics;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Juan_Arroyo_P1.Models
{
    public class AccesoDatos
    {
        private readonly string _conexion;
        public AccesoDatos(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("DefaultConnection");
        }
        public Datos BuscarPaciente(string GetCedula) //Aqui cae la cedula
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    //Sxript para buscar el id por cedula
                    string query = "Exec sp_Obtener_Paciente_Por_Cedula @Cedula";
                 
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cedula", GetCedula);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Si hay resultados
                            {
                                Datos datos = new Datos
                                {
                                    id_pacienteP = Convert.ToInt32(reader["id_paciente"]),
                                    cedulaP = Convert.ToString(reader["cedula"])
                                };

                                return datos;
                            }
                            else
                            {
                                return null; 
                            }
                        }
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
        public void RegistrarPaciente(Datos datos)
        {
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec sp_Insertar_Paciente @cedula,@nombre,@apellido,@telefono,@correo_electronico,@direccion,@fecha_nacimiento,@adicionado_por,@mensaje OUTPUT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cedula", Convert.ToString(datos.cedulaP));
                        cmd.Parameters.AddWithValue("@nombre", Convert.ToString(datos.nombreP));
                        cmd.Parameters.AddWithValue("@apellido", Convert.ToString(datos.apellidoP));
                        cmd.Parameters.AddWithValue("@telefono", Convert.ToString(datos.telefonoP));
                        cmd.Parameters.AddWithValue("@correo_electronico", Convert.ToString(datos.correo_electronicoP));
                        cmd.Parameters.AddWithValue("@direccion", Convert.ToString(datos.direccionP));
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", Convert.ToDateTime(datos.fecha_nacimientoP));
                        cmd.Parameters.AddWithValue("@adicionado_por", Convert.ToString("admin"));


                        SqlParameter mensajeParam = new SqlParameter("@mensaje", SqlDbType.VarChar, 255);
                        mensajeParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(mensajeParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        string mensaje = mensajeParam.Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar pedido " + ex.Message);
                }
            }
        }
        /*public List<Datos> cargarCitas(string fechaNow)
        {
            List<Datos> listaDatos = new List<Datos>();
            using (SqlConnection conn = new SqlConnection(_conexion))
            {
                try
                {
                    //Sxript para buscar el id por cedula
                    string query = "SELECT * FROM Citas";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", fechaNow);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Datos datos = new Datos
                                {
                                    id_citaC = Convert.ToInt32(reader["id_cita"]),
                                    id_pacienteC = Convert.ToInt32(reader["id_paciente"]),
                                    fecha_horaC = Convert.ToDateTime(reader["fecha_hora"]),
                                    motivo_consultaC = Convert.ToString(reader["motivo_consulta"]),
                                    estadoC = Convert.ToString(reader["estado"])
                                };
                                listaDatos.Add(datos);
                            }
                        }
                    }
                    return listaDatos.Count > 0 ? listaDatos : null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }*/
    }
}
/*//Primera parte validar si existe metodo
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
                    }*/