using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInasistencias
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(ShowAssemblies);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);


            //FSplashHilos.IniciarSplash(Application.StartupPath + @"\imagenes\splash.png", System.Drawing.Color.FromArgb(0, 0, 0));


            //forzarCargadoAssembliesCrystalReports();

            //FSplashHilos.CloseSplash();

            //AppDomain.CurrentDomain.AssemblyLoad -= ShowAssemblies;
            Application.Run(new FCentralizador());
        }

        /// <summary>
        /// Metodo que se encarga de caputar todos los Assemblies que se estan cargando
        /// al ejecutar la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ShowAssemblies(object sender, AssemblyLoadEventArgs e)
        {
            // Almacenamos los Assemblies dentro de la Cola que se encuentra dentro de Nuestro Formulario Splash

            FSplashHilos.ColaAssembliesCargados.Enqueue(e.LoadedAssembly.GetName().Name);
        }


        /// <summary>
        /// Metodo que se encarga de crear el Componente CrystalReportViewer para forzar
        /// el cargado de los assemblies de Crystal
        /// 
        /// </summary>
        public static void forzarCargadoAssembliesCrystalReports()
        {
            //CrystalDecisions.Windows.Forms.CrystalReportViewer CRVClientes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            //CRVClientes.Visible = false;
            //WFAQBAlmacenes10.ReportesAlmacenConfiguracion.CRListadoProveedores CRCliente = new WFAQBAlmacenes10.ReportesAlmacenConfiguracion.CRListadoProveedores();

            //CLCAD.DSQBAlmacenes10AlmacenConfiguracion.ProveedoresDataTable DTClientes = new CLCAD.DSQBAlmacenes10AlmacenConfiguracion.ProveedoresDataTable();
            //DTClientes.AddProveedoresRow("", "", "", "", 1, 1, "", 1, "", "", "", "", "", "", "", "", "", "", "", true, 1);
            //DTClientes.AcceptChanges();
            //CRCliente.SetDataSource((System.Data.DataTable)DTClientes);
            //CRVClientes.ReportSource = CRCliente;

        }
    }
}
