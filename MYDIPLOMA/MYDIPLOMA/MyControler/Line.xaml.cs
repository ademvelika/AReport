using MYDIPLOMA.Interface;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace MYDIPLOMA.MyControler
{
    /// <summary>
    /// Interaction logic for Line.xaml
    /// </summary>
    public partial class Line : UserControl,ControlInterface
    {
        public Line()
        {
            InitializeComponent();

     ContextMenu = new RightClick(this);
        }

        public FrameworkElement getPreview()
        {

            var line = new Separator();
            line.Width = Width;
            line.Height = 7;
            Canvas.SetLeft(line, Canvas.GetLeft(this));
            Canvas.SetTop(line, Canvas.GetTop(this));
            return line;
        }

        public XElement GetXml()
        {
            return new XElement("VIJE");
        }

        public void RemoveMySelf()
        {
            ((MainWindow)App.Current.MainWindow).RemoveFromDocument(this);
        }

        public void setSelection()
        {
            this.BorderThickness = new Thickness(2);
            this.BorderBrush = Brushes.LightBlue;
        }

        public void setColour(Brush c)
        {
            throw new NotImplementedException();
        }

        public void setFont(int size)
        {
            throw new NotImplementedException();
        }

        public void setBorder()
        {
            throw new NotImplementedException();
        }
    }
}
