using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Pr1Pautasso
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        clsConexion conexion = new clsConexion();
        private void frmProductos_Load(object sender, EventArgs e)
        {
            conexion.CargarCombo(cboCategoria);
            conexion.MostrarListView(LvMostrar);

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            conexion.Insertar(txtNombre.Text,txtDescripcion.Text,Decimal.Parse(txtPrecio.Text),Convert.ToInt32(txtStock.Text),cboCategoria.Text);
            conexion.MostrarListView(LvMostrar);
        }

        private void LvMostrar_SelectedIndexChanged(object sender, EventArgs e) // listo 
        {
            if (LvMostrar.SelectedItems.Count > 0)
            {
                ListViewItem item = LvMostrar.SelectedItems[0];
                txtNombre.Text = item.SubItems[1].Text;
                txtDescripcion.Text = item.SubItems[2].Text;
                txtPrecio.Text = item.SubItems[3].Text;
                txtStock.Text = item.SubItems[4].Text;
                txtCodigo.Text = item.SubItems[0].Text;

                // Utiliza FindStringExact para encontrar el ítem en el ComboBox
                //sin FindStringExact me pasaba que en el metodo CargarCombo se seleccionaba una categoria
                // y chocaba con la categoria seleccionada en el evento
                // LvMostrar SelectedIndexChanged y no mostraba nada
                int indice = cboCategoria.FindStringExact(item.SubItems[5].Text);
                if (indice != -1)
                {
                    cboCategoria.SelectedIndex = indice;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               
                int codigo = int.Parse(txtCodigo.Text);
                conexion.Eliminar(codigo);
                // Limpia los controles después de eliminar
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
                cboCategoria.SelectedIndex = -1;
                txtCodigo.Clear();
                conexion.MostrarListView(LvMostrar);
            }
        }
    }
}
