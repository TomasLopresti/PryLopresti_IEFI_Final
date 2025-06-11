using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryLopresti_IEFI_Final
{
    public partial class frmAuditoriasAdmin : Form
    {

        private string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\ControlDeUsuarios.accdb";
        public frmAuditoriasAdmin()
        {
            InitializeComponent();
        }

        private void frmAuditoriasAdmin_Load(object sender, EventArgs e)
        {
            CargarRegistros();
            using (OleDbConnection con = new OleDbConnection(cadenaConexion))
            {
                con.Open();
                string query = "SELECT Usuario FROM Usuarios";
                OleDbCommand cmd = new OleDbCommand(query, con);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbNombre.Items.Add(reader["Usuario"].ToString());
                }
            }
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd-mm-yyyy";
            dtpFecha.ShowCheckBox = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(cadenaConexion))
            {
                con.Open();

                string query = "SELECT * FROM Registros WHERE 1=1";
                List<OleDbParameter> parametros = new List<OleDbParameter>();

                if (!string.IsNullOrEmpty(cmbNombre.Text))
                {
                    query += " AND Usuario = ?";
                    parametros.Add(new OleDbParameter("?", cmbNombre.Text));
                }

                if (dtpFecha.Checked)
                {
                    query += " AND Format(HoraIngreso, 'yyyy-mm-dd') = ?";
                    string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                    parametros.Add(new OleDbParameter("?", fecha));
                }

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    foreach (var param in parametros)
                    {
                        cmd.Parameters.Add(param);
                    }

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMostrar.DataSource = dt;
                }
            }
            cmbNombre.SelectedIndex = -1;
        }
        private void CargarRegistros()
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    string consulta = "SELECT * FROM Registros ORDER BY idRegistro DESC"; // ordena para ver primero los más recientes
                    OleDbDataAdapter adapter = new OleDbDataAdapter(consulta, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvMostrar.DataSource = dt;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar registros: " + ex.Message);
            }
        }
    }
}
