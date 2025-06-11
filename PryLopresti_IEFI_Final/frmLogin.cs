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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        clsConexión conexión = new clsConexión();
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
            conexión.Llenar(cmbCargo);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            string cargoSeleccionado = cmbCargo.Text.Trim();

            if (usuario == "" || contraseña == "" || cargoSeleccionado == "")
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (conexión.ValidarCredenciales(usuario, contraseña, cargoSeleccionado))
            {
                // Guardar hora de ingreso y registro
                DateTime horaIngreso = DateTime.Now;
                int idRegistro = 0;

                using (OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\ControlDeUsuarios.accdb"))
                {
                    string consulta = "INSERT INTO Registros (Usuario, HoraIngreso) VALUES (@usuario, @horaIngreso)";
                    OleDbCommand comando = new OleDbCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.Date, Value = horaIngreso });

                    conexion.Open();
                    comando.ExecuteNonQuery();

                    comando.CommandText = "SELECT @@IDENTITY";
                    idRegistro = Convert.ToInt32(comando.ExecuteScalar());
                }
                // Pasar datos al formulario principal
                if (cargoSeleccionado == "Administrador")
                {
                    frmPrincipalAdmin admin = new frmPrincipalAdmin(usuario, horaIngreso, idRegistro);
                    admin.Show();
                }
                else if (cargoSeleccionado == "Empleado")
                {
                    frmPrincipalEmpleado empleado = new frmPrincipalEmpleado(usuario, horaIngreso, idRegistro);
                    empleado.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas o cargo no coincide.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMostrar.Checked)
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
    }
}
