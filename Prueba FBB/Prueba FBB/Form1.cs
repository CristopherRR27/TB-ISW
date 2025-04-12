using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_FBB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Formulario = new Form2();
            Formulario.Show();
        }

        private void btnPropietario_Click(object sender, EventArgs e)
        {
            Form Formulario = new Form5();
            Formulario.Show();
        }

        private void btnCA_Click(object sender, EventArgs e)
        {
            Form Formulario = new Form4();
            Formulario.Show();
        }
    }
}
