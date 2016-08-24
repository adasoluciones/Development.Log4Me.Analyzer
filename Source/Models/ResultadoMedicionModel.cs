using System;

namespace Ada.Framework.Development.Log4Me.Analyzer.Models
{
    public class ResultadoMedicionModel<T> : ResultadoMedicionModel
    {
        public T ID { get; set; }
    }

    public class ResultadoMedicionModel : ResultadoMedicionAnonimaModel
    {
        public string Nombre { get; set; }
    }

    public class ResultadoMedicionAnonimaModel
    {
        public DateTime? Inicio { get; set; }
        public DateTime? Termino { get; set; }
        public TimeSpan? Total
        {
            get
            {
                Nullable<TimeSpan> retorno = new Nullable<TimeSpan>();
                if (Termino.HasValue && Inicio.HasValue)
                {
                    retorno = (Termino.Value - Inicio.Value);
                }
                return retorno;
            }
        }
    }

}
