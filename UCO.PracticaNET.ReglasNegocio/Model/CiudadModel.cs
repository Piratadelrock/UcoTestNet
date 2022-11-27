using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCO.PracticaNET.ReglasNegocio.Model
{
    public class CiudadModel
    {
        #region espacio para crear propiedades (atributos Getters - Setters)

        // las propiedades se pueden documentar para que cuando se vean en
        // las propiedades se pueda ver una descripcion de lo que hace la pripiedad(atributo - elemento)
   
        [DisplayName("Codigo de la ciudad")]
        public int Id { get; set; }

        [DisplayName("Nombre de la ciudad")]
        public string Name { get; set; }
        
        #endregion


        #region espacio para metodos personalizados (metodos)
        /// <summary>
        /// Permite consultar las ciudades
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CiudadModel> ConsultarCiudad ()
        {
            //listado ciudad es igual a
            List<CiudadModel> listadoCiudad = new List<CiudadModel>();

            //crea el objeto de entidad: instancio el objeto entidadDatos de la clase o entidad UCOPracticasNETEntities
            UCOPracticasNETEntities entidadDatos = new UCOPracticasNETEntities();

            //descargo el listado de los datos de ciudad que me devolveria una lista de ciudades

            listadoCiudad = (from c in entidadDatos.ciudads
                             select c).Select(registroCiudad => new CiudadModel
                             {
                                 Id = registroCiudad.id,
                                 Name = registroCiudad.nombre

                             }).ToList();

            return listadoCiudad;



        }


        public List<CiudadModel> ConsultarCiudadxSP()
        {
      

            //listado ciudad es igual a
            List<CiudadModel> listadoCiudad = new List<CiudadModel>();

            //crea el objeto de entidad: instancio el objeto entidadDatos de la clase o entidad UCOPracticasNETEntities
            UCOPracticasNETEntities entidadDatos = new UCOPracticasNETEntities();


            //configuramos la conexion y sp
            string sp = "spUCOPractica_ListarCiudades";
            //conexion viene del App.config
            //string conDB = entidadDatos.Database.Connection.ConnectionString;
            string conDB = entidadDatos.Database.Connection.ConnectionString;

            //Ejecutar el sp para retorne de los datos
            //DataTable dtCiudad = new DataTable();  
            DataTable dtCiudad = AccesoDirectoSQL.EjecutarSP(sp,conDB);

            //recorremos la tabla o data table 
            foreach (DataRow fCiudad in dtCiudad.Rows)
            {
                CiudadModel listCiudadxSP = new CiudadModel();
                // nuevaCiudad = listCiudadxSP 
                //listCiudadxSP.Id = fCiudad["id"].ToString();
                //llamamos los campos de la base de datos y los convertimos para mostrarlos en la tabla
                listCiudadxSP.Id = int.Parse(fCiudad["id"].ToString());
                listCiudadxSP.Name = fCiudad["nombre"].ToString();

                listadoCiudad.Add(listCiudadxSP);

            }


            return listadoCiudad;

        }


        //List<CiudadModel>
        public void CrearCiudadLinq()
        {
            //listado ciudad es igual a
            CiudadModel ingresarCiudad = new CiudadModel();

            //crea el objeto de entidad: instancio el objeto entidadDatos de la clase o entidad UCOPracticasNETEntities
            UCOPracticasNETEntities entidadDatos = new UCOPracticasNETEntities();

            //descargo el listado de los datos de ciudad que me devolveria una lista de ciudades

            //ingresarCiudad = entidadDatos.ciudads.Add<ciudad>(ingresarCiudad);
            
            entidadDatos.SaveChanges();

            //return ingresarCiudad;
        }

        public void CrearCiudadxQuery(string querySql)
        {
            //string sp = "INSERT INTO ciudad(nombre) VALUES ('nombre nuevo')";
            UCOPracticasNETEntities entidadDatos = new UCOPracticasNETEntities();
            string conDB = entidadDatos.Database.Connection.ConnectionString;

            SqlConnection conexionSql = new SqlConnection(conDB);
            SqlCommand cmd = new SqlCommand(querySql, conexionSql);

            //abrimos la conexion
            conexionSql.Open();

            cmd.ExecuteNonQuery();
            //llenar el datatable con la ejecucion del sp
            //CiudadModel modelC = new CiudadModel();
            conexionSql.Close();
        }
        #endregion

        #region Zona Crud

        //crear
        //actualizar
        //eliminar




        #endregion

    }

}
