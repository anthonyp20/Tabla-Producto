using Financiera.Dominio;
using Financiera.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financiera.AppWin
{
    public partial class frmClienteEdit : Form
    {
        Cliente cliente;

        public frmClienteEdit(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void iniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
            if(cliente.ID > 0)
            {
                asignarControles();
            }
        }

        private void cargarDatos()
        {
            

        }

        private void grabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }

        private void asignarObjeto()
        {
            cliente.Nombres = txtNombre.Text;
            cliente.Marca = txtMarca.Text;
            cliente.Precio= txtPrecio.Text;
            cliente.Stock = txtStock.Text;
            
            cliente.Estado = chkEstado.Checked;
        }

        private void asignarControles()
        {
            txtNombre.Text = cliente.Nombres;
            txtMarca.Text = cliente.Marca;
            txtPrecio.Text = cliente.Precio;
            txtStock.Text = cliente.Stock;
            
            chkEstado.Checked = cliente.Estado;
        }
    }
}
