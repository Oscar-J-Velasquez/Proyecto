using Datos;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        public Form1(Alumno alumno)
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AlumnoLogica logica = new AlumnoLogica();
            dgvAlumnos.DataSource = logica.listaFiltrada();
            Text = "Aplicacion";
        }        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            AlumnoLogica logica = new AlumnoLogica();
            dgvAlumnos.DataSource = logica.listaFiltrada();            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminacionFisica_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();

            alumno = (Alumno)dgvAlumnos.CurrentRow.DataBoundItem;

            AlumnoLogica logica = new AlumnoLogica();
            logica.eliminarAlumno(alumno);
            dgvAlumnos.DataSource = logica.mostrarLista();
        }

        private void btnEliminacionLogica_Click(object sender, EventArgs e)
        {
            AlumnoLogica logica = new AlumnoLogica();
            Alumno alumno = new Alumno();
            alumno = (Alumno)dgvAlumnos.CurrentRow.DataBoundItem;
            

            logica.iniciarConsulta("update ALUMNO set Activo = 0 where Id = "+alumno.Id+"");
            logica.abrirConexion();
            logica.cerrarConexion();

            
            dgvAlumnos.DataSource = logica.listaFiltrada();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno = (Alumno)dgvAlumnos.CurrentRow.DataBoundItem;
            

            Form2 form2 = new Form2(alumno);
            form2.ShowDialog();
        }
    }
}
