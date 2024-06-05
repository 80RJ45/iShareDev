using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cDevelop.Controllers;
using cDevelop.Models;

namespace cDevelop.Forms
{
    public partial class frmAlumnosList : Form
    {
        DataTable tabAlumnos;
        private AlumnosController controller;
        private List<Alumno> alumnos;

        public frmAlumnosList()
        {
            InitializeComponent();
            controller = new AlumnosController();            
            tabAlumnos = new DataTable();

            tabAlumnos.Columns.Add("Nombre"); tabAlumnos.Columns.Add("Identidad");
            tabAlumnos.Columns.Add("FechaNac");
            tabAlumnos.Columns.Add("Sexo"); tabAlumnos.Columns.Add("Direccion");
            tabAlumnos.Columns.Add("Grado"); tabAlumnos.Columns.Add("cantMeses");
        }

        private async void getAlumnos()
        {
            alumnos = await
                controller.GetAllAlumnos();

            if (alumnos != null)
            {
                foreach (var alumno in alumnos)
                {
                    DataRow row = tabAlumnos.NewRow();

                    row["Nombre"] = alumno.firstName + " " + alumno.lastName;
                    row["Identidad"] = alumno.ssn;
                    row["Sexo"] = alumno.gender;
                    row["FechaNac"] = alumno.birthdate;
                    row["Direccion"] = alumno.address1 + " / " + alumno.address2;
                    row["Grado"] = alumno.gradeLevel;
                    row["cantMeses"] = alumno.plandePagos;

                    tabAlumnos.Rows.Add(row);
                }
            }
            else
                MessageBox.Show(this,"No se pudo obtener la petición", "Error", MessageBoxButtons.OK);
        }

        private void frmAlumnosList_Load(object sender, EventArgs e)
        {
            getAlumnos();
            dgvAlumnos.DataSource = tabAlumnos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAlumnos();
        }
    }
}
