using Microsoft.EntityFrameworkCore;

namespace Prueba3Parcial.Modelo
{
    [Owned]
    public class Ubicacion
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
