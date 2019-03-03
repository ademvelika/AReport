using MYDIPLOMA.Dialog;
using MYDIPLOMA.Helper;
using MYDIPLOMA.Interface;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace MYDIPLOMA.MyControler
{
    /// <summary>
    /// Interaction logic for Kolone.xaml
    /// </summary>
    public partial class Kolone : UserControl,ControlInterface
    {

        public bool HasTotal { get; set; }
        public Kolone()
        {
            InitializeComponent();
            FieldColumn.ContextMenu = null;
            ContextMenu = new RightClick(this);
            MenuItem m = new MenuItem { Header = "Add Function" };
            m.Click += (s, e) =>
            {
                FunctionWindowd diag = new FunctionWindowd(FieldColumn);
                diag.ShowDialog();
            };
            MenuItem addcoltotal = new MenuItem { Header = "Add total column" };

            addcoltotal.Click += (s, e) =>
            {
                HasTotal = true;

            };

            this.ContextMenu.Items.Add(m);
            this.ContextMenu.Items.Add(addcoltotal);
        }

        public XElement GetXml()
        {
        var col = new XElement(XMLCREATOR.TABLE_COLUMN,new XAttribute("TOT",HasTotal.ToString()), new XAttribute(XMLCREATOR.COLUMN_HEADER, ColHeader.Text),FieldColumn.GetXml());

            return col;

           
        }

        public void RemoveMySelf()
        {
            

            var pos = Grid.GetColumn(this);
            ((Grid)Parent).ColumnDefinitions.RemoveAt(pos);
            ((Grid)Parent).Children.Remove(this);

        }

        public void setSelection()
        {
            throw new NotImplementedException();
        }

        public void setColour(Brush c)
        {
            throw new NotImplementedException();
        }

        public void setFont(int size)
        {
            throw new NotImplementedException();
        }

        FrameworkElement ControlInterface.getPreview()
        {

          
            StackPanel s = new StackPanel();

            Label l = new Label { Content = ColHeader.Text, Background = ColHeader.Background,BorderBrush=Brushes.Gray, BorderThickness = new Thickness(1), FontSize = ColHeader.FontSize ,Foreground=Brushes.White};
            s.Children.Add(l);
           StackPanel  column = (StackPanel)FieldColumn.getPreview();
            s.Children.Add(column);
            if (HasTotal)
            {
                double sum = 0;
                int i = 0;
                foreach (Label lbl in column.Children)
                {
                    sum += Double.Parse(lbl.Content.ToString());
                }
                Label ltotal = new Label { Content = sum.ToString() };
                ltotal.Background = Brushes.LightGray;
                ltotal.BorderThickness = new Thickness(1);
                s.Children.Add(ltotal);
            }

          

            return s;
        }

        public void setBorder()
        {
            throw new NotImplementedException();
        }
    }
}
