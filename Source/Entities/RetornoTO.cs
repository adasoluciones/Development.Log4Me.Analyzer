using Newtonsoft.Json;
using System;

namespace Ada.Framework.Development.Log4Me.Analyzer.Entities
{
    /// <summary>
    /// Representación del registro del retorno de un método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class RetornoTO
    {
        /// <summary>
        /// Obtiene o establece el tipo de retorno.
        /// </summary>
        /// <example>
        ///     -Void
        ///     -System.String
        ///     -cl.MiApp.Entities.UsuarioTO
        ///     .....
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Tipo { get; set; }

        /// <summary>
        /// Obtiene o establece el valor retornado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public object Valor { get; set; }

        [JsonIgnore]
        public MetodoTO Metodo { get; set; }

        public DateTime Fecha { get; set; }
    }
}
