using System;
using System.Collections.Generic;

#nullable disable
using System.Text.Json;
using System.Text.Json.Serialization;
namespace banco_api.Models
{
    public partial class Deposito
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
        public int Cliente { get; set; }

        
        public virtual Cliente ClienteNavigation { get; set; }
    }
}
