using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab3Pr1Pautasso
{
    internal class clsConexion
    {
        

       // esta es una variante  //SqlConnection conexionSqlConnection = new SqlConnection("Data Source=MATUTEPC;Initial Catalog=MATUTEBD;Integrated Security=True;Trust Server Certificate=True");
       
        string cadena;

        public clsConexion() 
        {
            cadena = "Data Source=MATUTEPC;Initial Catalog=MATUTEBD;Integrated Security=True;";
        }

        public bool VerificarConexion() //listo 
        {
            bool result = false;

            //conexion 
            SqlConnection conexion = new SqlConnection(cadena);

            try
            {
                conexion.Open();
                result = true;
                MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conexion != null)  
                {
                    conexion.Close();
                }
            }

            return result;
        }

        public void Insertar(string nombre, string descripcion, decimal precio, int stock, string categoria)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "INSERT INTO PRODUCTOS1 (Nombre, Descripcion, Precio, Stock, Categoria) VALUES (@Nombre, @Descripcion, @Precio, @Stock, @Categoria)";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Descripcion", descripcion);
                    comando.Parameters.AddWithValue("@Precio", precio);
                    comando.Parameters.AddWithValue("@Stock", stock);
                    comando.Parameters.AddWithValue("@Categoria", categoria);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro insertado con éxito");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de inserción: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }//listo
        public void MostrarListView(ListView lvwProductos)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "SELECT * FROM PRODUCTOS1";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    lvwProductos.Items.Clear();
                    foreach (DataRow fila in tabla.Rows)
                    {
                        ListViewItem item = new ListViewItem(fila["Codigo"].ToString());
                        item.SubItems.Add(fila["Nombre"].ToString());
                        item.SubItems.Add(fila["Descripcion"].ToString());
                        item.SubItems.Add(fila["Precio"].ToString());
                        item.SubItems.Add(fila["Stock"].ToString());
                        item.SubItems.Add(fila["Categoria"].ToString());
                        lvwProductos.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de consulta: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }//listo

        public void CargarCombo(ComboBox cmbCategoria) //LISTO 
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "SELECT DISTINCT Categoria FROM PRODUCTOS1";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    cmbCategoria.DataSource = tabla;
                    cmbCategoria.DisplayMember = "Categoria";
                    cmbCategoria.ValueMember = "Categoria";
                    cmbCategoria.SelectedIndex = -1;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de consulta: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        public void Eliminar(int codigo)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string query = "DELETE FROM PRODUCTOS1 WHERE Codigo = @Codigo";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro eliminado con éxito");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de eliminación: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }





    }
}
