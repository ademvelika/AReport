using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MYDIPLOMA.Helper
{
   public  class ExcelConverter
    {

        private Canvas Document;
        private int LastHeaderRow;
       public ExcelConverter(Canvas c)
        {
            Document = c;
        }


        public void ExportExcel()
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  

            string filename = "Mydoc.xlsx";
           LastHeaderRow = 0; ;
            foreach (FrameworkElement item in Document.Children)
            {

                if(item is Label)
                {
                    int row = (int)Canvas.GetLeft(item) / 50;
                    int col = (int)Canvas.GetTop(item) / 50;
                    if (row == 0)
                    {
                        row = 1;
                    }
                    if (col == 0)
                    {
                        col = 1;
                    }
                    workSheet.Cells[col, row].Value = ((Label)item).Content.ToString();
                    LastHeaderRow = row;
                }
                else if(item is Grid)
                {
                    CreateTable(workSheet, item as Grid);
                }
               
             
               

               


            }

            try
            {
                FileStream objFileStrm = File.Create(filename);
                objFileStrm.Close();

                //Write content to excel file    
                File.WriteAllBytes(filename, excel.GetAsByteArray());

                Process.Start(filename);
            }
            catch(Exception e)
            {

                MessageBox.Show("Dicka shkoi gabim");
            }
        }

        public void CreateTable(ExcelWorksheet e, Grid panel)
        {


            //build headertable

            LastHeaderRow = LastHeaderRow + 2;
            e.Row(LastHeaderRow).Height = 30;
            
       
            e.Row(LastHeaderRow).Style.Font.Bold = true;
            e.Row(LastHeaderRow).Style.Font.Size = 20;
            int i = 1;
            foreach (StackPanel item in panel.Children)
            {
                var lb = item.Children[0] as Label;
                e.Cells[LastHeaderRow, i].Value =lb.Content.ToString();
                e.Cells[LastHeaderRow, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
               
                e.Cells[LastHeaderRow, i].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
                e.Cells[LastHeaderRow, i].Style.Font.Color.SetColor(System.Drawing.Color.White);
                i++;
            }


        
            int indexc = 0, indexrow = LastHeaderRow;
            foreach (StackPanel item in panel.Children)
            {
                indexc++;
                indexrow = LastHeaderRow;
                var valuesofColumns = item.Children[1] as StackPanel;

                foreach (Label el in valuesofColumns.Children)
                {
                    indexrow++;
                    e.Cells[indexrow, indexc].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    e.Cells[indexrow, indexc].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    e.Cells[indexrow, indexc].Value = el.Content.ToString();
                   
                }
                e.Column(indexc).AutoFit();

                if (item.Children.Count > 2)
                {
                    var agr = item.Children[2] as Label;

                    if (agr != null)
                    {
                        e.Cells[indexrow+1, indexc].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        e.Cells[(indexrow + 1), indexc].Value = agr.Content.ToString();
                        Color colFromHex2 = System.Drawing.ColorTranslator.FromHtml("#f44336");
                        e.Cells[indexrow + 1, indexc].Style.Fill.BackgroundColor.SetColor(colFromHex2);
                    }
                }
 

            }

            //e.Column(2).AutoFit();
            //e.Column(3).AutoFit();
            //e.Column(4).AutoFit();

        }
    }
}
