using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCO.PracticaNET.ReglasNegocio.Model;

namespace UCO.PracticaNET.AppWindows
{
    public partial class ListadoCiudad : Form
    {
        public ListadoCiudad()
        {
            InitializeComponent();

            ///proceso para mostrar y cargar los datos en el  grid view 
            
            //creamos la instancia de CiudadModel de las reglas del negocio 
            //
            CiudadModel listadoCiudad = new CiudadModel();
            
            //necesito llevarselo al grid directamente por lo que debemos usar un bindingsource para aplicarlo
            ciudadModelBindingSource.DataSource = listadoCiudad.ConsultarCiudadxSP();

            ///TODO: crear crud 
            ///ciudadModelBindingSource.DataSource = listadoCiudad.CrearCiudad();
            //se conecta el grid, con el datasource igual al binding de ciudad
            dataGridCiudad.DataSource = ciudadModelBindingSource;

        }

        private void dataGridCiudad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
