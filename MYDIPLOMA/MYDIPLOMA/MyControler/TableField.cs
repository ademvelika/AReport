using MYDIPLOMA.DataInterpretor;
using MYDIPLOMA.Helper;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace MYDIPLOMA.MyControler
{
    public class TableField : Field
    {
        public Helper.Expression.Expression Exp { get; set; }
        public TableField()
        {
            MoveImage.Visibility = Visibility.Collapsed;
            Conpanel.Background = Brushes.Transparent;

        }

        public override void setValue(Tuple<string, string> t)
        {
            DataBaseData = t;
            LblName.Content = t.Item2;
            Exp = null;

        }
        public override XElement GetXml()
        {
            XElement node = null;
            if (Exp != null)
            {
                node = new XElement(Exp.getXml());
            }
            else
            {
              node=   new XElement("DB", new XAttribute("TN", DataBaseData.Item1), new XAttribute("CN", DataBaseData.Item2));
            }
            return node;
        }

        public void SetExpression(Helper.Expression.Expression E)
        {
            Exp = E;
            LblName.Content = E.getFunctionAsString();
        }

        public override FrameworkElement getPreview()
        {
            StackPanel s = new StackPanel();

            List<string> l = null;

            if (Exp == null)
                l = (List<string>)SchemaCreator.CurrentChoise.getFieldColumn(DataBaseData);
            else
                l = Exp.getCollectionData();
            foreach (var item in l)
            {
                Label lb = new Label { Content = item, BorderBrush = Brushes.LightGray, BorderThickness = new Thickness(1) };
                s.Children.Add(lb);

            }
            return s;
        }
    }
}
