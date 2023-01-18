using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCO.PracticaNET.ReglasNegocio;
using UCO.PracticaNET.ReglasNegocio.Model;

namespace UCO.PracticaNET.AppWindows
{
    public partial class ListadoCiudad : Form
    {

        public ListadoCiudad()
        {
            InitializeComponent();

            ///proceso para mostrar y cargar los datos en el grid view 

            //creamos la instancia de CiudadModel de las reglas del negocio 
            //
            CiudadModel listadoCiudad = new CiudadModel();

            //necesito llevarselo al grid directamente por lo que debemos usar un bindingsource para aplicarlo
            ciudadModelBindingSource.DataSource = listadoCiudad.ConsultarCiudadxSP();

            //consultarLista();

            //ciudadModelBindingSource.DataSource = listadoCiudad.CrearCiudad();
            //se conecta el grid, con el datasource igual al binding de ciudad
            dataGridCiudad.DataSource = ciudadModelBindingSource;

        }


        private void dataGridCiudad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: como grabar sin que cualquier campo este vacio
            //en este caso es mi entidad

            if ((nombreTextBox.Text != String.Empty))
            {
                CiudadModel ciudadModel = new CiudadModel();
                //string query = "INSERT INTO ciudad(nombre)
                //VALUES ('" + nombreTextBox.Text + "')";

                string nombre = nombreTextBox.Text;
                

                //ciudadModel.CrearCiudadLinq(nombre);
                ciudadModel.CrearCiudadxQuery(nombre);

                MessageBox.Show("Se a Guardado el nombre de la ciudad : " + nombreTextBox.Text + " Exitosamente");

            }
            else
            {
                MessageBox.Show("No se puede guardar una ciudad sin nombre");
            }

            Clear();
            consultarLista();
            btnDelete.Enabled = false;


            //ciudadModel.CrearCiudad();

            //using (UCOPracticasNETEntities context = new UCOPracticasNETEntities())
            //{
            //    CiudadModel ingresarCiudad = new CiudadModel();

            //intento 3
            //var std = new CiudadModel()
            //{
            //   Name = "Gates"
            //};
            //context.ciudads.Add(std);

            //context.SaveChanges();



            //intento2
            //ingresarCiudad.Name = nombreTextBox.Text.Trim();
            //context.ciudads.Add(ciudades);
            //var ciudades = context.Set<ciudad>();
            //ciudades.add(new ciudad { nombre = nombretextbox.text.trim() });


            //intento1
            // context.ciudads.Add(new ciudad { nombre = nombreTextBox.Text.Trim() });
            //context.SaveChanges();

            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteLast();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;

            Clear();
        }



        /// <summary>
        /// Permite actualizar la lista del dataGridView 
        /// </summary>
        void consultarLista()
        {
            CiudadModel listadoCiudad = new CiudadModel();
            ciudadModelBindingSource.DataSource = listadoCiudad.ConsultarCiudadxSP();
        }

        /// <summary>
        /// permite limpiar los campos 
        /// </summary>
        void Clear()
        {
            nombreTextBox.Text = string.Empty;
            btnAñadir.Text = "Save";
            //listadoCiudad.Id = 0;
        }
    
        private void deleteLast()
        {

            using (UCOPracticasNETEntities context = new UCOPracticasNETEntities())
            {
                CiudadModel ciudadModel = new CiudadModel();


                //var std = context.ciudads.First<ciudad>;
                
                //context.ciudads.Remove(std);
                
                context.SaveChanges();
            }
            consultarLista();
        }

        private void deleteByName(){
            CiudadModel ciudad = new CiudadModel();


        }

  
    }

}
