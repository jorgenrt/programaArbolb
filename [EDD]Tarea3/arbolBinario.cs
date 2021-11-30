using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Arboles
{
    class arbolBinario
    {
        private NodoArbol raiz { get; set; }

        public arbolBinario()
        {
            this.raiz = null;
        }

        private string compararCadenas(string c1, string c2)
        {
            int index = c1.Length;

            if (c1.Length > c2.Length)
            {
                index = c2.Length;
            }

            int i;
            for (i = 0; i < index; i++)
            {
                if (Encoding.ASCII.GetBytes(c1[i].ToString())[0] < Encoding.ASCII.GetBytes(c2[i].ToString())[0])
                {
                    return c2;
                }
                else if (Encoding.ASCII.GetBytes(c1[i].ToString())[0] > Encoding.ASCII.GetBytes(c2[i].ToString())[0])
                {
                    return c1;
                }
            }

            if (c1.Length > c2.Length)
            {
                return c1;
            }

            return c2;
        }
        

        public void insertar(string dato)
        {
            NodoArbol nuevo = new NodoArbol(dato);

            if ( this.raiz == null)
            {
                this.raiz = nuevo;
            }
            else
            {
                if ( this.raiz.dato.Equals(dato) == false )
                {
                    if (compararCadenas(dato,this.raiz.dato).Equals(dato) == true)
                    {
                        this.raiz.derecho = insertar2(this.raiz.derecho, nuevo);
                    }
                    else if (compararCadenas(dato, this.raiz.dato).Equals(this.raiz.dato) == true)
                    {
                        this.raiz.izquierdo = insertar2(this.raiz.izquierdo, nuevo);
                    }
                }
            }
        }

        private NodoArbol insertar2(NodoArbol rama, NodoArbol nuevo)
        {
            if (rama == null)
            {
                rama = nuevo;
            }
            else
            {
                if ( rama.dato.Equals(nuevo.dato) == false)
                {
                    if (compararCadenas(rama.dato,nuevo.dato).Equals(nuevo.dato) == true)
                    {
                        rama.derecho = insertar2(rama.derecho, nuevo);
                    }
                    else if (compararCadenas(rama.dato, nuevo.dato).Equals(rama.dato) == true)
                    {
                        rama.izquierdo = insertar2(rama.izquierdo, nuevo);
                    }
                }

            }

            return rama;

            
        }

        public string inorden()
        {
            string cadena = "";

            return inorden2(this.raiz, ref cadena);
        }

        private string inorden2( NodoArbol rama,ref string cadena)
        {
            if (rama != null)
            {
                inorden2(rama.izquierdo, ref cadena);

                if (String.IsNullOrEmpty(cadena) == true)
                {
                    cadena += rama.dato;
                }
                else
                {
                    cadena += ", " + rama.dato;
                }

                inorden2(rama.derecho, ref cadena);
            }

            return cadena;
        }

        public string preorden()
        {
            string cadena = "";
            return preorden2(this.raiz, ref cadena);
        }

        private string preorden2(NodoArbol rama, ref string cadena)
        {
            if (rama != null)
            {
                if (String.IsNullOrEmpty(cadena) == true)
                {
                    cadena += rama.dato;
                }
                else
                {
                    cadena += ", " + rama.dato;
                }

                preorden2(rama.izquierdo,ref  cadena);
                preorden2(rama.derecho, ref cadena);
            }

            return cadena;
        }

        public string postorden()
        {
            string cadena = "";
            return postorden2(this.raiz, ref cadena);
        }

        private string postorden2(NodoArbol rama, ref string cadena)
        {
            if (rama != null)
            {
                postorden2(rama.izquierdo,ref cadena);
                postorden2(rama.derecho,ref cadena);

                if (String.IsNullOrEmpty(cadena) == true)
                {
                    cadena += rama.dato;
                }
                else
                {
                    cadena += ", " + rama.dato;
                }
            }

            return cadena;
        }

        public string graficar()
        {
            string dot = "digraph G {\n\nnode [shape = record,height=.1];\nsplines=\"line\";\n\n";
            
            graficar2(this.raiz, ref dot);

            dot += "}";

            StreamWriter sw = new StreamWriter("D:\\dot.txt");
            sw.Write(dot);
            sw.Close();

            string ruta = "D:\\dot.txt";
            string ruta2 = "D:\\Arbol.png";

            string cmd = "dot -Tpng " + ruta + " -o " + ruta2;

            System.Diagnostics.ProcessStartInfo miProceso = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cmd);
            System.Diagnostics.Process.Start(miProceso);


            return ruta2;
        }

        private void graficar2(NodoArbol rama, ref string cadena)
        {
            if ( rama != null)
            {
                cadena += "nodo" + rama.dato + "[label = \" <f2>|<f1> " + rama.dato + " |<f0> \"];\n";

                graficar2(rama.izquierdo, ref cadena);
                graficar2(rama.derecho, ref cadena);

                if (rama.izquierdo != null)
                {
                    cadena += "\"nodo" + rama.dato + "\":f2 -> \"nodo" + rama.izquierdo.dato + "\":f1;\n"; 
                }

                if (rama.derecho != null)
                {
                    cadena += "\"nodo" + rama.dato + "\":f0 -> \"nodo" + rama.derecho.dato + "\":f1;\n";
                }
            }
        }



        public void limpiar()
        {
            this.raiz = null;
        }
    }
}
