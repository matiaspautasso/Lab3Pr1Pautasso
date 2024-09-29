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
    public partial class frmGestionAlmacen : Form
    {
        public frmGestionAlmacen()
        {
            InitializeComponent();
        }
        clsConexion conexoin=new clsConexion(); 
        private void Form1_Load(object sender, EventArgs e)
        {
             conexoin.VerificarConexion();
            
            
            
        }
       
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos frmProductos = new frmProductos();
            frmProductos.ShowDialog();
        }
    }
}
