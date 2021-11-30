using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Arboles
{
    public partial class Form1 : Form
    {
        arbolBinario arbol;
        public Form1()
        {
            InitializeComponent();
            arbol = new arbolBinario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                arbol.insertar(textBox1.Text);

                textBox2.Text = arbol.inorden();
                textBox3.Text = arbol.preorden();
                textBox4.Text = arbol.postorden();

                string ruta = arbol.graficar();

                System.Threading.Thread.Sleep(1000);

                FileStream file = new FileStream(ruta, FileMode.Open);
                Image img = Image.FromStream(file);
                pictureBox1.Image = img;
                file.Close();

            }

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            arbol.limpiar();

            textBox2.Text = arbol.inorden();
            textBox3.Text = arbol.preorden();
            textBox4.Text = arbol.postorden();

            string ruta = arbol.graficar();

            System.Threading.Thread.Sleep(1000);

            FileStream file = new FileStream(ruta, FileMode.Open);
            Image img = Image.FromStream(file);
            pictureBox1.Image = img;
            file.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
