using System.ComponentModel.DataAnnotations;

namespace Juan_Arroyo_P1.Models
{
    public class Datos
    {
        public int id_pacienteP { get; set; }
        [Required(ErrorMessage = "El cedula es obligatorio")]
        public string cedulaP { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombreP { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string apellidoP { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string telefonoP { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido")]
        public string correo_electronicoP { get; set; }
        [Required(ErrorMessage = "La dirección es obligatorio")]
        [StringLength(500, ErrorMessage = "La dirección no puede superar los 500 caracteres")]
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
    public class ContactViewModel
    {
        public Datos NuevoMensaje { get; set; }
        public List<Datos> Mensajes { get; set; } = new List<Datos>();
    }
}
