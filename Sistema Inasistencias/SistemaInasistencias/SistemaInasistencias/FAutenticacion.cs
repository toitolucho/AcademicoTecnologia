using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using System.Configuration;

namespace SistemaInasistencias
{
    public partial class FAutenticacion : Form
    {
        
        
        public string Servidor = "";
        public string BaseDatos = "";
        public int  CodigoUsuario = 10;
        public string NombreUsuario = "";        
        public FAutenticacion()
        {
            InitializeComponent();
        }

        private void FAutenticacion_Load(object sender, EventArgs e)
        {
            string Servidor = System.Configuration.ConfigurationSettings.AppSettings["Servidor"];
            string BaseDatos = System.Configuration.ConfigurationSettings.AppSettings["BaseDatos"];
            string NombreUsuario = System.Configuration.ConfigurationSettings.AppSettings["NombreUsuario"];

            tBServidor.Text = Servidor;
            tBBaseDatos.Text = BaseDatos;
            tBNombreUsuario.Text = NombreUsuario;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        public void guardarDatosHistorial()
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["Servidor"].Value.ToString().CompareTo(Servidor) != 0)
                {
                    config.AppSettings.Settings["Servidor"].Value = Servidor;
                }

                if (config.AppSettings.Settings["NombreUsuario"].Value.ToString().CompareTo(NombreUsuario) != 0)
                {
                    config.AppSettings.Settings["NombreUsuario"].Value = NombreUsuario;
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {

            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            //if (ConfiguracionConeccion.Conectar(tBServidor.Text, "QBAlmacenes10_Lubricos", tBNombreUsuario.Text, tBContrasena.Text))
            if (ConfiguracionConeccion.Conectar(tBServidor.Text, "AcademicaTecnologia", "sa", "kc28ma10cw18"))
            //if (ConfiguracionConeccion.Conectar(tBServidor.Text, "QBAlmacenes10_Lubricos", "sa", "kc28ma10cw18"))
            {
                //CodigoUsuario = Usuarios.VerificarUsuario(tBNombreUsuario.Text, tBContrasena.Text);
                //colocar codigo de validación de la autenticidad del usuario

                if (CodigoUsuario <= 0)
                {
                    MessageBox.Show("Los datos proporcionados en la autenticacion a nivel del Sistema no son validos, verifique y vuelva a intentar.");
                }
                else
                {
                    Servidor = tBServidor.Text;
                    BaseDatos = tBBaseDatos.Text;
                    NombreUsuario = tBNombreUsuario.Text;

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    guardarDatosHistorial();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Los datos proporcionados en la autenticacion a nivel del Gestor de Base de Datos no son validos, verifique y vuelva a intentar.");
            }



            //CodigoUsuario = Usuarios.VerificarUsuario(tBNombreUsuario.Text, tBContrasena.Text);

            //if ( CodigoUsuario <= 0)
            //{
            //    MessageBox.Show("Los datos proporcionados en la autenticacion no son validos, verifique y vuelva a intentar.");
            //}
            //else
            //{
            //    Servidor = tBServidor.Text;
            //    BaseDatos = tBBaseDatos.Text;
            //    NombreUsuario = tBNombreUsuario.Text;

            //    this.Close();
            //}
               
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void FAutenticacion_Shown(object sender, EventArgs e)
        {
            tBNombreUsuario.Focus();
        }

        private void tBNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                FImputDialog formNombreServidor = new FImputDialog();
                formNombreServidor.DatoSalida = tBServidor.Text;
                if (formNombreServidor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tBServidor.Text = formNombreServidor.DatoSalida;
                }
                formNombreServidor.Dispose();
            }
        }

        
    }
}
