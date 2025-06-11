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
    public partial class frmPrincipalAdmin : Form
    {
        private string usuario;
        private DateTime horaIngreso;
        private int idRegistro;
        private Timer time;
        public frmPrincipalAdmin(string usuario, DateTime horaIngreso, int idRegistro)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.horaIngreso = horaIngreso;
            this.idRegistro = idRegistro;
        }
        clsConexión Conexión = new clsConexión();

        private void frmPrincipalAdmin_Load(object sender, EventArgs e)
        {
            lblUsuarioIngreso.Text = usuario;
            horaIngreso = DateTime.Now;
            temporizador = new Timer();
            temporizador.Interval = 1000; // 1 segundo
            temporizador.Tick += Temporizador_Tick;
            temporizador.Start();
        }
        private void Temporizador_Tick(object sender, EventArgs e)
        {
            TimeSpan transcurrido = DateTime.Now - horaIngreso;
            lblFechaYHora.Text = $"Tiempo transcurrido: {transcurrido.Hours:D2}:{transcurrido.Minutes:D2}:{transcurrido.Seconds:D2}";
        }

        private void frmPrincipalAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            DateTime horaEgreso = DateTime.Now;
            TimeSpan tiempo = horaEgreso - horaIngreso;
            string tiempoFormateado = tiempo.ToString(@"hh\:mm\:ss");

            using (OleDbConnection conexion = new OleDbConnection(
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\ControlDeUsuarios.accdb"))
            {
                // Usamos ? y pasamos los parámetros en orden
                string consulta = "UPDATE Registros SET HoraEgreso = ?, TiempoTranscurrido = ? WHERE idRegistro = ?";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    // HoraEgreso: tipo Date
                    comando.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.Date, Value = horaEgreso });

                    // TiempoTranscurrido: tipo VarChar porque es texto (ej: 01:25:33)
                    comando.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.VarChar, Value = tiempoFormateado });

                    // idRegistro: tipo Integer
                    comando.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.Integer, Value = idRegistro });

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }

            MessageBox.Show(
                $"Gracias por usar el sistema, {usuario}.\nTiempo total conectado: {tiempo.Hours} horas, {tiempo.Minutes} minutos, {tiempo.Seconds} segundos.",
                "Sesión finalizada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Application.Exit();
        }

        private void tareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTareasAdmin v = new frmTareasAdmin();
            v.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarioAdmin v = new frmUsuarioAdmin();
            v.ShowDialog();
        }

        private void auditoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditoriasAdmin v = new frmAuditoriasAdmin();
            v.ShowDialog();
        }
    }
}
