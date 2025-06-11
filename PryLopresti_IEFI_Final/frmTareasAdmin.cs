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
    public partial class frmTareasAdmin : Form
    {
        public frmTareasAdmin()
        {
            InitializeComponent();
        }

        private void frmTareasAdmin_Load(object sender, EventArgs e)
        {
            MostrarTablas();
            Control();
            btnEliminarTarea.Enabled = false;
            btnEliminarLugar.Enabled = false;

            dgvTareas.CellClick += dgvTareas_CellClick;
            dgvLugares.CellClick += dgvLugares_CellClick;
        }
        private void MostrarTablas()
        {
            string cadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ControlDeUsuarios.accdb";

            using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
            {
                conexion.Open();

                
                string consultaTareas = "SELECT * FROM Tareas";
                OleDbDataAdapter adaptadorTareas = new OleDbDataAdapter(consultaTareas, conexion);
                DataTable tablaTareas = new DataTable();
                adaptadorTareas.Fill(tablaTareas);
                dgvTareas.DataSource = tablaTareas;

                
                string consultaLugares = "SELECT * FROM Lugares";
                OleDbDataAdapter adaptadorLugares = new OleDbDataAdapter(consultaLugares, conexion);
                DataTable tablaLugares = new DataTable();
                adaptadorLugares.Fill(tablaLugares);
                dgvLugares.DataSource = tablaLugares;
            }
        }
        public void Control()
        {
            if (txtLugares.Text != "")
            {
                btnAgregrarLugar.Enabled = true;
            }
            else
            {
                btnAgregrarLugar.Enabled = false;
            }
            if (txtTareas.Text != "")
            {
                btnAgregrarTarea.Enabled = true;
            }
            else
            {
                btnAgregrarTarea.Enabled = false;
            }
        }

        private void btnAgregrarTarea_Click(object sender, EventArgs e)
        {
            string tarea = txtTareas.Text.Trim();


            using (OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ControlDeUsuarios.accdb"))
            {
                conexion.Open();

                if (!string.IsNullOrEmpty(tarea))
                {
                    string consultaTarea = "INSERT INTO Tareas (Tarea) VALUES (@tarea)";
                    using (OleDbCommand cmd = new OleDbCommand(consultaTarea, conexion))
                    {
                        cmd.Parameters.AddWithValue("@tarea", tarea);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Datos agregados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtTareas.Clear();
            MostrarTablas();
        }

        private void btnAgregrarLugar_Click(object sender, EventArgs e)
        {
            string lugar = txtLugares.Text.Trim();

            using (OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ControlDeUsuarios.accdb"))
            {
                conexion.Open();

                if (!string.IsNullOrEmpty(lugar))
                {
                    string consultaTarea = "INSERT INTO Lugares (Lugar) VALUES (@lugar)";
                    using (OleDbCommand cmd = new OleDbCommand(consultaTarea, conexion))
                    {
                        cmd.Parameters.AddWithValue("@lugar", lugar);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Datos agregados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtLugares.Clear();
            MostrarTablas();
        }

        private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                txtTareas.Text = dgvTareas.Rows[e.RowIndex].Cells["Tarea"].Value?.ToString();
                btnEliminarTarea.Enabled = true;
            }
        }

        private void dgvLugares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtLugares.Text = dgvLugares.Rows[e.RowIndex].Cells["Lugar"].Value?.ToString();
                btnEliminarLugar.Enabled = true;
            }
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            string tarea = txtTareas.Text.Trim();

            if (string.IsNullOrEmpty(tarea))
            {
                MessageBox.Show("Seleccioná una tarea para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmación = MessageBox.Show($"¿Estás seguro de eliminar la tarea \"{tarea}\"?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmación == DialogResult.No)
                return;

            using (OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ControlDeUsuarios.accdb"))
            {
                conexion.Open();
                string consulta = "DELETE FROM Tareas WHERE Tarea = @tarea";
                using (OleDbCommand cmd = new OleDbCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@tarea", tarea);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Tarea eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTareas.Clear();
            btnEliminarTarea.Enabled = false;
            MostrarTablas();
        }

        private void btnEliminarLugar_Click(object sender, EventArgs e)
        {
            string lugar = txtLugares.Text.Trim();

            if (string.IsNullOrEmpty(lugar))
            {
                MessageBox.Show("Seleccioná un lugar para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmación = MessageBox.Show($"¿Estás seguro de eliminar el lugar \"{lugar}\"?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmación == DialogResult.No)
                return;

            using (OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ControlDeUsuarios.accdb"))
            {
                conexion.Open();
                string consulta = "DELETE FROM Lugares WHERE Lugar = @lugar";
                using (OleDbCommand cmd = new OleDbCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@lugar", lugar);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Lugar eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLugares.Clear();
            btnEliminarLugar.Enabled = false;
            MostrarTablas();
        }

        private void txtTareas_TextChanged(object sender, EventArgs e)
        {
            Control();
        }

        private void txtLugares_TextChanged(object sender, EventArgs e)
        {
            Control();
        }
    }
}
