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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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
                dgvDetalles.DataSource = DT;

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=Acm-user16;Initial Catalog=YO;Integrated Security=true";
            string valorBuscado = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(valorBuscado))
            {
                MessageBox.Show("Por favor ingresa un valor para eliminar.");
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                Con.Open();
                string query = "DELETE FROM Registro WHERE id_Propiedad = @valor";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@valor", valorBuscado);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro eliminado exitosamente.");
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("No se encontró un registro con ese valor.");
                }

                txtBuscar.Clear();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=Acm-user16;Initial Catalog=YO;Integrated Security=true";
            string valorBuscado = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(valorBuscado))
            {
                MessageBox.Show("Por favor ingresa un ID para buscar.");
                return;
            }

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                try
                {
                    Con.Open();
                    string query = "SELECT * FROM Registro WHERE Id_Propiedad = @Id_Propiedad";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Id_Propiedad", valorBuscado);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvDetalles.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún registro con ese ID.");
                        dgvDetalles.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar: " + ex.Message);
                }
                txtBuscar.Clear();
            }
        }
    }
}