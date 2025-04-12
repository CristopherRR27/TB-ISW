using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Prueba_FBB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void btnRegistrar_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"server=Acm-user16;database=Yo;integrated security = true");
            string strSql;
            strSql = "insert into Registro (Id_Propiedad,Nombre,Numero,Nombre_Propiedad,Ubicacion_Propiedad,Descripcion_Propiedad,Precio_X_Dia,Precio_X_Compra,Estado) values (@Id_Propiedad,@Nombre,@Numero,@Nombre_Propiedad,@Ubicacion_Propiedad,@Descripcion_Propiedad,@Precio_X_Dia,@Precio_X_Compra,@Estado)";
            SqlCommand cmd = new SqlCommand(strSql, Con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("Id_Propiedad",txtidPropiedad.Text);
            cmd.Parameters.AddWithValue("Nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("Numero", txtNumTelefono.Text);
            cmd.Parameters.AddWithValue("Nombre_Propiedad", txtNomPropiedad.Text);
            cmd.Parameters.AddWithValue("Ubicacion_Propiedad", txtUbiPropiedad.Text);
            cmd.Parameters.AddWithValue("Descripcion_Propiedad", txtDescPropiedad.Text);
            cmd.Parameters.AddWithValue("Precio_X_Dia", txtPrecioxD.Text); 
            cmd.Parameters.AddWithValue("Precio_X_Compra", txtPrecioxC.Text);
            cmd.Parameters.AddWithValue("Estado", "Disponible");

            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            MessageBox.Show("Registro Completo");

            txtidPropiedad.Clear();
            txtNombre.Clear();
            txtNumTelefono.Clear();
            txtNomPropiedad.Clear();
            txtUbiPropiedad.Clear();
            txtDescPropiedad.Clear();
            txtPrecioxD.Clear();
            txtPrecioxC.Clear();
        }

        private void btnRegistrarUsu_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"server=Acm-user16;database=Yo;integrated security = true");
            string strSql;
            strSql = "insert into Propietarios (Usuario,Contrasena) values (@Usuario,@Contrasena)";
            SqlCommand cmd = new SqlCommand(strSql, Con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("Usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("Contrasena", txtContrasena.Text);


            Con.Open();
            cmd.ExecuteNonQuery();
            Con.Close();

            MessageBox.Show("Registro Completo");

            this.Close();

            txtUsuario.Clear();
            txtContrasena.Clear();

        }
    }
}
