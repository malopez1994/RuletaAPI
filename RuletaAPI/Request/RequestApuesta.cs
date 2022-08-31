using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaAPI.Request
{
    public class RequestApuesta
    {
        [Range(0, 38)]
        public int Ubicacion { get; set; }
        [Range(0.5d, maximum: 10000)]
        public double ValorApostado { get; set; }
    }
}
