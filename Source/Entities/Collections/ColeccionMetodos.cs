using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Analyzer.Entities.Collections
{
    public class ColeccionMetodos : IList<MetodoTO>, ICollection<MetodoTO>, IEnumerable<MetodoTO>
    {
        public HiloTO Hilo { get; set; }

        public ColeccionMetodos(HiloTO hilo)
        {
            Hilo = hilo;
        }

        private List<MetodoTO> Coleccion = new List<MetodoTO>();

        public int IndexOf(MetodoTO item)
        {
            return Coleccion.IndexOf(item);
        }

        public void Insert(int index, MetodoTO item)
        {
            item.Hilo = Hilo;
            Coleccion.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Coleccion.RemoveAt(index);
        }

        public MetodoTO this[int index]
        {
            get
            {
                return Coleccion[index];
            }
            set
            {
                value.Hilo = Hilo;
                Coleccion[index] = value;
            }
        }

        public void Add(MetodoTO item)
        {
            item.Hilo = Hilo;
            Coleccion.Add(item);
        }

        public void Clear()
        {
            Coleccion.Clear();
        }

        public bool Contains(MetodoTO item)
        {
            return Coleccion.Contains(item);
        }

        public void CopyTo(MetodoTO[] array, int arrayIndex)
        {
            Coleccion.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Coleccion.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(MetodoTO item)
        {
            return Coleccion.Remove(item);
        }

        public IEnumerator<MetodoTO> GetEnumerator()
        {
            return Coleccion.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Coleccion.GetEnumerator();
        }
    }
}
