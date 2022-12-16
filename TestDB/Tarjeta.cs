using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    public class Tarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TarjetaId { get; set; }
        public TiposTarjetas TipoTarjeta { get; set; }
        public EstatusTarjetas EstatusTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
        public int MesVigencia { get; set; }
        public int AnualidaVigencia { get; set; }
        public bool Activo { get; set; }
        public Guid CuentaClienteId { get; set; }
        [ForeignKey("CuentaClienteId")]
        public virtual CuentaCliente CuentaCliente { get; set; }

        public enum TiposTarjetas
        {
            Credito,
            Debito
        }
        public enum EstatusTarjetas
        {
            Activa,
            Bloqueada
        }
    }
}
