using RuletaAPI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaAPI.Data
{
   public interface IRuletaData
    {
        public Ruleta ConsultarRuletaxId(string Id);

        public List<Ruleta> ConsultarRuletas();

        public Ruleta ActualizarRuleta(string Id, Ruleta _ruleta);

        public Ruleta GuardarRuleta(Ruleta _ruleta);
    }
}
