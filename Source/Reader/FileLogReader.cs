using Ada.Framework.Development.Log4Me.Analyzer.Entities;
using FileHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ada.Framework.Development.Log4Me.Analyzer.Reader
{
    public class FileLogReader
    {
        public delegate void ProcesadorRegistroLog(RegistroInLineTO registro);

        public void AnalizarRegistros(IList<RegistroInLineTO> registros, ProcesadorRegistroLog procesadorRegistro)
        {
            foreach (RegistroInLineTO registro in registros)
            {
                procesadorRegistro(registro);
            }
        }

        public void LeerArchivo(string ruta, ProcesadorRegistroLog procesadorRegistro, int cantidadRegistrosBloque = 100)
        {
            FileHelperAsyncEngine<RegistroInLineTO> reader = new FileHelperAsyncEngine<RegistroInLineTO>();

            using (reader.BeginReadFile(ruta))
            {
                RegistroInLineTO[] registros = reader.ReadNexts(cantidadRegistrosBloque);
                while (registros.Length > 0)
                {
                    AnalizarRegistros(registros, procesadorRegistro);
                    registros = reader.ReadNexts(cantidadRegistrosBloque);
                }
            }
        }

        public void LeerArchivoMasivamente(string ruta, ProcesadorRegistroLog procesadorRegistro, int registrosPorHilo)
        {
            FileHelperAsyncEngine<RegistroInLineTO> reader = new FileHelperAsyncEngine<RegistroInLineTO>();

            using (reader.BeginReadFile(ruta))
            {
                IList<Task> tareas = new List<Task>();

                RegistroInLineTO[] registros = reader.ReadNexts(registrosPorHilo);
                while (registros.Length > 0)
                {
                    tareas.Add(new Task(() => { AnalizarRegistros(registros, procesadorRegistro); }));
                }
                Task.WaitAll(tareas.ToArray());
            }
        }
    }
}
