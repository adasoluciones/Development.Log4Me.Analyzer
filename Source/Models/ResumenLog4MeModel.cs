using Ada.Framework.Development.Log4Me.Analyzer.Entities;
using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Analyzer.Models
{
    public class ResumenLog4MeModel : ResultadoAnalisisModel
    {
        public int MetodosEjecutados { get; set; }
        public int FlujosEjecutados { get; set; }
        public int ExcepcionesLanzadas { get; set; }

        public IList<ExcepcionTO> Excepciones { get; set; }

        public ResultadoMedicionModel<string> FlujoMasDemoroso { get; set; }
        public ResultadoMedicionModel<string> MetodoMasDemoroso { get; set; }

        public ResultadoMedicionModel<string> Log { get; set; }

        public ResumenLog4MeModel()
        {
            Analisis = new ResultadoMedicionAnonimaModel();
            FlujoMasDemoroso = new ResultadoMedicionModel<string>();
            MetodoMasDemoroso = new ResultadoMedicionModel<string>();
            Log = new ResultadoMedicionModel<string>();
            Excepciones = new List<ExcepcionTO>();
        }
    }
}
