using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class MenuClientes : Form
    {
        public MenuClientes()
        {
            InitializeComponent();
        }

        Principal principal = new Principal();
        Clientes clientes = new Clientes();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuPrincipal logeo;
            logeo = new MenuPrincipal();
            logeo.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        public void cargarDatos()
        {
            gridClientes.DataSource = ConexionASql.hacerConsulta("select * from clientes");
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btDarAltaCliente_Click(object sender, EventArgs e)
        {
            AltaClientes logeo;
            logeo = new AltaClientes();
            logeo.Show();
            this.Hide();
        }

        private void btnModificarClientes_Click(object sender, EventArgs e)
        {
            int posicion = gridClientes.CurrentRow.Index;

            if (MessageBox.Show("Estas seguro que quieres modificar el cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clientes.dni = gridClientes[1, posicion].Value.ToString();
                clientes.nombre = gridClientes[2, posicion].Value.ToString();
                clientes.apellido = gridClientes[3, posicion].Value.ToString();
                clientes.fechaNacimiento =  gridClientes[4, posicion].Value.ToString();
                clientes.telefono = gridClientes[5, posicion].Value.ToString();
                clientes.email = gridClientes[6, posicion].Value.ToString();
                clientes.domicilio = gridClientes[7, posicion].Value.ToString();

                principal.modificacionCliente(clientes, Convert.ToInt32(gridClientes[0, posicion].Value));
                MessageBox.Show("Cliente modificado correctamente.");
            }
            else
            {
                
            }
            
        }

        private void btnBajaClientes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que quieres eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idClinetes = Convert.ToInt32(gridClientes[0, gridClientes.CurrentRow.Index].Value);
                gridClientes.Rows.Remove(gridClientes.CurrentRow);
                principal.bajaCliente(idClinetes);
                MessageBox.Show("Cliente dado de baja correctamente.");
            }
            else
            {
                
            }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parabuscardni = "select * from clientes where dni like " + "'%" + txtBuscar.Text.ToString() + "%'";
            string parabuscarnombre = "select * from clientes where nombre like " + "'%" + txtBuscar.Text.ToString() + "%'";
            string parabuscarapellido = "select * from clientes where apellido like " + "'%" + txtBuscar.Text.ToString() + "%'";
            if (true == ConexionASql.hacerConsultas(parabuscardni))
            {
                gridClientes.DataSource = ConexionASql.hacerConsulta(parabuscardni);
                gridClientes.Refresh();
            }else if (true == ConexionASql.hacerConsultas(parabuscarnombre))
            {
                gridClientes.DataSource = ConexionASql.hacerConsulta(parabuscarnombre);
                gridClientes.Refresh();
            }else if(true == ConexionASql.hacerConsultas(parabuscarapellido))
            {
                gridClientes.DataSource = ConexionASql.hacerConsulta(parabuscarapellido);
                gridClientes.Refresh();
            }
            else if (txtBuscar.Text.ToString() == null || txtBuscar.Text.ToString() == "" || txtBuscar.Text.ToString() == "Buscar")
            {
                var sql = "select * from clientes";
                gridClientes.DataSource = ConexionASql.hacerConsulta(sql);
                gridClientes.Refresh();
            }
            else
            {
                MessageBox.Show("El secretario no esta registrado.");
            }
            txtBuscar.Enabled = false;
            txtBuscar.Enabled = true;
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.DimGray;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar";
                txtBuscar.ForeColor = Color.DimGray;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
