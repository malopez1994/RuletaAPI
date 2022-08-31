using RuletaAPI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace RuletaAPI.Data
{
    public class RuletaData : IRuletaData

    {

        private const string llaveID = "RuletaInfo";
        ObjectCache _memoryCache = MemoryCache.Default;
        public Ruleta ActualizarRuleta(string Id, Ruleta _ruleta)
        {
            _ruleta.Id = Id;
            return GuardarRuleta(_ruleta);
        }

        public List<Ruleta> ConsultarRuletas()
        {
            var ruletas = _memoryCache.ToList().Select(x => (Ruleta)x.Value).ToList();
            if (ruletas is null || ruletas.Count == 0)
            {
                return new List<Ruleta>();
            }
            return (List<Ruleta>)ruletas;
          
        }
        public Ruleta ConsultarRuletaxId(string Id)
        {
            var ruleta = (Ruleta)_memoryCache.Get(llaveID + Id);
            //var datainfo = this.cachingProvider.Get<Ruleta>(llaveID + Id);
            //if (ruleta.HasValue)
            if(ruleta == null)
            {
                return null;
            }
            //return datainfo.Value;
            return ruleta;
        }

        public Ruleta GuardarRuleta(Ruleta _ruleta)
        {
            _memoryCache.Set(llaveID + _ruleta.Id, _ruleta, DateTimeOffset.Now.AddMinutes(15.0));
           return _ruleta;
        }

    }
}
