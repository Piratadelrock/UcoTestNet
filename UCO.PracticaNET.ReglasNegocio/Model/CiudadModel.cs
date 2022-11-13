using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        #endregion

        #region Zona Crud

        //crear
        //actualizar
        //eliminar




        #endregion

    }

}
