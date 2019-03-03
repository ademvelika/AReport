using MYDIPLOMA.Helper;
using MYDIPLOMA.Preview;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace MYDIPLOMA.Dialog
{
    /// <summary>
    /// Interaction logic for DocumentPreview.xaml
    /// </summary>
    public partial class DocumentPreview : Window
    {

        public Canvas Document { get; set; }
        public DocumentPreview()
        {
            InitializeComponent();

            Document = new PreviewScreen();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Container.Content = Document;
        }

        private void reziseCanvas()
        {
           
            Scroller.Height = this.Height - 20;
            Scroller.Width = this.Width;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                dialog.PrintVisual(Document, "IFMS Print Screen");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Print Screen", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void PDFExport_Click(object sender, RoutedEventArgs e)
        {

            //// Create a new PDF document
            //PdfDocument document = new PdfDocument();

            //// Create an empty page
            //PdfPage page = document.AddPage();

            //// Get an XGraphics object for drawing
            //XGraphics gfx = XGraphics.FromPdfPage(page);

            //// Create a font



            //foreach (FrameworkElement item in Document.Children)
            //{
            //    var lbl = item as Label;
            //    if (lbl != null)
            //    {
            //        XFont font = new XFont("Times New Roman", 12, XFontStyle.Bold);
            //        gfx.DrawString(lbl.Content.ToString(), font, XBrushes.Black, Canvas.GetLeft(lbl)*0.75, Canvas.GetTop(lbl)*0.75);
            //    }

            //}
            //// Draw the text


            //// Save the document...
            //string filename = "HelloWorld.pdf";
            //document.Save(filename);
            //// ...and start a viewer.
            //Process.Start(filename);

            MemoryStream lMemoryStream = new MemoryStream();
            Package package = Package.Open(lMemoryStream, FileMode.Create);
            XpsDocument doc = new XpsDocument(package);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
            writer.Write(Document);
            doc.Close();
            package.Close();

            var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
            PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, "test.pdf", 0);
            Process.Start("test.pdf");
        }

        private void ExcelExport_Click(object sender, RoutedEventArgs e)
        {
            ExcelConverter exel = new ExcelConverter(Document);
            exel.ExportExcel();
        }
    }
}
