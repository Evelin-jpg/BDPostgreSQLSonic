using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDServerSonic
{
    public partial class Marcador : Form
    {
        string consulta;
        public Marcador()
        {
            InitializeComponent();
        }

        private void Marcador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgreSQL.EjecutaConsultaSelect("SELECT * FROM Marcador ORDER BY idMarcador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Clasificacion = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;

            consulta = "INSERT INTO Marcador(Nombre, Clasificacion, Descripcion, idJugador) VALUES ('" + Nombre + "', + '" + Clasificacion + "', '" + Descripcion + "', '" + idJugador + "')";
            ConexionPostgreSQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Clasificacion = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idJugador = textBox4.Text;
            int idMarcador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Marcador SET Nombre = '" + Nombre + "',Clasificacion = '" + Clasificacion + "',Descripcion = '" + Descripcion + "',idJugador = '" + idJugador + "'  WHERE idMarcador = " + idMarcador.ToString();
            ConexionPostgreSQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMarcador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Marcador SET  estatus = False WHERE idMarcador =  " + idMarcador.ToString(); ;
            ConexionPostgreSQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Menu app = new Menu();
            app.Show();
            this.Hide();
        }
    }
}
