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
    public partial class frmAuditoriasEmpleado : Form
    {
        private string usuario; 
        private string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\ControlDeUsuarios.accdb";
        public frmAuditoriasEmpleado(string usuarioLogueado)
        {
            InitializeComponent();
            usuario = usuarioLogueado;
        }

        private void frmAuditoriasEmpleado_Load(object sender, EventArgs e)
        {
            CargarRegistrosUsuario();
        }
        private void CargarRegistrosUsuario()
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    string consulta = "SELECT * FROM Registros WHERE Usuario = ? ORDER BY idRegistro DESC";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(consulta, conexion);
                    adapter.SelectCommand.Parameters.AddWithValue("?", usuario);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvMostrar.DataSource = dt;

                    dgvMostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvMostrar.ReadOnly = true;
                    dgvMostrar.AllowUserToAddRows = false;
                    dgvMostrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar registros: " + ex.Message);
            }
        }
    }
}
