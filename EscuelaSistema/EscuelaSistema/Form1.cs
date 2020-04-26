using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaSistema
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                var usuario = from Doc in db.Docente
                            where Doc.NombreUsuarioD == txtNombreUsuario.Text
                            && Doc.ContraseñaD == txtNombreContraseña.Text
                            select Doc;

                if (usuario.Count() > 0)
                {
                    MessageBox.Show("Haz iniciado sesion");
                    InicioDocente adminis = new InicioDocente();
                    adminis.Show();
                    this.Hide();
                }
                

            }

            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                var est = from Estudiante in db.Estudiante
                          where Estudiante.NombreUsuarioE == txtNombreUsuario.Text
                          && Estudiante.ContraseñaE == txtNombreContraseña.Text
                          select Estudiante;

                if (est.Count() > 0)
                {
                    MessageBox.Show("Haz iniciado sesion" );
                    InicioEstudiante usua = new InicioEstudiante();

                    usua.Show();
                    this.Hide();
                }
                


            }
            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                var dir = from Director in db.Director
                          where Director.NombreUsuarioDi == txtNombreUsuario.Text
                          && Director.ContraseñaDi == txtNombreContraseña.Text
                          select Director;

                if (dir.Count() > 0)
                {
                    MessageBox.Show("Haz iniciado sesion");
                    InicioDirector usua = new InicioDirector();

                    usua.Show();
                    this.Hide();
                }
               
            }
           

        }
    }
}
