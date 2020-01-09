using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaInasistencias
{
    public partial class FImputDialog : Form
    {

        public string DatoSalida
        {
            get
            {
                return txtDatoEntrada.Text;
            }
            set
            {
                txtDatoEntrada.Text = value;
            }
        }

        public Label LabelMensaje
        {
            get { return lblMensaje; }
            
        }

        ErrorProvider eProvider;

        public FImputDialog()
        {
            InitializeComponent();
            eProvider = new ErrorProvider();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.txtDatoEntrada.KeyDown += new KeyEventHandler(txtDatoEntrada_KeyDown);
            this.Shown += new EventHandler(FImputDialog_Shown);
        }

        void FImputDialog_Shown(object sender, EventArgs e)
        {
            this.txtDatoEntrada.Text = DatoSalida;
            this.txtDatoEntrada.Focus();
            this.txtDatoEntrada.SelectAll();
        }

        void txtDatoEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e as EventArgs);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            eProvider.Clear();
            if (String.IsNullOrEmpty(txtDatoEntrada.Text))
            {
                eProvider.SetError(txtDatoEntrada, "Aún no ha ingresado ningun dato");
                txtDatoEntrada.Focus();
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
