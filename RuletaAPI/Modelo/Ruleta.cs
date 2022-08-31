using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaAPI.Modelo
{
    public class Ruleta
    {
        public string Id { get; set; }
        public bool Apertura { get; set; } = false;
        public DateTime? Abierto { get; set; }
        public DateTime? Cerrado { get; set; }
        public IDictionary<string, double>[] NumeroValido { get; set; } = new IDictionary<string, double>[39];
        public Ruleta()
        {
            this.Init();
        }
        private void Init()
        {
            for (int i = 0; i < NumeroValido.Length; i++)
            {
                NumeroValido[i] = new Dictionary<string, double>();
            }
        }
    }
}