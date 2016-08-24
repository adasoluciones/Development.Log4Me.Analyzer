using Ada.Framework.Development.Log4Me.Analyzer.Entities;
using Ada.Framework.Development.Log4Me.Analyzer.Models;
using Ada.Framework.Development.Log4Me.Analyzer.Reader;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ada.Framework.Development.Log4Me.Analyzer
{
    public class Analyzer
    {
        private FileLogReader Reader { get; set; }

        public Analyzer()
        {
            Reader = new FileLogReader();
        }

        public ResumenLog4MeModel ObtenerResumen(string ruta)
        {
            ResumenLog4MeModel retorno = new ResumenLog4MeModel();
            retorno.Analisis.Inicio = DateTime.Now;
            retorno.Log.Nombre = ruta;

            IDictionary<string, bool> Hilos = new Dictionary<string, bool>();

            IDictionary<string, RegistroInLineTO> flujoInicio = new Dictionary<string, RegistroInLineTO>();
            IDictionary<string, RegistroInLineTO> flujoRetorno = new Dictionary<string, RegistroInLineTO>();

            IDictionary<string, RegistroInLineTO> metodoInicio = new Dictionary<string, RegistroInLineTO>();
            IDictionary<string, RegistroInLineTO> metodoRetorno = new Dictionary<string, RegistroInLineTO>();

            Reader.LeerArchivo(ruta, (registro =>
                {
                    if (!Hilos.ContainsKey(registro.ThreadGUID))
                    {
                        Hilos.Add(registro.ThreadGUID, true);
                    }

                    if (!retorno.Log.Inicio.HasValue)
                    {
                        retorno.Log.Inicio = registro.Fecha;
                    }

                    if (registro.Tipo == "Excepcion")
                    {
                        retorno.ExcepcionesLanzadas++;
                        retorno.Excepciones.Add(new ExcepcionTO()
                        {
                            Tipo = registro.TipoExcepcion,
                            StackTrace = registro.StackTrace,
                            Mensaje = registro.Mensaje,
                            Data = registro.Data,
                            Metodo = new MetodoTO()
                            {
                                MethodGUID = registro.MethodGUID,
                                Hilo = new HiloTO()
                                {
                                    ThreadGUID = registro.ThreadGUID
                                }
                            }
                        });
                    }

                    if (registro.Tipo == "Inicio")
                    {
                        retorno.MetodosEjecutados++;

                        if (flujoInicio.ContainsKey(registro.ThreadGUID))
                        {
                            if (flujoInicio[registro.ThreadGUID].Fecha > registro.Fecha)
                            {
                                flujoInicio[registro.ThreadGUID] = registro;
                            }
                        }
                        else
                        {
                            flujoInicio.Add(registro.ThreadGUID, registro);
                        }

                        if (metodoInicio.ContainsKey(registro.MethodGUID))
                        {
                            if (metodoInicio[registro.MethodGUID].Fecha > registro.Fecha)
                            {
                                metodoInicio[registro.MethodGUID] = registro;
                            }
                        }
                        else
                        {
                            metodoInicio.Add(registro.MethodGUID, registro);
                        }
                    }

                    if (registro.Tipo == "Retorno")
                    {
                        if (flujoRetorno.ContainsKey(registro.ThreadGUID))
                        {
                            if (flujoRetorno[registro.ThreadGUID].Fecha < registro.Fecha)
                            {
                                flujoRetorno[registro.ThreadGUID] = registro;
                            }
                        }
                        else
                        {
                            flujoRetorno.Add(registro.ThreadGUID, registro);
                        }

                        if (metodoRetorno.ContainsKey(registro.MethodGUID))
                        {
                            if (metodoRetorno[registro.MethodGUID].Fecha < registro.Fecha)
                            {
                                metodoRetorno[registro.MethodGUID] = registro;
                            }
                        }
                        else
                        {
                            metodoRetorno.Add(registro.MethodGUID, registro);
                        }
                    }

                    retorno.Log.Termino = registro.Fecha;
                }));
            retorno.FlujosEjecutados = Hilos.Count;
            retorno.FlujoMasDemoroso = ObtenerMasCostoso(flujoInicio, flujoRetorno, false);
            retorno.MetodoMasDemoroso = ObtenerMasCostoso(metodoInicio, metodoRetorno, true);
            retorno.Analisis.Termino = DateTime.Now;
            return retorno;
        }

        private ResultadoMedicionModel<string> ObtenerMasCostoso(IDictionary<string, RegistroInLineTO> tiemposInicio, IDictionary<string, RegistroInLineTO> tiemposRetorno, bool Hilo)
        {
            List<string> identificadores = tiemposInicio.Keys.ToList();

            ResultadoMedicionModel<string> retorno = new ResultadoMedicionModel<string>()
            {
                ID = identificadores[0],
                Inicio = tiemposInicio[identificadores[0]].Fecha,
                Termino = tiemposRetorno[identificadores[0]].Fecha,
                Nombre = Hilo ? tiemposInicio[identificadores[0]].Metodo : null
            };

            foreach (string id in identificadores)
            {
                if (!tiemposRetorno.ContainsKey(id))
                {
                    throw new Exception(string.Format("No se ha logeado el retorno en el método {0}", tiemposInicio[id].Clase + "." + tiemposInicio[id].Metodo.Split(' ')[1]));
                }

                if ((tiemposRetorno[id].Fecha - tiemposInicio[id].Fecha) > retorno.Total)
                {
                    retorno.ID = id;
                    retorno.Inicio = tiemposInicio[id].Fecha;
                    retorno.Termino = tiemposRetorno[id].Fecha;
                    retorno.Nombre = Hilo ? tiemposInicio[id].Metodo : id;
                }
            }

            if (Hilo)
            {
                string[] array = retorno.Nombre.Split(' ');
                if (array.Length == 2)
                {
                    retorno.Nombre = array[1];
                }
            }

            return retorno;
        }

        public IList<RegistroInLineTO> ObtenerFlujo(string ruta, string ThreadGUID)
        {
            IList<RegistroInLineTO> retorno = new List<RegistroInLineTO>();
            Reader.LeerArchivo(ruta, registro => { if (registro.ThreadGUID == ThreadGUID) { retorno.Add(registro); } });
            return retorno;
        }

        public IList<RegistroInLineTO> ObtenerMetodo(string ruta, string MethodGUID)
        {
            IList<RegistroInLineTO> retorno = new List<RegistroInLineTO>();
            Reader.LeerArchivo(ruta, registro => { if (registro.MethodGUID == MethodGUID) { retorno.Add(registro); } });
            return retorno;
        }

        public IList<string> ObtenerFlujos(string ruta)
        {
            IList<string> retorno = new List<string>();
            Reader.LeerArchivo(ruta, registro => { if (!retorno.Contains(registro.ThreadGUID)) { retorno.Add(registro.ThreadGUID); } });
            return retorno;
        }

        public IList<string> ObtenerMetodos(string ruta, string ThreadGUID)
        {
            IList<string> retorno = new List<string>();
            Reader.LeerArchivo(ruta, registro => { if (!retorno.Contains(registro.MethodGUID) && registro.ThreadGUID == ThreadGUID) { retorno.Add(registro.MethodGUID); } });
            return retorno;
        }
    }
}
