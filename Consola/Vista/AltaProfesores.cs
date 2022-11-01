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
    public partial class AltaProfesores : Form
    {
        public AltaProfesores()
        {
            InitializeComponent();
        }



        Profesores paraAltaProfesores=new Profesores();
        Principal principal=new Principal();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btDarAltaSecretario_Click(object sender, EventArgs e)
        {
            bool fecha = DateTime.TryParse(txtFechaNacimiento.Text,out DateTime fecharecep);
            paraAltaProfesores.email = txtEmail.Text;
            paraAltaProfesores.dni = txtDNI.Text;
            paraAltaProfesores.apellido = txtApellido.Text;
            paraAltaProfesores.fechaNacimiento = txtFechaNacimiento.Text;
            paraAltaProfesores.nombre = txtNombre.Text;
            paraAltaProfesores.telefono = txtTelefono.Text;
            paraAltaProfesores.horasTrabajadas = int.Parse(txtHorasTrabajadas.Text);
            paraAltaProfesores.monto = int.Parse(txtMontoPorHora.Text);
            paraAltaProfesores.sueldo = paraAltaProfesores.monto * paraAltaProfesores.horasTrabajadas;
            paraAltaProfesores.domicilio = txtDomicili.Text;
            principal.altaProfesor(paraAltaProfesores);
            MessageBox.Show("Dado de alta satifactoriamente.");

            limpiar();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuProfesores logeo;
            logeo = new MenuProfesores();
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

        private void AltaProfesores_Load(object sender, EventArgs e)
        {

        }

        private void AltaProfesores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtFechaNacimiento_Leave(object sender, EventArgs e)
        {
            if (txtFechaNacimiento.Text == "")
            {
                txtFechaNacimiento.Text = "DD/MM/YYYY";
                txtFechaNacimiento.ForeColor = Color.DimGray;
            }
        }

        private void txtFechaNacimiento_Enter(object sender, EventArgs e)
        {
            if (txtFechaNacimiento.Text == "DD/MM/YYYY")
            {
                txtFechaNacimiento.Text = "";
                txtFechaNacimiento.ForeColor = Color.DimGray;
            }
        }
        public void limpiar()
        {
            txtApellido.ResetText();
            txtDNI.ResetText();
            txtEmail.ResetText();
            txtFechaNacimiento.Text = "DD/MM/YYYY";
            txtNombre.ResetText();
            txtTelefono.ResetText();
            txtDomicili.ResetText();
            txtHorasTrabajadas.ResetText();
            txtMontoPorHora.ResetText();
        }
    }
}
