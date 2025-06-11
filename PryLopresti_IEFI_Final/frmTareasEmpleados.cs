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
    public partial class frmTareasEmpleados : Form
    {
        string usuarioLogueado;
        public frmTareasEmpleados(string usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }
        clsConexión conexión = new clsConexión();

        private void frmTareasEmpleados_Load(object sender, EventArgs e)
        {
            dgvTareas.Columns.Add("IdTarea", "IdTarea");
            dgvTareas.Columns["IdTarea"].Visible = false;
            dgvTareas.Columns.Add("TareaNombre", "Tarea");
            dgvTareas.Columns.Add("IdLugar", "IdLugar");
            dgvTareas.Columns["IdLugar"].Visible = false;
            dgvTareas.Columns.Add("LugarNombre", "Lugar");
            dgvTareas.Columns.Add("Fecha", "Fecha");
            CargarTareas();
            CargarLugares();
            CargarRegistroTareas();
            dtpFecha.MaxDate = DateTime.Today;
        }

        private void btnAgregrar_Click(object sender, EventArgs e)
        {
            if (cmbTareas.SelectedItem == null || cmbLugares.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccioná una tarea y un lugar.");
                return;
            }

            var tarea = (KeyValuePair<int, string>)cmbTareas.SelectedItem;
            var lugar = (KeyValuePair<int, string>)cmbLugares.SelectedItem;
            DateTime fecha = dtpFecha.Value;

            dgvTareas.Rows.Add(tarea.Key, tarea.Value, lugar.Key, lugar.Value, fecha);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.Rows.Count == 0)
            {
                MessageBox.Show("No hay tareas para grabar.");
                return;
            }

            string consulta = "INSERT INTO RegistroTareas (Usuario, Tarea, Lugar, Fecha, Comentarios, Insumos, Estudio, Vacaciones, Salario, Recibo) " +
                              "VALUES (@Usuario, @Tarea, @Lugar, @Fecha, @Comentarios, @Insumos, @Estudio, @Vacaciones, @Salario, @Recibo)";

            try
            {
                conexión.conexión.Open();

                foreach (DataGridViewRow fila in dgvTareas.Rows)
                {
                    if (fila.IsNewRow) continue;

                    OleDbCommand comando = new OleDbCommand(consulta, conexión.conexión);
                    comando.Parameters.AddWithValue("@Usuario", usuarioLogueado);
                    comando.Parameters.AddWithValue("@Tarea", fila.Cells["IdTarea"].Value);
                    comando.Parameters.AddWithValue("@Lugar", fila.Cells["IdLugar"].Value);
                    comando.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fila.Cells["Fecha"].Value));
                    comando.Parameters.AddWithValue("@Comentarios", txtComentarios.Text);
                    comando.Parameters.AddWithValue("@Insumos", chkInsumo.Checked);
                    comando.Parameters.AddWithValue("@Estudio", chkEstudio.Checked);
                    comando.Parameters.AddWithValue("@Vacaciones", chkVacaciones.Checked);
                    comando.Parameters.AddWithValue("@Salario", chkSalario.Checked);
                    comando.Parameters.AddWithValue("@Recibo", chkRecibo.Checked);
                    comando.ExecuteNonQuery();
                }

                MessageBox.Show("Tareas guardadas correctamente.");
                CargarRegistroTareas();
                dgvTareas.Rows.Clear();
                txtComentarios.Clear();
                chkInsumo.Checked = chkEstudio.Checked = chkVacaciones.Checked = chkSalario.Checked = chkRecibo.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al grabar: " + ex.Message);
            }
            finally
            {
                if (conexión.conexión.State == ConnectionState.Open)
                    conexión.conexión.Close();
            }

        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            dgvTareas.Rows.Clear();
            txtComentarios.Clear();
            chkInsumo.Checked = chkEstudio.Checked = chkVacaciones.Checked = chkSalario.Checked = chkRecibo.Checked = false;

            cmbLugares.SelectedIndex = -1;
            cmbTareas.SelectedIndex = -1;


            dtpFecha.MinDate = DateTimePicker.MinimumDateTime;
            dtpFecha.MaxDate = DateTimePicker.MaximumDateTime;


            dtpFecha.Value = DateTime.Now;
        }
        private void CargarTareas()
        {
            cmbTareas.Items.Clear();
            string consulta = "SELECT IdTarea, Tarea FROM Tareas";
            OleDbCommand comando = new OleDbCommand(consulta, conexión.conexión);
            conexión.conexión.Open();
            OleDbDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                cmbTareas.Items.Add(new KeyValuePair<int, string>((int)lector["IdTarea"], lector["Tarea"].ToString()));
            }
            lector.Close();
            conexión.conexión.Close();
            cmbTareas.DisplayMember = "Value";
            cmbTareas.ValueMember = "Key";
        }
        private void CargarLugares()
        {
            cmbLugares.Items.Clear();
            string consulta = "SELECT IdLugar, Lugar FROM Lugares";
            OleDbCommand comando = new OleDbCommand(consulta, conexión.conexión);
            conexión.conexión.Open();
            OleDbDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                cmbLugares.Items.Add(new KeyValuePair<int, string>((int)lector["IdLugar"], lector["Lugar"].ToString()));
            }
            lector.Close();
            conexión.conexión.Close();
            cmbLugares.DisplayMember = "Value";
            cmbLugares.ValueMember = "Key";
        }
        private void CargarRegistroTareas()
        {
            try
            {
                string consulta = "SELECT " +
                                  "RegistroTareas.Usuario, " +
                                  "Tareas.Tarea AS Tarea, " +
                                  "Lugares.Lugar AS Lugar, " +
                                  "RegistroTareas.Fecha, " +
                                  "RegistroTareas.Comentarios, " +
                                  "RegistroTareas.Insumos, " +
                                  "RegistroTareas.Estudio, " +
                                  "RegistroTareas.Vacaciones, " +
                                  "RegistroTareas.Salario, " +
                                  "RegistroTareas.Recibo " +
                                  "FROM (RegistroTareas " +
                                  "INNER JOIN Tareas ON RegistroTareas.Tarea = Tareas.IdTarea) " +
                                  "INNER JOIN Lugares ON RegistroTareas.Lugar = Lugares.IdLugar";

                OleDbDataAdapter adaptador = new OleDbDataAdapter(consulta, conexión.conexión);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvMostrar.DataSource = tabla;

                // Ajustes visuales
                dgvMostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMostrar.RowHeadersVisible = false;

                // Colorear booleanos
                foreach (DataGridViewRow fila in dgvMostrar.Rows)
                {
                    foreach (string campo in new[] { "Insumos", "Estudio", "Vacaciones", "Salario", "Recibo" })
                    {
                        if (fila.Cells[campo].Value != DBNull.Value)
                        {
                            bool valor = Convert.ToBoolean(fila.Cells[campo].Value);
                            fila.Cells[campo].Style.BackColor = valor ? Color.Red : Color.LightGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros: " + ex.Message);
            }
        }
        private void PintarCelda(DataGridViewRow fila, string nombreColumna)
        {
            if (fila.Cells[nombreColumna].Value != DBNull.Value)
            {
                bool valor = Convert.ToBoolean(fila.Cells[nombreColumna].Value);
                fila.Cells[nombreColumna].Style.BackColor = valor ? Color.LightGreen : Color.LightCoral;
                fila.Cells[nombreColumna].Style.ForeColor = Color.Black;
                fila.Cells[nombreColumna].Value = valor ? "Sí" : "No";
            }
        }

    }
}
