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
    public partial class Form2 : Form
    {
        Alumno alumnoSeleccionado = null;
        public Form2()
        {
            InitializeComponent();
            Text = "Agregar Alumno";
        }
        public Form2(Alumno alumno)
        {
            InitializeComponent();
            alumnoSeleccionado = alumno;
            Text = "Modificar Alumno";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            resultado = MessageBox.Show("¿Estas seguro de que queres cerrar el formulario?", "AVISO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Close();
            }        
                
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (alumnoSeleccionado == null)
            {
                string nombre = tbxNombre.Text;
                int nroDni = int.Parse(tbxDni.Text);
                string direccion = tbxDireccion.Text;
                int edad = int.Parse(tbxEdad.Text);


                Alumno alumno = new Alumno();
                alumno.Nombre = nombre;
                alumno.Dni = nroDni;
                alumno.Direccion = direccion;
                alumno.Edad = edad;

                AlumnoLogica logica = new AlumnoLogica();
                logica.cargarAlumno(alumno);
                Close();

            }
            else
            {
                tbxNombre.Text = alumnoSeleccionado.Nombre;
                tbxDni.Text = alumnoSeleccionado.Dni.ToString();
                tbxDireccion.Text = alumnoSeleccionado.Direccion;
                tbxEdad.Text = alumnoSeleccionado.Edad.ToString();
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (alumnoSeleccionado != null)
            {
            tbxNombre.Text = alumnoSeleccionado.Nombre;
            tbxDni.Text = alumnoSeleccionado.Dni.ToString();
            tbxDireccion.Text = alumnoSeleccionado.Direccion;
            tbxEdad.Text = alumnoSeleccionado.Edad.ToString();
            }
        }
    }
}
