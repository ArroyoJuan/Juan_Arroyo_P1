using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;

namespace Juan_Arroyo_P1.Models
{
    public class Pacientes
    {
        public int id_paciente { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public string direccion { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_adicion { get; set; }
        public string adicionado_por { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string modificado_por { get; set; }
    }
}
