using RuletaAPI.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaAPI.Servicios
{
   public interface IRuletaServicio
    {
        public Ruleta Creacion();
        public Ruleta Busqueda(string Id);
        public Ruleta Abrir(string Id);
        public Ruleta Cerrar(string Id);
        public Ruleta Apuesta(string Id, string RuletaId, int Ubicacion, double valorApostado);
        public List<Ruleta> ListadoRuletas();
    }
}
