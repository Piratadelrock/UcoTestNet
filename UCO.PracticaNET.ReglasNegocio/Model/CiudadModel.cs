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
        #region espacio para crear propiedades (atributos)
        [DisplayName("Codigo de la ciudad")]
        public int Id { get; set; }

        [DisplayName("Nombre de la ciudad")]
        public string Name { get; set; }
        
        #endregion


        #region espacio para metodos personalizados (metodos)
        public List<CiudadModel> ConsultarCiudad ()
        {
            List<CiudadModel> listadoCiudad = new List<CiudadModel>();

            //creo el objeto entidad
            UCOPracticasNETEntities entidadDatos = new UCOPracticasNETEntities();

            listadoCiudad = (from c in entidadDatos.ciudads
                             select c).Select(registroCiudad => new CiudadModel
                             {
                                 Id = registroCiudad.id,
                                 Name = registroCiudad.nombre

                             }).ToList();
            return listadoCiudad;

        }
    }



        #endregion



}
