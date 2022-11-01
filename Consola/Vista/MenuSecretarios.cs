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
using System.Data.SQLite;

namespace Vista
{
    public partial class MenuSecretarios : Form
    {
        public MenuSecretarios()
        {
            InitializeComponent();
        }
        
        Secretarios secre = new Secretarios();
        Principal principal = new Principal();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Titulo_Click(object sender, EventArgs e)
        {

        }

        private void btDarAltaSecretario_Click(object sender, EventArgs e)
        {

            //abrirFormChico(new Form6());
            AltaSecretarios logeo;
            logeo = new AltaSecretarios();
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

        private void Form4_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public void cargarDatos()
        {
            gridSecretarios.DataSource = ConexionASql.hacerConsulta("select * from secretarios");
        }

        private void gridSecretarios_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int posicion = gridSecretarios.CurrentRow.Index;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que quieres eliminar este secretario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idSecretarios = Convert.ToInt32(gridSecretarios[0, gridSecretarios.CurrentRow.Index].Value);
                gridSecretarios.Rows.Remove(gridSecretarios.CurrentRow);
                principal.bajaSecretario(idSecretarios);
                MessageBox.Show("Secretario dado de baja correctamente.");
            }
            else { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que quieres modificar este secretario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int posicion = gridSecretarios.CurrentRow.Index;

                secre.dni = gridSecretarios[1, posicion].Value.ToString();
                secre.contraseña = gridSecretarios[2, posicion].Value.ToString();
                secre.nombre = gridSecretarios[3, posicion].Value.ToString();
                secre.apellido = gridSecretarios[4, posicion].Value.ToString();
                secre.fechaNacimiento = gridSecretarios[5, posicion].Value.ToString();
                secre.telefono = gridSecretarios[6, posicion].Value.ToString();
                secre.email = gridSecretarios[7, posicion].Value.ToString();
                secre.domicilio = gridSecretarios[8, posicion].Value.ToString();
                secre.horasTrabajadas = Convert.ToInt32(gridSecretarios[9, posicion].Value);
                secre.monto = Convert.ToInt32(gridSecretarios[10, posicion].Value);
                secre.sueldo = secre.horasTrabajadas * secre.monto;
                principal.modificacionSecretarios(secre, Convert.ToInt32(gridSecretarios[0, posicion].Value));
                MessageBox.Show("Secretario modificado correctamente.");
            }
            else { }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuPrincipal logeo;
            logeo = new MenuPrincipal();
            logeo.Show();
            this.Hide();
        }

        private void txtBuscar(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string parabuscar = "select * from secretarios where dni like " + "'%" + txtContraseña.Text.ToString() + "%'";
            string parabuscarnombre = "select * from secretarios where nombre like " + "'%" + txtContraseña.Text.ToString() + "%'";
            string parabuscarapellido = "select * from secretarios where apellido like " + "'%" + txtContraseña.Text.ToString() + "%'";
            if (true == ConexionASql.hacerConsultas(parabuscar))
            {
                gridSecretarios.DataSource = ConexionASql.hacerConsulta(parabuscar);
                gridSecretarios.Refresh();
            }
            else if (true == ConexionASql.hacerConsultas(parabuscarnombre))
            {
                gridSecretarios.DataSource = ConexionASql.hacerConsulta(parabuscarnombre);
                gridSecretarios.Refresh();
            }
            else if (true == ConexionASql.hacerConsultas(parabuscarapellido))
            {
                gridSecretarios.DataSource = ConexionASql.hacerConsulta(parabuscarapellido);
                gridSecretarios.Refresh();
            }
            else if (txtContraseña.Text.ToString() == null || txtContraseña.Text.ToString() == "" || txtContraseña.Text.ToString() == "Buscar")
            {
                var sql = "select * from secretarios";
                gridSecretarios.DataSource = ConexionASql.hacerConsulta(sql);
                gridSecretarios.Refresh();
            }
            else
            {
                MessageBox.Show("El secretario no esta registrado.");
            }
            txtContraseña.Enabled = false;
            txtContraseña.Enabled = true;
        }

        private void txtContraseña_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Buscar";
                txtContraseña.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter_1(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Buscar")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.DimGray;
            }
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {

        }

        private void gridSecretarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int posicion = gridSecretarios.CurrentRow.Index;
        }

        private void Form4_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Form formactivo = null;
        //public void abrirFormChico(Form formhijo)
        //{

        //    if (formactivo != null)
        //    {
        //        formactivo.Close();
        //        formactivo = formhijo;
        //        formhijo.TopLevel = false;
        //        formhijo.FormBorderStyle = FormBorderStyle.None;
        //        formhijo.Dock = DockStyle.Fill;
        //        panelSecretarios.Controls.Add(formhijo);
        //        panelSecretarios.Tag = formhijo;
        //        formhijo.BringToFront();
        //        formhijo.Show();
        //    }
        //    else
        //    {
        //        formactivo = formhijo;
        //        formhijo.TopLevel = false;
        //        formhijo.FormBorderStyle = FormBorderStyle.None;
        //        formhijo.Dock = DockStyle.Fill;
        //        panelSecretarios.Controls.Add(formhijo);
        //        panelSecretarios.Tag = formhijo;
        //        formhijo.BringToFront();
        //        formhijo.Show();
        //    }
        //}

    }
}
