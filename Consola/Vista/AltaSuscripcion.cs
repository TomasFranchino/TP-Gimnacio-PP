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
    public partial class AltaSuscripcion : Form
    {
        public AltaSuscripcion()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        Suscripciones suscripciones = new Suscripciones();
        Principal principal = new Principal();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar";
            }
            string parabuscar = "select c.id,c.dni from clientes c where dni like " + "'%" + txtBuscar.Text.ToString() + "%'";
            string parabuscarnombre = "select a.id,a.nombre from actividades a where nombre like " + "'%" + txtBuscar.Text.ToString() + "%'";
            if (true == ConexionASql.hacerConsultas(parabuscar))
            {
                GridParaAlta.DataSource = ConexionASql.hacerConsulta(parabuscar);
                GridParaAlta.Refresh();
            }
            else if (true == ConexionASql.hacerConsultas(parabuscarnombre))
            {
                GridParaAlta.DataSource = ConexionASql.hacerConsulta(parabuscarnombre);
                GridParaAlta.Refresh();
            }
            else if (txtBuscar.Text.ToString() == null || txtBuscar.Text.ToString() == "" || txtBuscar.Text.ToString() == "Buscar")
            {
                string sql = "select c.id as idCliente,c.dni,a.id as idActividad,a.nombre from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id";
                GridParaAlta.DataSource = ConexionASql.hacerConsulta(sql);
                GridParaAlta.Refresh();
            }
            else
            {
                MessageBox.Show("El cliente no esta registrado.");
            }

            txtBuscar.Enabled = false;
            txtBuscar.Enabled = true;
        }

        private void GridParaAlta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void AltaSuscripcion_Load(object sender, EventArgs e)
        {
            string sql= "select c.id as idCliente,c.dni,a.id as idActividad,a.nombre from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id";
            GridParaAlta.DataSource = ConexionASql.hacerConsulta(sql);  
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuSuscripciones logeo;
            logeo = new MenuSuscripciones();
            logeo.Show();
            this.Hide();
        }

        private void GridParaAlta_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btDarAltaClientes_Click(object sender, EventArgs e)
        {
            
            suscripciones.idCliente = Convert.ToInt32(txtIdCliente.Text);
            suscripciones.idActividad = Convert.ToInt32(txtIdActividad.Text);
            suscripciones.fechaSuscripcion = DateTime.Now.ToString("dd/MM/yyyy");
            suscripciones.finSuscripcion = (Convert.ToDateTime(suscripciones.fechaSuscripcion).AddMonths(1)).ToString("dd/MM/yyyy");
            suscripciones.pagado = chbxPagado.Checked;
            principal.altaSuscripciones(suscripciones);
            MessageBox.Show("Dado de alta satifactoriamente.");
            
            limpiar();
        }

        private void AltaSuscripcion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar";
                txtBuscar.ForeColor = Color.DimGray;
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.DimGray;
            }
        }

        private void txtFechaSuscripcion_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtFechaSuscripcion_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtFinSuscripcion_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtFinSuscripcion_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtFinSuscripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaSuscripcion_TextChanged(object sender, EventArgs e)
        {

        }
        public void limpiar()
        {
            
            txtIdActividad.ResetText();
            txtIdCliente.ResetText();
            chbxPagado.Checked = false ;
            

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
