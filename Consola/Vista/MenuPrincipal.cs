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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        

        private void btDarAltaSecretario_Click(object sender, EventArgs e)
        {
            //abrirFormChico(new Form4());
            MenuSecretarios logeo;
            logeo = new MenuSecretarios();
            logeo.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuProfesores logeo;
            logeo = new MenuProfesores();
            logeo.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login logeo;
            logeo = new Login();
            logeo.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //abrirFormChico(new Form5());
            MenuClientes logeo;
            logeo = new MenuClientes();
            logeo.Show();
            this.Hide();
        }

        private void btnSuscripciones_Click(object sender, EventArgs e)
        {
            //abrirFormChico(new Form7());
            MenuSuscripciones logeo;
            logeo = new MenuSuscripciones();
            logeo.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        Form formactivo = null;
        public void abrirFormChico(Form formhijo)
        {
            
            if (formactivo != null)
            {
                formactivo.Close();
                formactivo = formhijo;
                formhijo.TopLevel = false;
                formhijo.FormBorderStyle= FormBorderStyle.None;
                formhijo.Dock = DockStyle.Fill;
                panelMenuPrincipal.Controls.Add(formhijo);
                panelMenuPrincipal.Tag = formhijo;
                formhijo.BringToFront();
                formhijo.Show();
            }
            else
            {
                formactivo = formhijo;
                formhijo.TopLevel = false;
                formhijo.FormBorderStyle = FormBorderStyle.None;
                formhijo.Dock = DockStyle.Fill;
                panelMenuPrincipal.Controls.Add(formhijo);
                panelMenuPrincipal.Tag = formhijo;
                formhijo.BringToFront();
                formhijo.Show();
            }
        }

        private void panelMenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
