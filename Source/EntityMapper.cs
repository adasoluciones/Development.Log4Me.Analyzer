using Ada.Framework.Development.Log4Me.Analyzer.Entities;
using System;
using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Analyzer
{
    /// <summary>
    /// Mapeador de entidades del Log.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class EntityMapper
    {
        /// <summary>
        /// Convierte una colección de registros (fieles al txt) mediante un filtro, a una representación de cada parte del flujo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="registros">Colección de registros en línea(fieles al txt).</param>
        /// <param name="filtro">Filtro para excluir elementos. <value>true</value> para incluir, <value>false</value> para excluir.</param>
        /// <returns>Representación completa del flujo</returns>
        public HiloTO Convertir(IList<RegistroInLineTO> registros, Func<RegistroInLineTO, bool> filtro = null)
        {
            HiloTO retorno = new HiloTO();
            int fila = 0;
            if (registros != null)
            {
                retorno.Ejecuciones.Add(CargarArbol(new MetodoTO(), ref fila, registros, filtro));
            }
            return retorno;
        }

        public MetodoTO ConvertirMetodo(IList<RegistroInLineTO> registros, Func<RegistroInLineTO, bool> filtro = null)
        {
            int fila = 0;
            MetodoTO retorno = CargarArbol(new MetodoTO(), ref fila, registros, filtro);
            if (registros.Count > 0)
            {
                retorno.Hilo = new HiloTO() { ThreadGUID = registros[0].ThreadGUID };
            }
            return retorno;
        }

        /// <summary>
        /// Carga una colección de registros (fieles al txt) mediante un filtro, a una representación de cada parte del flujo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="retorno">Representación completa del flujo, para cargar los datos leídos.</param>
        /// <param name="x">Fila inicial a leer. Luego se continúa hasta el final.</param>
        /// <param name="registros">Registros fieles el archivo plano (Origen de la información).</param>
        /// <param name="filtro">Filtro para excluir elementos. <value>true</value> para incluir, <value>false</value> para excluir.</param>
        /// <returns>Representación completa del flujo</returns>
        private MetodoTO CargarArbol(MetodoTO retorno, ref int x, IList<RegistroInLineTO> registros, Func<RegistroInLineTO, bool> filtro = null)
        {
            while(x < registros.Count)
            {
                RegistroInLineTO registro = registros[x];

                if (filtro == null || (filtro != null && filtro(registro)))
                {
                    if (registro.Tipo == "Inicio")
                    {
                        if (retorno.Nombre != null)
                        {
                            retorno.Llamadas.Add(CargarArbol(new MetodoTO(), ref x, registros));
                        }
                        else
                        {
                            retorno.Nombre = registro.Metodo;
                            retorno.Clase = registro.Clase;
                            retorno.MethodGUID = registro.MethodGUID;
                            retorno.Fecha = registro.Fecha;
                        }
                    }
                    else if (registro.Tipo == "Retorno")
                    {
                        retorno.Retorno = new RetornoTO()
                        {
                            Fecha = registro.Fecha,
                            Tipo = registro.TipoVariable,
                            Valor = registro.ValorVariable
                        };

                        return retorno;
                    }
                    else if (registro.Tipo == "Excepcion")
                    {
                        retorno.Excepcion = new ExcepcionTO()
                        {
                            Data = registro.Data,
                            Mensaje = registro.Mensaje,
                            StackTrace = registro.StackTrace,
                            Tipo = registro.NombreVariable,
                        };
                    }
                    else if (registro.Tipo == "Parametro")
                    {
                        retorno.Parametros.Add(new ParametroTO()
                        {
                            Nombre = registro.NombreVariable,
                            Tipo = registro.TipoVariable,
                            Valor = registro.ValorVariable
                        });
                    }
                }
                x++;
            }

            return null;
        }
    }
}
