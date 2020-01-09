using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaInasistencias;
using SistemaInasistencias.DSSistemaInasistenciasTableAdapters;

namespace SistemaInasistencias
{
    public class ConfiguracionConeccion
    {

        //static DSSistemaInasistenciasTableAdapters.FuncionesSistemaTableAdapter Adapter;

        private static TAFuncionesSistemas _QTAFuncionesSistema = null;



        protected static TAFuncionesSistemas Adapter
        {
            get
            {
                if (_QTAFuncionesSistema == null)
                { 
                    _QTAFuncionesSistema = new TAFuncionesSistemas();
                    
                }
                return _QTAFuncionesSistema;
            }
        }
        

        public static bool Conectar(string servidor, string baseDatos)
        {
            //string cadenaConexion = CLCAD.Properties.Settings.Default.Properties["BibliotecaDigitalConnectionString"].DefaultValue.ToString();

            string cadena = "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";Integrated Security=True";
            Properties.Settings.Default.Properties["AcademicaTecnologiaConnectionString"].DefaultValue = cadena;
            Properties.Settings.Default.Reload();

            try
            {

                object auxObject = Adapter.ObtenerFechaHoraServidor().Value; 

                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }

        public static bool Conectar(string servidor, string baseDatos, string usuario, string contrasena)
        {
            string cadena = "Data Source=" + servidor + ";Initial Catalog=" + baseDatos + ";Persist Security Info=True; User ID=" + usuario + ";Password=" + contrasena;
            Properties.Settings.Default.Properties["AcademicaTecnologiaConnectionString"].DefaultValue = cadena;
           // Properties.Settings.Default.Save(System.Configuration.ConfigurationSaveMode.Modified, true);
            Properties.Settings.Default.Reload();
            
            try
            {
                
                object auxObject = Adapter.ObtenerFechaHoraServidor().Value;

                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }

    }
}
