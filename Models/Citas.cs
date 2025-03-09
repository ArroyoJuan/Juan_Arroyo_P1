using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Juan_Arroyo_P1.Models
{
    public class Citas
    {
        public int id_cita { get; set; }
        public int id_paciente { get; set; }
        public DateTime fecha_hora { get; set; }
        public string motivo_consulta { get; set; }
        public string estado { get; set; }
        public DateTime fecha_adicion { get; set; }
        public string adicionado_por { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string modificado_por { get; set; }
    }
}
