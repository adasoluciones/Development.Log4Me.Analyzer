
namespace Ada.Framework.Development.Log4Me.Analyzer.Entities
{
    /// <summary>
    /// Representación del registro de una variable del método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class VariableTO
    {
        /// <summary>
        /// Obtiene o establece el nombre de la variable.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de la variable.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Tipo { get; set; }

        /// <summary>
        /// Obtiene o establece el valor (estado) que tenía la variable en un momento determinado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public object Valor { get; set; }
    }
}
