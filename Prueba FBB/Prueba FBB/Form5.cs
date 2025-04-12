using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_FBB
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            String strSql;
            strSql = "Select * from Propietarios where Usuario = @Usuario AND Contrasena = @Contrasena";
            SqlConnection Con = new SqlConnection(@"Server=Acm-User16;Database=YO;Integrated Security=True");
            SqlDataAdapter DA = new SqlDataAdapter(strSql, Con);
            Con.Open();

            DA.SelectCommand.CommandType = CommandType.Text;
            DA.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar, 15).Value = txtUsuario.Text;
            DA.SelectCommand.Parameters.Add("@Contrasena", SqlDbType.VarChar, 15).Value = txtContrasena.Text;

            DA.Fill(DT);
            if (DT.Rows.Count > 0)
            {
                Form Formulario = new Form3();
                Formulario.Show();
            }
            else
            {
                MessageBox.Show("Usuario incorrecto");
                txtContrasena.Focus();
            }
            Con.Close();

            txtUsuario.Clear();
            txtContrasena.Clear();

            this.Close();
        }
    }
}
