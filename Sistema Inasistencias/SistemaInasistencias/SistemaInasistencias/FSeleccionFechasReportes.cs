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
    public partial class FSeleccionFechasReportes : Form
    {
        DateTime _fechaInicio, _fechaFin;
        public object SelectedValueFiltro
        {
            get {return cBoxFiltro.SelectedValue; }
        }
        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }
        public FSeleccionFechasReportes()
        {
            InitializeComponent();
        }
        public void setVisibilidadFiltro(bool estadoVisible)
        {
            lblFiltro.Visible = gBoxFiltro.Visible = cBoxFiltro.Visible = estadoVisible;
        }
        public Label LabelFiltro
        {
            get { return this.lblFiltro; }
        }
        public void cargarDatosFiltro(DataTable DTFiltro, string DisplayMember, string ValueMember)
        {
            cBoxFiltro.DataSource = DTFiltro;
            cBoxFiltro.DisplayMember = DisplayMember;
            cBoxFiltro.ValueMember = ValueMember;
            cBoxFiltro.SelectedIndex = -1;     
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _fechaInicio = dateFechaInicio.Value;
            _fechaFin = dateFechaFin.Value;
            Button btnAccion = sender as Button;            
            this.DialogResult = btnAccion.Equals(btnAceptar) ? DialogResult.OK : DialogResult.Cancel;
        }
    }

}
