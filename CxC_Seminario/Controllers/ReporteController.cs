using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CxC_Seminario.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Factura_Usuario()
        {
            DataSetFactura_Usuario ds = new DataSetFactura_Usuario();

            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                SizeToReportContent = true,
                Width = Unit.Percentage(100),
                Height = Unit.Percentage(100),
                ZoomMode = ZoomMode.FullPage
            };

            var connectionString = ConfigurationManager.ConnectionStrings["ARE_SeminarioConnectionString"].ConnectionString;


            SqlConnection conx = new SqlConnection(connectionString); SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Factura_Usuario", conx);

            adp.Fill(ds, ds.Factura_Usuario.TableName);

            reportViewer.LocalReport.ReportPath = "E:/Analisis/Proyecto/SeminarioReports/Factura_Usuario.rdl";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetFactura_Usuario", ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;

            return View();
        }
    }
}