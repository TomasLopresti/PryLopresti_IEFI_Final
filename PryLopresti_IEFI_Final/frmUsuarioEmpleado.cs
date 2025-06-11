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
    public partial class frmUsuarioEmpleado : Form
    {
        string usuarioLogueado;
        public frmUsuarioEmpleado(string usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
        }
        clsConexión conexion = new clsConexión();
        private void frmUsuarioEmpleado_Load(object sender, EventArgs e)
        {
            txtNueva.UseSystemPasswordChar = true;
            txtRepetida.UseSystemPasswordChar = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string actual = txtActual.Text.Trim();
            string nueva = txtNueva.Text.Trim();
            string repetida = txtRepetida.Text.Trim();

            if (string.IsNullOrEmpty(actual) || string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(repetida))
            {
                MessageBox.Show("Por favor, completá todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nueva != repetida)
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Verificar contraseña actual
                string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseñaActual";
                using (OleDbCommand comando = new OleDbCommand(consulta, conexion.conexión))
                {
                    comando.Parameters.AddWithValue("@usuario", usuarioLogueado);
                    comando.Parameters.AddWithValue("@contraseñaActual", actual);

                    conexion.conexión.Open();
                    int existe = (int)comando.ExecuteScalar();
                    conexion.conexión.Close();

                    if (existe == 0)
                    {
                        MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Actualizar contraseña
                string actualizar = "UPDATE Usuarios SET Contraseña = @nueva WHERE Usuario = @usuario";
                using (OleDbCommand comando = new OleDbCommand(actualizar, conexion.conexión))
                {
                    comando.Parameters.AddWithValue("@nueva", nueva);
                    comando.Parameters.AddWithValue("@usuario", usuarioLogueado);

                    conexion.conexión.Open();
                    comando.ExecuteNonQuery();
                }


                string usuarioCambiar = usuarioLogueado;

                DialogResult confirmación = MessageBox.Show(
                    $"¿Estás seguro de que querés Modificar la contraseña de \"{usuarioCambiar}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );
                MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtActual.Clear();
                txtNueva.Clear();
                txtRepetida.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.conexión.State == ConnectionState.Open)
                    conexion.conexión.Close();
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMostrar.Checked)
            {
                txtNueva.UseSystemPasswordChar = true;
                txtRepetida.UseSystemPasswordChar = true;
            }
            else
            {
                txtNueva.UseSystemPasswordChar = false;
                txtRepetida.UseSystemPasswordChar = false;
            }
        }
    }
}
