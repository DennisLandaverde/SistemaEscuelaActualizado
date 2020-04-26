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
    public partial class InicioDocente : Form
    {
        public InicioDocente()
        {
            InitializeComponent();
        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void recordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistrarAlumnos registrar = new RegistrarAlumnos();
            registrar.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos alum = new Alumnos();
            alum.Show();
            this.Hide();
        }

        private void registrarNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarNota registrarn = new RegistrarNota();
            registrarn.Show();
            this.Hide();
        }

        private void InicioDocente_Load(object sender, EventArgs e)
        {

        }
    }
}
