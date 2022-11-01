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
    public partial class MenuProfesores : Form
    {
        public MenuProfesores()
        {
            InitializeComponent();
        }
        Profesores profe = new Profesores();
        Principal principal = new Principal();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuPrincipal logeo;
            logeo = new MenuPrincipal();
            logeo.Show();
            this.Hide();
        }



        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDarAltaProfesores_Click(object sender, EventArgs e)
        {
            AltaProfesores logeo;
            logeo = new AltaProfesores();
            logeo.Show();
            this.Hide();
        }

        private void btnBajaProfesores_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que quieres eliminar este profesor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idProfesores = Convert.ToInt32(gridProfesores[0, gridProfesores.CurrentRow.Index].Value);
                gridProfesores.Rows.Remove(gridProfesores.CurrentRow);
                principal.bajaProfesor(idProfesores);
                MessageBox.Show("Profesor dado de baja correctamente.");
            }
            else
            {

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parabuscardni = "select * from profesores where dni like " + "'%" + txtBuscar.Text.ToString() + "%'";
            string parabuscarnombre = "select * from profesores where nombre like " + "'%" + txtBuscar.Text.ToString() + "%'";
            string parabuscarapellido = "select * from profesores where apellido like " + "'%" + txtBuscar.Text.ToString() + "%'";
            if (true == ConexionASql.hacerConsultas(parabuscardni))
            { 
                gridProfesores.DataSource = ConexionASql.hacerConsulta(parabuscardni);
                gridProfesores.Refresh();
            }else if (true == ConexionASql.hacerConsultas(parabuscarnombre))
            {
                gridProfesores.DataSource = ConexionASql.hacerConsulta(parabuscarnombre);
                gridProfesores.Refresh();
            }else if (true == ConexionASql.hacerConsultas(parabuscarapellido))
            {
                gridProfesores.DataSource = ConexionASql.hacerConsulta(parabuscarapellido);
                gridProfesores.Refresh();
            }
            else if (txtBuscar.Text.ToString() == null || txtBuscar.Text.ToString() == "" || txtBuscar.Text.ToString() == "Buscar")
            {
                var sql = "select * from profesores";
                gridProfesores.DataSource = ConexionASql.hacerConsulta(sql);
                gridProfesores.Refresh();
            }
            else
            {
                MessageBox.Show("El Profesor no esta registrado.");
            }
            txtBuscar.Enabled = false;
            txtBuscar.Enabled = true;
        }

        private void MenuProfesores_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        public void cargarDatos()
        {
            gridProfesores.DataSource = ConexionASql.hacerConsulta("select * from profesores");
        }

        private void gridProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificarProfesores_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que quieres modificar este profesor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int posicion = gridProfesores.CurrentRow.Index;

                profe.dni = gridProfesores[1, posicion].Value.ToString(); 
                profe.nombre = gridProfesores[2, posicion].Value.ToString();
                profe.apellido = gridProfesores[3, posicion].Value.ToString();
                profe.fechaNacimiento = gridProfesores[4, posicion].Value.ToString();
                profe.telefono = gridProfesores[5, posicion].Value.ToString();
                profe.email = gridProfesores[6, posicion].Value.ToString();
                profe.domicilio = gridProfesores[7, posicion].Value.ToString();
                profe.sueldo = profe.horasTrabajadas * profe.monto;
                profe.horasTrabajadas = Convert.ToInt32(gridProfesores[8, posicion].Value);
                profe.monto = Convert.ToInt32(gridProfesores[9, posicion].Value);
                profe.sueldo = Convert.ToInt32(gridProfesores[10, posicion].Value);


                principal.modificacionProfesores(profe, Convert.ToInt32(gridProfesores[0, posicion].Value));
                MessageBox.Show("Profesor modificado correctamente.");
            }
            else{ }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuProfesores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
