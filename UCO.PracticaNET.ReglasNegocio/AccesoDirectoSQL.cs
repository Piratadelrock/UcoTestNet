using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCO.PracticaNET.ReglasNegocio
{
    internal class AccesoDirectoSQL
    {
        //CREO UN METODO EJECUTARSP

        public static DataTable EjecutarSP (string nombreSP, string conexionBaseDatos)
        {
            //realizamos una conexion sql mandando la base de datos 
            SqlConnection conexionSql = new SqlConnection(conexionBaseDatos);
            //en este mandamos  los comandos del sp
            SqlCommand cmdSp = new SqlCommand(nombreSP,conexionSql);
            //cargamos el resultado de la tabla 
            DataTable dtResultado = new DataTable();

            //abrimos la conexion
            conexionSql.Open();

            //llenar el datatable con la ejecucion del sp
            dtResultado.Load(cmdSp.ExecuteReader());

            return dtResultado;
        }

    }
}
