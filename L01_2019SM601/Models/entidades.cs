﻿using System.ComponentModel.DataAnnotations;

namespace L01_2019SM601.Models
{
    public class entidades
    {
        [Key]
        public int clienteId { get; set; }
        public string nombreCliente { get; set; }
        public string direccion { get; set; }

        

    }
}
