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
    public partial class RegistrarNota : Form
    {
        public RegistrarNota()
        {
            InitializeComponent();
        }

        void CargarDatos()
        {
            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                var Jointablas = from Estudiante in db.Estudiante
                                 from Materia in db.Materia
                                 from Nota in db.Notas
                                 where Nota.IdEstudiante == Estudiante.IdEstudiante && Nota.IdMateria == Materia.IdMateria

                                 select new
                                 {

                                     IdEstudiante = Estudiante.IdEstudiante,
                                     IdMateria = Estudiante.NombreUsuarioE,
                                     Contraseña = Estudiante.ContraseñaE,
                                    

                                 };

                dataGridView1.DataSource = Jointablas.ToList();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Notas notas = new Notas();
            using (SistemaEscolarEntities db = new SistemaEscolarEntities())
            {
                String Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                int Idc = int.Parse(Id);
                notas = db.Notas.Where(VerificarId => VerificarId.IdNotas == Idc).First();
                notas.IdEstudiante = Convert.ToInt32(txtIdEstudiante.Text);
                notas.IdMateria = Convert.ToInt32(txtIdMateria.Text);
                notas.Nota = Convert.ToInt32(txtNota.Text);
                db.Entry(notas).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }
            
            CargarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String IdEstudiante = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String IdMateria = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Nota = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtIdEstudiante.Text = IdEstudiante;
            txtIdMateria.Text = IdMateria;
            txtNota.Text = Nota;
          
        }

        private void RegistrarNota_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
