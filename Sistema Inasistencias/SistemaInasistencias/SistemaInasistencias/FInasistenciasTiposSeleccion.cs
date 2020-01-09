using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaInasistencias.DSSistemaInasistenciasTableAdapters;

namespace SistemaInasistencias
{
    public partial class FInasistenciasTiposSeleccion : Form
    {
        ListarInasistenciasTiposTableAdapter TAListarInasistenciasTipos;
        SistemaInasistencias.DSSistemaInasistencias.ListarInasistenciasTiposDataTable DTListarInasistenciasTipos;
        ErrorProvider errorProvider1;
        public byte IdInasistencia = 0;
        public FInasistenciasTiposSeleccion()
        {
            InitializeComponent();
            errorProvider1 = new ErrorProvider();
            TAListarInasistenciasTipos = new ListarInasistenciasTiposTableAdapter();
            DTListarInasistenciasTipos = TAListarInasistenciasTipos.GetData();
            cBoxInasistenciasTipos.DataSource = DTListarInasistenciasTipos;
            cBoxInasistenciasTipos.DisplayMember = "NombreInasistencia";
            cBoxInasistenciasTipos.ValueMember = "IdInasistencia";
            cBoxInasistenciasTipos.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(cBoxInasistenciasTipos.SelectedIndex < 0)
            {
                errorProvider1.SetError(cBoxInasistenciasTipos, "No ha seleccionado el tipo");
            }
            else
            {
                IdInasistencia = DTListarInasistenciasTipos[cBoxInasistenciasTipos.SelectedIndex].IdInasistencia;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
