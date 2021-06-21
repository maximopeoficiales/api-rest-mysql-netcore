using System;
using System.Collections.Generic;

#nullable disable

namespace banco_api.Models
{
    public partial class Retiro
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
        public int Cliente { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
    }
}
