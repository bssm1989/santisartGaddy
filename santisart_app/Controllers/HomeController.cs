using System.IO;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Web;
using OfficeOpenXml;
using System.Linq;
using Spire.Xls.Converter;
using Spire.Pdf;
using Spire.Xls;

namespace santisart_app.Controllers
{
    public class HomeController : Controller
    {
        private const string V = @"ExcelTemp\Book5.xlsx";
         
        public ActionResult Index()
        {
            
            //string topLeft = "A1";
            //string bottomRight = "A4";
            //string graphTitle = "Graph Title";
            //string xAxis = "Time";
            //string yAxis = "Value";
            //var application = new Microsoft.Office.Interop.Excel.Application();
            //string pathExcel = Server.MapPath("ExcelTemp\\Book5.xlsx");// + V;
            //                                                           // string fileName = application.StartupPath + @"\ExcelTemp\Test.xlsm";//C:\Users\mumee\source\repos\santisart_app\santisart_app\ExcelTemp\Test.xlsx "\\ExcelTemp\\Test.xlsx";
            //var workbook = application.Workbooks.Open(pathExcel);
            //var worksheet = workbook.Worksheets[1] as
            //    Microsoft.Office.Interop.Excel.Worksheet;

            //// Add chart.
            //var charts = worksheet.ChartObjects() as
            //    Microsoft.Office.Interop.Excel.ChartObjects;
            //var chartObject = charts.Add(60, 10, 300, 300) as
            //    Microsoft.Office.Interop.Excel.ChartObject;
            //var chart = chartObject.Chart;

            //// Set chart range.
            //var range = worksheet.get_Range(topLeft, bottomRight);
            //chart.SetSourceData(range);

            //// Set chart properties.
            //chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;
            //chart.ChartWizard(Source: range,
            //    Title: graphTitle,
            //    CategoryTitle: xAxis,
            //    ValueTitle: yAxis);

            ////// Save.
            //workbook.Save();
            //workbook.Close();
            //FileInfo excel = new FileInfo(Server.MapPath(@"ExcelTemp\Test.xlsx"));
            //string excel2 = Server.MapPath(@"ExcelTemp\Test.xlsx");
            //using (var package = new ExcelPackage(excel))
            //{
            //    var workbook = package.Workbook;

            //    //*** Sheet 1
            //    var worksheet = workbook.Worksheets.First();

            //    Workbook excelFile = new Workbook();
            //    worksheet.Cells["Y6"].Value = "บัสซาม";
            //    worksheet.Cells["B2"].Value = System.DateTime.Now;
            //    package.Save();


            //    // Spire.XLS to open XLSX workbook stream created by EPPlus


            //    //    // Spire.PDF to convert XLSX to PDF, I read it has limited functionality (total pages, rows, etc...).
            //    //    //PdfConverter pdfConverter = new PdfConverter(excelFile);
            //    //    //PdfConverterSettings settings = new PdfConverterSettings();
            //    //    Worksheet sheet = excelFile.Worksheets[0];

            //    //    sheet.SaveToPdf(Server.MapPath("ExcelTemp\\excel2.pdf"));

            //    //    System.Diagnostics.Process.Start(Server.MapPath("ExcelTemp\\excel2.pdf"));
            //    //}
            //    using (var package = new ExcelPackage())
            //    {
            //        var workbook = package.Workbook;

            //        //*** Sheet 1
            //        var worksheet = workbook.Worksheets.Add("Sheet1");
            //        worksheet.Cells["A1"].Value = "ThaiCreate.Com";
            //        worksheet.Cells["B2"].Value = "2017";

            //        package.SaveAs(new FileInfo(Server.MapPath(@"ExcelTemp/myExcel.xlsx")));
            //    }
            //    //FileStream fs1 = new FileStream(Server.MapPath("ExcelTemp\\test.txt"), FileMode.OpenOrCreate, FileAccess.Write);
            //    //StreamWriter writer = new StreamWriter(fs1);
            //    //writer.Write(Server.MapPath("ExcelTemp\\test.txt"));
                //writer.Close();
                return View();
        }

        public ActionResult AnotherLink()
        {
           
            
            return View("Index");
        }
    }
}
