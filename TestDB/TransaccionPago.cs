using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    public class TransaccionPago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransaccionId { get; set; }
        public Estatus EstatusTarjeta { get; set; }
        public string Referencia { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public Guid TarjetaId { get; set; }
        [ForeignKey("TarjetaId")]
        public virtual Tarjeta Tarjeta { get; set; }
        public enum Estatus
        {
            Procesando,
            Denegado,

        }
    }
}
