using FileHelpers;
using System;

namespace Ada.Framework.Development.Log4Me.Analyzer.Entities
{
    /// <summary>
    /// Representación de un registro del log (una línea en el txt).
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [DelimitedRecord(";")]
    public class RegistroInLineTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del hilo(GUID).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(1)]
        public string ThreadGUID { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del método(GUID).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(2)]
        public string MethodGUID { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la clase a la que pertenece el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(3)]
        public string Clase { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del método de que se está registrando.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(4)]
        public string Metodo { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de registro.
        /// </summary>
        /// <example>
        ///     -Inicio
        ///     -Parametro
        ///     -Variable
        ///     -Excepcion
        ///     -Mensaje
        ///     -Retorno
        ///     ......
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(5)]
        public string Tipo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que se registró el evento.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(6)]
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy H:mm:ss")]
        public DateTime Fecha;

        /// <summary>
        /// Obtiene o establece el nombre de la variable registrada.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(7)]
        public string NombreVariable { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de la variable registrada.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(8)]
        public string TipoVariable { get; set; }

        /// <summary>
        /// Obtiene o establece el valor(estado) de la variable registrada.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(9)]
        public string ValorVariable { get; set; }

        /// <summary>
        /// Obtiene o establece la pila de llamados que contiene la excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(10)]
        public string StackTrace { get; set; }

        /// <summary>
        /// Obtiene o establece datos adicionales que fueron recogidos al lanzarse la excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(11)]
        public string Data { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo (clase) de la instancia de excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(12)]
        public string TipoExcepcion { get; set; }

        /// <summary>
        /// Obtiene o establece el mensaje del flujo de un método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(13)]
        public string Mensaje { get; set; }

        /// <summary>
        /// Obtiene o establece el nivel de importancia o tipo del mensaje.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(14)]
        public string Nivel { get; set; }

        /// <summary>
        /// Obtiene o establece el número de la llamada actual de la instancia en el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [FieldOrder(15)]
        public int Llamada { get; set; }

        [FieldOrder(16)]
        [FieldOptional]
        public string Extra;
    }
}
