using Logica;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class MenuSuscripciones : Form
    {
        public MenuSuscripciones()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        Suscripciones suscripciones = new Suscripciones();
        Principal principal = new Principal();
        private void Form7_Load(object sender, EventArgs e)
        {
            TextoFecha.Text = DateTime.Today.ToString("MMMM");
            cargarDatos();
        }

        private void lblExperimento_Click(object sender, EventArgs e)
        {
        }
        public void cargarDatos()
        {
            string sql = "select s.id, c.nombre as nombre_cliente, a.nombre as nombre_actividad, s.fechasuscripcion, s.finsuscripcion, a.monto, s.pagado from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id";
            gridSuscripciones.DataSource = ConexionASql.hacerConsulta(sql);
        }

        private void gridSuscripciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuPrincipal logeo;
            logeo = new MenuPrincipal();
            logeo.Show();
            this.Hide();
        }

        private void btDarAltaSecretario_Click(object sender, EventArgs e)
        {
            int posicion = gridSuscripciones.CurrentRow.Index;
            suscripciones.fechaSuscripcion = gridSuscripciones[3, posicion].Value.ToString();
            string fin = Convert.ToString(Convert.ToDateTime(suscripciones.fechaSuscripcion).AddMonths(1).ToString("dd/MM/yyyy"));
            gridSuscripciones[4, posicion].Value = fin;
            suscripciones.finSuscripcion = fin;
            suscripciones.pagado = Convert.ToBoolean(gridSuscripciones[6, posicion].Value.ToString());
            principal.modificacionSuscripciones(suscripciones, Convert.ToInt32(gridSuscripciones[0, posicion].Value));

        }

        private void btAltaSuscripcion_Click(object sender, EventArgs e)
        {
            AltaSuscripcion logeo;
            logeo = new AltaSuscripcion();
            logeo.Show();
            this.Hide();
        }

        private void MenuSuscripciones_MouseDown(object sender, MouseEventArgs e)
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



        private void paraBTFecha(int Fechasn)//Evitar fallo de busqueda debido a que no agrega un cero a la izquierda en los numeros de un digito para buscar la fecha
        {
            if (Fechasn >8)
            {
                Fechasn += 1;
                string sql = "select s.id, c.nombre as nombre_cliente, a.nombre as nombre_actividad, s.fechasuscripcion, s.finsuscripcion, a.monto, s.pagado from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id where s.fechasuscripcion like '%/" + Fechasn + "/%'";
                gridSuscripciones.DataSource = ConexionASql.hacerConsulta(sql);
            }
            else 
            {
                Fechasn += 1;
                string sql = "select s.id, c.nombre as nombre_cliente, a.nombre as nombre_actividad, s.fechasuscripcion, s.finsuscripcion, a.monto, s.pagado from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id where s.fechasuscripcion like '%/0" + Fechasn + "/%'";
                gridSuscripciones.DataSource = ConexionASql.hacerConsulta(sql);
            }
        }
     
        string[] paises = new string[] { "enero", "febrero", "marzo", "abril", "mayo","junio","julio","agosto","septiembre","octubre","noviembre","diciembre" };
   
        private void btnFechaAdelante_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<paises.Length+1; i++)
            {
                if (paises[i] == TextoFecha.Text)
                {
                    if (i >= 11)
                    {
                        int s2 = -1;
                        string p2 = paises[s2+1];
                        TextoFecha.Text = p2;
                        paraBTFecha(s2+1);
                        break;
                    }
                    string p= paises[i+1];
                    TextoFecha.Text = p;
                    paraBTFecha(i + 1);
                    break;
                }
            }
        }

        private void btnFechaAtras_Click(object sender, EventArgs e)
        {
            for (int i = 11; i >= 0; i--)
            {
                if (paises[i] == TextoFecha.Text)
                {
                    if (i == 0)
                    {
                        int s2 = 11;
                        string p2 = paises[s2];
                        TextoFecha.Text = p2;
                        paraBTFecha(s2);
                        break;
                    }
                    string p = paises[i-1];
                    TextoFecha.Text = p;
                    paraBTFecha(i-1);
                    break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void gridSuscripciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)//para el formato condicional en pagado
        {

            if (this.gridSuscripciones.Columns[e.ColumnIndex].Name == "pagado")
            {

                if (Convert.ToBoolean(e.Value) == false)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            {
                string parabuscarid = "select s.id, c.nombre as nombre_cliente, a.nombre as nombre_actividad, s.fechasuscripcion, s.finsuscripcion, a.monto, s.pagado from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id where s.id like '%" + txtBuscar.Text.ToString() + "%'"; ;
                string sql = "select s.id, c.nombre as nombre_cliente, a.nombre as nombre_actividad, s.fechasuscripcion, s.finsuscripcion, a.monto, s.pagado from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id";
                string parabuscaractividad = "select s.id, c.nombre as nombre_cliente, a.nombre as nombre_actividad, s.fechasuscripcion, s.finsuscripcion, a.monto, s.pagado from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id where a.nombre like '%" + txtBuscar.Text.ToString() + "%'";
                string parabuscarnombre = "select s.id, c.nombre as nombre_cliente, a.nombre as nombre_actividad, s.fechasuscripcion, s.finsuscripcion, a.monto, s.pagado from suscripciones s left join actividades a, clientes c on s.idactividad = a.id and s.idcliente = c.id where c.nombre like '%" + txtBuscar.Text.ToString() + "%'";
                if (true == ConexionASql.hacerConsultas(parabuscarid))
                {
                    gridSuscripciones.DataSource = ConexionASql.hacerConsulta(parabuscarid);
                    gridSuscripciones.Refresh();
                }else if (true == ConexionASql.hacerConsultas(parabuscaractividad))
                {
                    gridSuscripciones.DataSource = ConexionASql.hacerConsulta(parabuscaractividad);
                    gridSuscripciones.Refresh();
                }
                else if (true == ConexionASql.hacerConsultas(parabuscarnombre))
                {
                    gridSuscripciones.DataSource = ConexionASql.hacerConsulta(parabuscarnombre);
                    gridSuscripciones.Refresh();
                }
                else if (txtBuscar.Text.ToString() == null || txtBuscar.Text.ToString() == "" || txtBuscar.Text.ToString() == "Buscar")
                {
                    gridSuscripciones.DataSource = ConexionASql.hacerConsulta(sql);
                    gridSuscripciones.Refresh();
                }
                else
                {
                    MessageBox.Show("La suscripcion no esta registrada. ");
                }
                txtBuscar.Enabled = false;
                txtBuscar.Enabled = true;
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

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.DimGray;
            }
        }
    }
}