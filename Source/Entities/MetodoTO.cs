using Ada.Framework.Development.Log4Me.Analyzer.Entities.Collections;
using System;
using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Analyzer.Entities
{
    /// <summary>
    ///  Representación del registro de un método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class MetodoTO
    {
        /// <summary>
        /// Constructor que inicializa las propiedades de la instancia.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public MetodoTO()
        {
            Parametros = new List<ParametroTO>();
            llamadas = new ColeccionMetodos(Hilo);
        }

        public DateTime Fecha { get; set; }
        
        public string Nombre { get; set; }

        public string MethodGUID { get; set; }

        /// <summary>
        /// Obtiene o establece el registro de los parámetros del método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public IList<ParametroTO> Parametros { get; set; }

        private ColeccionMetodos llamadas;

        /// <summary>
        /// Obtiene o establece el registro de las llamadas que realizó el método a otros o a sí mismo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public ColeccionMetodos Llamadas { get { return llamadas; } }

        private ExcepcionTO excepcion;

        /// <summary>
        /// Obtiene o establece el registro las excepciones lanzadas en el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public ExcepcionTO Excepcion { get { return excepcion; } set { value.Metodo = this; excepcion = value; } }


        private RetornoTO retorno;

        /// <summary>
        /// Obtiene o establece el registro del retorno del método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public RetornoTO Retorno { get { return retorno; } set { value.Metodo = this; retorno = value; } }

        public HiloTO Hilo { get; set; }

        public string Clase { get; set; }

        public string ObtenerNombreSinRetornoNiParametros()
        {
            string[] aux = Nombre.Split(' ');
            bool auxMayor = false;
            if (aux.Length > 1)
            {
                aux = aux[1].Split('(');
                auxMayor = true;
            }
            return auxMayor ? aux[0] : Nombre;
        }
    }
}
