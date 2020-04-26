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
    public partial class RegistrarAlumnos : Form
    {
        public RegistrarAlumnos()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            InicioDocente docente = new InicioDocente();
            docente.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante();
            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                estudiante.NombreEstudiante = txtNombreEstudiante.Text;
                estudiante.NombreUsuarioE = txtNombreUsuario.Text;
                estudiante.SexoEstudiante = txtSexo.Text;
                estudiante.ContraseñaE = txtContraseña.Text;
                estudiante.Edad = int.Parse(txtEdad.Text);
                db.Estudiante.Add(estudiante);
                db.SaveChanges();
            }
        }

        private void RegistrarAlumnos_Load(object sender, EventArgs e)
        {

        }
    }
}
