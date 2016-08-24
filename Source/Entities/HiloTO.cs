using Ada.Framework.Development.Log4Me.Analyzer.Entities.Collections;

namespace Ada.Framework.Development.Log4Me.Analyzer.Entities
{
    public class HiloTO
    {
        private ColeccionMetodos ejecuciones;

        public string ThreadGUID { get; set; }
        public ColeccionMetodos Ejecuciones { get { return ejecuciones; } }

        public HiloTO()
        {
            ejecuciones = new ColeccionMetodos(this);
        }
    }
}
