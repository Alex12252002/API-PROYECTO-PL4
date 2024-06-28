using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prueba3Parcial.Modelo
{
    public class TareaMantenimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMantenimiento {  get; set; }
        public string Tareas { get; set; }
        
        public int Kilometraje { get; set; }
        public string Repuesto { get; set; }
        public string Observacion { get; set; }
    }
}
