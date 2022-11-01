using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class AltaSecretarios : Form
    {
        public AltaSecretarios()
        {
            InitializeComponent();
            
        }
        Secretarios paraAltaSecretarios = new Secretarios();
        Principal principal = new Principal();

        MenuSecretarios logeo;
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        



        private void Form2_Load(object sender, EventArgs e)
        {
            txtDNI.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private void txtFechaNacimiento_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void txtHorasTrabajadas_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtMontoPorHora_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TextoSueldo_Click(object sender, EventArgs e)
        {
            }

        private void btDarAltaSecretario_Click(object sender, EventArgs e)
        {
            bool fecha = DateTime.TryParse(txtFechaNacimiento.Text,out DateTime fecharecep);
            paraAltaSecretarios.email = txtEmail.Text;
            paraAltaSecretarios.dni = txtDNI.Text;
            paraAltaSecretarios.contraseña = txtContraseña.Text;
            paraAltaSecretarios.apellido = txtApellido.Text;
            paraAltaSecretarios.fechaNacimiento =txtFechaNacimiento.Text;
            paraAltaSecretarios.nombre = txtNombre.Text;
            paraAltaSecretarios.telefono = txtTelefono.Text;
            paraAltaSecretarios.horasTrabajadas = int.Parse(txtHorasTrabajadas.Text);
            paraAltaSecretarios.monto = int.Parse(txtMontoPorHora.Text);
            paraAltaSecretarios.sueldo = paraAltaSecretarios.monto * paraAltaSecretarios.horasTrabajadas;
            paraAltaSecretarios.domicilio = txtDomicili.Text;
            principal.altaSecretarios(paraAltaSecretarios);
            MessageBox.Show("Dado de alta satifactoriamente.");

            limpiar();
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TextoIDSecretario_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            logeo = new MenuSecretarios();
            logeo.Show();
            this.Hide();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextoDomicilio_Click(object sender, EventArgs e)
        {

        }

        private void TextoTelefono_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TextoApellido_Click(object sender, EventArgs e)
        {

        }

        private void TextoEmail_Click(object sender, EventArgs e)
        {

        }

        private void TextoDNI_Click(object sender, EventArgs e)
        {

        }

        private void TextoContraseña_Click(object sender, EventArgs e)
        {

        }

        private void TextoFechaNacimiento_Click(object sender, EventArgs e)
        {

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
            txtDomicili.ResetText();
            txtEmail.ResetText();
            txtFechaNacimiento.Text = "DD/MM/YYYY";
            txtNombre.ResetText();
            txtTelefono.ResetText();
            txtHorasTrabajadas.ResetText();
            txtMontoPorHora.ResetText();
            txtContraseña.ResetText();
        }
    }
    
}
