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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
        }
        void CargarDatos()
        {
            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                var Jointablas = from Estudiante in db.Estudiante

                                 select new
                                 {

                                     Nombre  = Estudiante.NombreEstudiante,
                                     Usuario = Estudiante.NombreUsuarioE,
                                     Contraseña = Estudiante.ContraseñaE,
                                     NIE = Estudiante.NIE,
                                     Sexo = Estudiante.SexoEstudiante,
                                     Edad = Estudiante.Edad

                                 };

                dataGridView1.DataSource = Jointablas.ToList();

            }
        }
        void LimpiarDatos()
        {
            txtNombreEstudiante.Text = "";
            txtNombreUsuario.Text = "";
            txtSexo.Text = "";
            txtContraseña.Text = "";
            txtContraseña.Text = "";
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante alumnos = new Estudiante();
            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                String Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                int Idc = int.Parse(Id);
                alumnos = db.Estudiante.Where(VerificarId => VerificarId.IdEstudiante == Idc).First();
                alumnos.NombreEstudiante = txtNombreEstudiante.Text;
                alumnos.NombreUsuarioE = txtNombreUsuario.Text;
                alumnos.ContraseñaE = txtNombreUsuario.Text;
                alumnos.SexoEstudiante = txtSexo.Text;
                alumnos.Edad = int.Parse(txtEdad.Text);

                db.Entry(alumnos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CargarDatos();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            InicioDocente inicio = new InicioDocente();
            inicio.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Nombre = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Usuario = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Contra = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String Edad = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            String Sexo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtNombreEstudiante.Text = Nombre;
            txtNombreUsuario.Text = Usuario;
            txtSexo.Text = Sexo;
            txtContraseña.Text = Contra;
            txtEdad.Text = Edad;
        }
    }
}
