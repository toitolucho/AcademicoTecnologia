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
    public partial class FCentralizador : Form
    {
        int CodigoUsuario;
        DSSistemaInasistenciasTableAdapters.ListarCarrerasTableAdapter TAListarCarreras;
        DSSistemaInasistencias.ListarCarrerasDataTable DTListarCarreras;
        ListarHorariosCargaHorariaInasistenciaTableAdapter TAListarHorariosCargaHorariaInasistencia;
        DSSistemaInasistencias.ListarHorariosCargaHorariaInasistenciaDataTable DTListarHorariosCargaHorariaInasistencia;
        DSSistemaInasistencias.ListarInasistenciasTiposDataTable DTInasistenciasTipos;
        DSSistemaInasistenciasTableAdapters.ListarInasistenciasTiposTableAdapter TAInasistenciasTipos;
        ListarFaltasCentralizadasTableAdapter TAListarFaltasCentralizadas;

        public FCentralizador()
        {
            InitializeComponent();
           


            FAutenticacion fautenticacion = new FAutenticacion();
            if (fautenticacion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                CodigoUsuario = fautenticacion.CodigoUsuario;

                //sSPrincipal.Items[0].Text += fautenticacion.Servidor;
                //sSPrincipal.Items[1].Text += fautenticacion.BaseDatos;
                //sSPrincipal.Items[2].Text += CodigoUsuario.ToString();
                //sSPrincipal.Items[3].Text += fautenticacion.NombreUsuario;

                //IDPC = "PC-EMAS01"; //Se obtendra del archivo de licencia de sistema Doblones.als

                TAListarFaltasCentralizadas = new ListarFaltasCentralizadasTableAdapter();
                TAInasistenciasTipos = new ListarInasistenciasTiposTableAdapter();
                DTInasistenciasTipos = TAInasistenciasTipos.GetData();

                TAListarCarreras = new ListarCarrerasTableAdapter();
                TAListarHorariosCargaHorariaInasistencia = new ListarHorariosCargaHorariaInasistenciaTableAdapter();
                DTListarCarreras = TAListarCarreras.GetData();
                cBoxCarreras.DisplayMember = "NombreCarrera";
                cBoxCarreras.ValueMember = "NumeroCarrera";
                cBoxCarreras.DataSource = DTListarCarreras;

                int year = DateTime.Now.Year;
                
                for(int inicio = 2016; inicio <= year; inicio++)
                {
                    cBoxGestiones.Items.Add("01/" + inicio);
                    cBoxGestiones.Items.Add("02/" + inicio);
                }


                cBoxCarreras.SelectedIndex = -1;
                cBoxGestiones.SelectedIndex = -1;
                cBoxTurnos.SelectedIndex = -1;
                dtGVListaCargaHoraria.AutoGenerateColumns = false;
                dtGVListaCargaHoraria.CurrentCellDirtyStateChanged += dtGVListaCargaHoraria_CurrentCellDirtyStateChanged;
                dtGVListaCargaHoraria.CellValueChanged += dtGVListaCargaHoraria_CellValueChanged;

                
                DGCIdInasistencia.DataSource = DTInasistenciasTipos;
                DGCIdInasistencia.DisplayMember = "NombreInasistencia";
                DGCIdInasistencia.ValueMember = "IdInasistencia";
                DGCIdInasistencia.DataPropertyName =  "IdInasistencia";

            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;

            }
        }

        void dtGVListaCargaHoraria_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DTListarHorariosCargaHorariaInasistencia != null && DTListarHorariosCargaHorariaInasistencia.Count != 0
                && dtGVListaCargaHoraria.CurrentCell != null && e.ColumnIndex == DGCAsistencia.Index)
            {
                if (e.ColumnIndex == DGCAsistencia.Index)
                {
                    //int PlanEstudiosAsignaturaCargaHorariaId = DTListarHorariosCargaHorariaInasistencia[e.RowIndex].PlanEstudiosAsignaturaCargaHorariaId;
                    if (dtGVListaCargaHoraria[e.ColumnIndex, e.RowIndex].Value.Equals(false))
                    {                        
                        FInasistenciasTiposSeleccion formTipos = new FInasistenciasTiposSeleccion();
                        if (formTipos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            DTListarHorariosCargaHorariaInasistencia[e.RowIndex].IdInasistencia = formTipos.IdInasistencia;
                        }
                        else
                        {
                            dtGVListaCargaHoraria[e.ColumnIndex, e.RowIndex].Value = true;
                        }
                    }
                    else
                    {
                        DTListarHorariosCargaHorariaInasistencia[e.RowIndex].SetIdInasistenciaNull();
                    }
                   
                    
                }
            }
        }

        void dtGVListaCargaHoraria_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVListaCargaHoraria.IsCurrentCellDirty && (dtGVListaCargaHoraria.CurrentCell.ColumnIndex == DGCAsistencia.Index
                || dtGVListaCargaHoraria.CurrentCell.ColumnIndex == DGCIdInasistencia.Index))
            {
                dtGVListaCargaHoraria.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnVerLista_Click(object sender, EventArgs e)
        {
            
            DTListarHorariosCargaHorariaInasistencia = TAListarHorariosCargaHorariaInasistencia.GetData(
                cBoxGestiones.SelectedItem.ToString(), 
                dtpFecha.Value, DTListarCarreras[cBoxCarreras.SelectedIndex].NombreCarrera , 
                cBoxTurnos.SelectedItem.ToString()[0].ToString());
            dtGVListaCargaHoraria.DataSource = DTListarHorariosCargaHorariaInasistencia;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataRow[] DRListasHorarios = DTListarHorariosCargaHorariaInasistencia.Select("Asistencia = False");
            if(DRListasHorarios.Count() > 0)
            {
                string ListaIdFaltas = "";
                foreach( DataRow fila  in DRListasHorarios )
                {
                    ListaIdFaltas += fila["PlanEstudiosAsignaturaCargaHorariaId"].ToString() + "-" + fila["IdInasistencia"].ToString() + ",";
                }

                ListaIdFaltas = ListaIdFaltas.Substring(0, ListaIdFaltas.Length - 1);
                MessageBox.Show(ListaIdFaltas);
                try
                {
                    TAListarHorariosCargaHorariaInasistencia.InsertarPlanesEstudiosAsignaturasCargasHorariasInasistencias(cBoxGestiones.SelectedItem.ToString(),
                                    dtpFecha.Value, DTListarCarreras[cBoxCarreras.SelectedIndex].NombreCarrera, cBoxTurnos.SelectedItem.ToString()[0].ToString(), ListaIdFaltas);
                    MessageBox.Show("Los los registros fueron almacenados correctamente", "Registro de Inasistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error, consulte con su administrador " + ex.Message, "Registro de Inasistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FSeleccionFechasReportes form = new FSeleccionFechasReportes();
            form.setVisibilidadFiltro(false);
            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FReporteGeneral formReporte = new FReporteGeneral();
                formReporte.cargarReporteInasistencias(TAListarFaltasCentralizadas.GetData(form.FechaInicio, form.FechaFin), form.FechaInicio, form.FechaFin);
                formReporte.ShowDialog();
            }
        }

    }
}
