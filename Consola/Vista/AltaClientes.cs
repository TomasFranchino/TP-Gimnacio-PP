using Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace Vista
{
    public partial class AltaClientes : Form
    {
        public AltaClientes()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        


        Clientes paraAltaClientes = new Clientes();
        Principal principal = new Principal();
        

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
            MenuClientes logeo;
            logeo = new MenuClientes();
            logeo.Show();
            this.Hide();
        }
        
        private void btDarAltaClientes_Click(object sender, EventArgs e)
        {
            bool fecha = DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fecharecep);
            
            paraAltaClientes.email = txtEmail.Text;
            paraAltaClientes.dni = txtDNI.Text;
            paraAltaClientes.apellido = txtApellido.Text;
            paraAltaClientes.fechaNacimiento =txtFechaNacimiento.Text.ToString();
            paraAltaClientes.nombre = txtNombre.Text;
            paraAltaClientes.telefono = txtTelefono.Text;
            paraAltaClientes.domicilio = txtDomicilio.Text;
            if (validarEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email con formato invalido. ");
            }
            else
            {
                if (fecha == true)
                {
                    principal.altaCliente(paraAltaClientes);
                    MessageBox.Show("Dado de alta satifactoriamente.");
                       
                }
                else { MessageBox.Show("Fecha nacimiento invalida. "); }
            }
            limpiar();
        }
       

        private void Form6_Load(object sender, EventArgs e)
        {
            txtDNI.Focus();
            tx();
        }
        public void tx()
        {
            txtDNI.Focus();

        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtFechaNacimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaNacimiento_Enter(object sender, EventArgs e)
        {
            if (txtFechaNacimiento.Text == "DD/MM/YYYY")
            {
                txtFechaNacimiento.Text = "";
                txtFechaNacimiento.ForeColor = Color.DimGray;
            }
        }

        private void txtFechaNacimiento_Leave(object sender, EventArgs e)
        {
            if (txtFechaNacimiento.Text == "")
            {
                txtFechaNacimiento.Text = "DD/MM/YYYY";
                txtFechaNacimiento.ForeColor = Color.DimGray;
            }
            bool fecha = DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fecharecep);
            if (fecha==false)
            {
                MessageBox.Show("Fecha invalida. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFechaNacimiento.Text = "DD/MM/YYYY";
            }
        }

        private void Form6_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar>=32  &&  e.KeyChar<=64) || (e.KeyChar>=91  &&  e.KeyChar<=96) || (e.KeyChar>=123  &&  e.KeyChar<=159)|| (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Caracter invalido, solo letras","Alerta",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Caracter invalido, solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Caracter invalido, solo letras y numeros. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }
        public static bool validarEmail(string comprobarEmail)
        {
            string emailFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if(Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public void limpiar()
        {
            txtApellido.ResetText();
            txtDNI.ResetText();
            txtDomicilio.ResetText();
            txtEmail.ResetText();
            txtFechaNacimiento.Text = "DD/MM/YYYY";
            txtNombre.ResetText();
            txtTelefono.ResetText();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
            
            if (e.KeyChar<=47 || e.KeyChar>=58)
            {
                MessageBox.Show("Caracter invalido, solo numeros. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
             
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar <= 47 || e.KeyChar >= 58)
            {
                MessageBox.Show("Caracter invalido, solo numeros. ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
          
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
