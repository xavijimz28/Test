using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    public class TarjetaPrestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PrestamoId { get; set; }
        public decimal MontoPrestado { get; set; }
        public Estatus EstatusPrestamo { get; set; }
        public DateTime FechaLiquidar { get; set; }
        public DateTime FechaPago { get; set; }
        public Guid TarjetaId { get; set; }
        [ForeignKey("TarjetaId")]
        public virtual Tarjeta Tarjeta { get; set; }
        public enum Estatus
        {
            Autorizado,
            Denegado
        }
    }
}
