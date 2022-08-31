using RuletaAPI.Data;
using RuletaAPI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaAPI.Servicios
{
    public class RuletaServicio : IRuletaServicio
    {
        private IRuletaData ruletaData;
        public RuletaServicio(IRuletaData _ruletaData)
        {
            this.ruletaData = _ruletaData;
        }
        public Ruleta Abrir(string Id)
        {
            Ruleta ruleta = ruletaData.ConsultarRuletaxId(Id);
            if (ruleta == null)
            {
                throw new Exception();
            }
            if (ruleta.Abierto != null)
            {
                throw new Exception();
            }
            ruleta.Abierto = DateTime.Now;
            ruleta.Apertura = true;
            return ruletaData.ActualizarRuleta(Id, ruleta);
        }
        public Ruleta Apuesta(string Id, string RuletaId, int Ubicacion, double valorApostado)
        {
            if (valorApostado > 10000 || valorApostado < 1)
            {
                throw new Exception("El valor apostado no se puede realizar");
            }
            Ruleta _ruleta = ruletaData.ConsultarRuletaxId(Id);
            if (_ruleta == null)
            {
                throw new Exception("no tiene ninguna ruleta");
            }

            if (_ruleta.Apertura == false)
            {
                throw new Exception();
            }

            double value = 0d;
            _ruleta.NumeroValido[Ubicacion].TryGetValue(RuletaId, out value);
            _ruleta.NumeroValido[Ubicacion].Remove(RuletaId + "");
            _ruleta.NumeroValido[Ubicacion].TryAdd(RuletaId + "", value + valorApostado);

            return ruletaData.ActualizarRuleta(_ruleta.Id, _ruleta);
        }
        public Ruleta Busqueda(string Id)
        {
            return ruletaData.ConsultarRuletaxId(Id);
        }
        public Ruleta Cerrar(string Id)
        {
            Ruleta ruleta = ruletaData.ConsultarRuletaxId(Id);
            if (ruleta == null)
            {
                throw new Exception();
            }
            if (ruleta.Cerrado != null)
            {
                throw new Exception();
            }
            ruleta.Cerrado = DateTime.Now;
            ruleta.Apertura = false;
            return ruletaData.ActualizarRuleta(Id, ruleta);
        }
        public Ruleta Creacion()
        {
            Ruleta _ruleta = new Ruleta()
            {
                Id = Guid.NewGuid().ToString(),
                Apertura = false,
                Abierto = null,
                Cerrado = null
            };
            ruletaData.GuardarRuleta(_ruleta);
            return _ruleta;
        }
        public List<Ruleta> ListadoRuletas()
        {
            return ruletaData.ConsultarRuletas();
        }
    }
}
