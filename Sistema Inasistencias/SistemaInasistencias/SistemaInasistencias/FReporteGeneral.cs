using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace SistemaInasistencias
{
    public partial class FReporteGeneral : Form
    {
        Button btnCerrar;
        DataSet DSTransaccionesArticulos;
        public FReporteGeneral()
        {
            InitializeComponent();
            btnCerrar = new Button();
            btnCerrar.Click += new EventHandler(btnCerrar_Click);
            this.CancelButton = btnCerrar;
            DSTransaccionesArticulos = new DataSet();
        }
        void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cargarReporteInasistencias(DataTable DTListaInasistencias, DateTime FechaInicio, DateTime FechaFin)
        {
            DSTransaccionesArticulos.Tables.Clear();
            DTListaInasistencias.TableName = "ListarFaltasCentralizadas";            
            DSTransaccionesArticulos.Tables.AddRange(new DataTable[] { DTListaInasistencias });
            //CRListarFaltasCentralizadas _CRListarFaltasCentralizadas = new CRListarFaltasCentralizadas();


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Properties.Settings.Default.Properties["AcademicaTecnologiaConnectionString"].DefaultValue.ToString());


            ReportDocument myReportDocument;
            myReportDocument = new ReportDocument();
           // myReportDocument.Load(@"D:\Reports\rptitemintrans.rpt");
            myReportDocument.Load(System.Windows.Forms.Application.StartupPath + "\\CRListarFaltasCentralizadas.rpt");
            //myReportDocument.SetDataSource(DSTransaccionesArticulos);
            myReportDocument.SetDatabaseLogon(builder.UserID.ToString(), builder.Password.ToString(), builder.DataSource.ToString(), builder.InitialCatalog.ToString(), true);
            crystalReportViewer1.ReportSource = myReportDocument;
            crystalReportViewer1.DisplayToolbar = true;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------Fecha Inicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();


            crtParamDiscreteValue.Value = FechaInicio;
            crtParamField.ParameterFieldName = "FechaInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------Fecha Fin
            ParameterDiscreteValue crtParamDiscreteValue2 = new ParameterDiscreteValue();
            ParameterField crtParamField2 = new ParameterField();
            crtParamDiscreteValue2.Value = FechaFin;
            crtParamField2.ParameterFieldName = "FechaFin";
            crtParamField2.CurrentValues.Add(crtParamDiscreteValue2);
            crtParamFields.Add(crtParamField2);

            

            crystalReportViewer1.ParameterFieldInfo = crtParamFields;
            crystalReportViewer1.ShowGroupTreeButton = false;

            this.Text = "Reporte de Datos ";

            //CRSalidasArticulosGeneral _CRSalidasArticulosGeneral = new CRSalidasArticulosGeneral();
            //_CRSalidasArticulosGeneral.SetDataSource(DSTransaccionesArticulos);
            //CRVTransaccionesArticulos.ReportSource = _CRSalidasArticulosGeneral;
            
        }

       
    }
}
