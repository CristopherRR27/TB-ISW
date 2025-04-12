using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_FBB
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void GuardarReporte(string contenido)
        {
            string rutaDirectorio = @"C:\Users\Cristopher_R_R#27\Desktop\Reportes Emitidos";
            string nombreArchivo = $"Reporte de Alquiler_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string ruta = Path.Combine(rutaDirectorio, nombreArchivo);
            try
            {
                Directory.CreateDirectory(rutaDirectorio);
                File.WriteAllText(ruta, contenido);
                MessageBox.Show("Reporte generado exitosamente:\n" + ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo:\n" + ex.Message);
            }
        }

        private void GuardarReporte2(string contenido2)
        {
            string rutaDirectorio = @"C:\Users\Cristopher_R_R#27\Desktop\Reportes Emitidos";
            string nombreArchivo = $"Reporte de Compra_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string ruta = Path.Combine(rutaDirectorio, nombreArchivo);
            try
            {
                Directory.CreateDirectory(rutaDirectorio);
                File.WriteAllText(ruta, contenido2);
                MessageBox.Show("Reporte generado exitosamente:\n" + ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo:\n" + ex.Message);
            }
        }

        public void CargarDatos()
        {
            string connectionString = "Data Source=Acm-user16;Initial Catalog=YO;Integrated Security=true";
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Registro";
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                dgvDetalles2.DataSource = DT;

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"server=Acm-user16;database=YO;integrated security = true");
            conexion.Open();
            int codigo = int.Parse(txtidPropiedad.Text);
            string cadena = "select Nombre, Nombre_Propiedad, Ubicacion_Propiedad, Descripcion_Propiedad, Precio_X_Dia, Precio_X_Compra from Registro where Id_Propiedad =" + codigo;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtNombre.Text = registro["Nombre"].ToString();
                txtNomPropiedad.Text = registro["Nombre_Propiedad"].ToString();
                txtUbiPropiedad.Text = registro["Ubicacion_Propiedad"].ToString();
                txtDescPropiedad.Text = registro["Descripcion_Propiedad"].ToString();
                txtPrecioD.Text = registro["Precio_X_Dia"].ToString();
                txtPrecioC.Text = registro["Precio_X_Compra"].ToString();

            }
            else
            {
                MessageBox.Show("Propiedad No Encontrada");
            }
            conexion.Close();
        }

        private void btnAlquilar_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"server=Acm-user16;database=Yo;integrated security = true");

            string strSql = "UPDATE Registro SET Estado = @Estado WHERE Id_Propiedad = @Id_Propiedad";

            SqlCommand cmd = new SqlCommand(strSql, Con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Estado", "Alquilado");

            cmd.Parameters.AddWithValue("@Id_Propiedad", txtidPropiedad.Text);

            try
            {
                Con.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                Con.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show(" Estado actualizado a 'Alquilado'.");
                }
                else
                {
                    MessageBox.Show(" No se encontró una propiedad con ese ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }


            try
            {
                string id = txtidPropiedad.Text.Trim();
                string dias = txtDiasA.Text.Trim();
                string precioDia = txtPrecioD.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string nombreProp = txtNomPropiedad.Text.Trim();
                string ubicacion = txtUbiPropiedad.Text.Trim();
                string descripcion = txtDescPropiedad.Text.Trim();

                double total = Convert.ToDouble(dias) * Convert.ToDouble(precioDia);

                string contenido = "===== REPORTE DE ALQUILER =====\n" +
                                   $"ID Propiedad: {id}\n" +
                                   $"Nombre del Propietario: {nombre}\n" +
                                   $"Nombre de la Propiedad: {nombreProp}\n" +
                                   $"Ubicación: {ubicacion}\n" +
                                   $"Descripción: {descripcion}\n" +
                                   $"Días de Alquiler: {dias}\n" +
                                   $"Precio por Día: {precioDia}\n" +
                                   $"TOTAL: {total:C}\n" +
                                   $"Fecha: {DateTime.Now}\n" +
                                   "===============================";

                GuardarReporte(contenido);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            txtidPropiedad.Clear();
            txtDiasA.Clear();
            txtPrecioD.Clear();
            txtPrecioC.Clear();
            txtNombre.Clear();
            txtNomPropiedad.Clear();
            txtUbiPropiedad.Clear();
            txtDescPropiedad.Clear();

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {

            SqlConnection Con = new SqlConnection(@"server=Acm-user16;database=Yo;integrated security = true");

            string strSql = "UPDATE Registro SET Estado = @Estado WHERE Id_Propiedad = @Id_Propiedad";

            SqlCommand cmd = new SqlCommand(strSql, Con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Estado", "Comprado");

            cmd.Parameters.AddWithValue("@Id_Propiedad", txtidPropiedad.Text);

            try
            {
                Con.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                Con.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Estado actualizado a 'Comprado'.");
                }
                else
                {
                    MessageBox.Show(" No se encontró una propiedad con ese ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            try
            {
                string id = txtidPropiedad.Text.Trim();
                string dias = txtDiasA.Text.Trim();
                string precioCompra = txtPrecioC.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string nombreProp = txtNomPropiedad.Text.Trim();
                string ubicacion = txtUbiPropiedad.Text.Trim();
                string descripcion = txtDescPropiedad.Text.Trim();

                string total = precioCompra;

                string contenido2 = "===== REPORTE DE ALQUILER =====\n" +
                                   $"ID Propiedad: {id}\n" +
                                   $"Nombre del Propietario: {nombre}\n" +
                                   $"Nombre de la Propiedad: {nombreProp}\n" +
                                   $"Ubicación: {ubicacion}\n" +
                                   $"Descripción: {descripcion}\n" +
                                   $"Precio por Compra: {precioCompra}\n" +
                                   $"TOTAL: {total:C}\n" +
                                   $"Fecha: {DateTime.Now}\n" +
                                   "===============================";

                GuardarReporte2(contenido2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            txtidPropiedad.Clear();
            txtDiasA.Clear();
            txtPrecioD.Clear();
            txtPrecioC.Clear();
            txtNombre.Clear();
            txtNomPropiedad.Clear();
            txtUbiPropiedad.Clear();
            txtDescPropiedad.Clear();
        }

    }
    
}

