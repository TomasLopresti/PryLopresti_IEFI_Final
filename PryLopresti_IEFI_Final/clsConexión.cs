using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryLopresti_IEFI_Final
{
    internal class clsConexión
    {
        public OleDbConnection conexión;
        private int idUltimoRegistro = -1;
        public clsConexión()
        {
            string ruta = Application.StartupPath + @"\ControlDeUsuarios.accdb"; // Dentro de bin\Debug
            string cadenaConexion = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};";

            conexión = new OleDbConnection(cadenaConexion);
        }
        public void Llenar(ComboBox Cmb)
        {
            try
            {
                Cmb.Items.Clear(); // Limpiar antes de cargar

                string consulta = "SELECT DISTINCT Cargo FROM Usuarios";
                OleDbCommand comando = new OleDbCommand(consulta, conexión);
                conexión.Open();
                OleDbDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Cmb.Items.Add(lector["Cargo"].ToString());
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox: " + ex.Message);
            }
            finally
            {
                if (conexión.State == ConnectionState.Open)
                    conexión.Close();
            }
        }

        public bool ValidarCredenciales(string usuario, string contraseña, string cargo)
        {
            try
            {
                string consulta = "SELECT 1 FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseña AND Cargo = @cargo";
                OleDbCommand comando = new OleDbCommand(consulta, conexión);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
                comando.Parameters.AddWithValue("@cargo", cargo);

                conexión.Open();
                object resultado = comando.ExecuteScalar();
                return resultado != null;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (conexión.State == ConnectionState.Open)
                    conexión.Close();
            }
        }
    }
}
