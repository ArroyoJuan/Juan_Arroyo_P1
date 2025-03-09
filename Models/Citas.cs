using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Juan_Arroyo_P1.Models
{
    public class Citas
    {
        public int id_cita { get; set; }
        public int id_pacienteC { get; set; }
        public DateTime fecha_hora { get; set; }
        public string motivo_consulta { get; set; }
        public string estado { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime fecha_adicion { get; set; }
        public string adicionado_por { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string modificado_por { get; set; }
    }
}
