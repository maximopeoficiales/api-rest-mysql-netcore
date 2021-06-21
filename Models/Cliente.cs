using System;
using System.Collections.Generic;

#nullable disable
using System.Text.Json;
using System.Text.Json.Serialization;

namespace banco_api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Depositos = new HashSet<Deposito>();
            Retiros = new HashSet<Retiro>();
        }

        public int NCuenta { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }

        [JsonIgnore]
        public virtual ICollection<Deposito> Depositos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Retiro> Retiros { get; set; }
    }
}
