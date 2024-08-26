﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasLyncas.Domain.DTOs
{
    public class ItemVendaAdicionarDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal TotalItensVenda { get; set; }
    }
}
