using System.ComponentModel.DataAnnotations;

namespace Juan_Arroyo_P1.Models
{
    public class Datos
    {
        public int id_pacienteP { get; set; }
        public string cedulaP { get; set; }
        public string nombreP { get; set; }
        public string apellidoP { get; set; }
        public string telefonoP { get; set; }
        public string correo_electronicoP { get; set; }
        public string direccionP { get; set; } 
        public DateTime fecha_nacimientoP { get; set; }
        public DateTime fecha_adicionP { get; set; }
        public string adicionado_porP { get; set; }
        public DateTime fecha_modificacionP { get; set; }
        public string modificado_porP { get; set; }
        public int id_citaC { get; set; }
        public int id_pacienteC { get; set; }
        public DateTime fecha_horaC { get; set; }
        public string motivo_consultaC { get; set; }
        public string estadoC { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime fecha_adicionC { get; set; }
        public string adicionado_porC { get; set; }
        public DateTime fecha_modificacionC { get; set; }
        public string modificado_porC { get; set; }
        public string Mensaje { get; set; }
        public Datos newTable { get; set; }
        public List<Datos> GetTable { get; set; } = new List<Datos>();

    }
}
