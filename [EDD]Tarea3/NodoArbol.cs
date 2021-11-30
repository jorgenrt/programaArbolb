using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arboles
{
    class NodoArbol
    {
        public string dato { get; set; }
        public NodoArbol izquierdo { get; set; }
        public NodoArbol derecho { get; set; }

        public NodoArbol(string dato)
        {
            this.dato = dato;
            this.izquierdo = null;
            this.derecho = null;
        }

    }
}
