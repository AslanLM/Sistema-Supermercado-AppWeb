﻿
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sistema_Supermercado_AppWeb.Models
{
    public partial class TipoCuenta
    {
        public TipoCuenta()
        {
            Cuentas = new HashSet<Cuentas>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cuentas> Cuentas { get; set; }
    }
}