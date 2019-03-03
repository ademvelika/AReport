using MYDIPLOMA.Helper;
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
    /// Interaction logic for Text.xaml
    /// </summary>
    public partial class Text : UserControl,ControlInterface
    {
        public Text()
        {
            InitializeComponent();

            ContextMenu = new RightClick(this);
        }

        public XElement GetXml()
        {
            var node = new XElement(XMLCREATOR.TEKST, new XAttribute("VALUE",Txt.Text),new XAttribute(XMLCREATOR.TOP,Canvas.GetTop(this)),new XAttribute(XMLCREATOR.WIDTH,this.Width),new XAttribute(XMLCREATOR.HEIGHT,this.Height) ,new XAttribute(XMLCREATOR.LEFT, Canvas.GetLeft(this)));

            return node;
         
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
            Txt.Foreground = c;
        }

        public void setFont(int size)
        {
            Txt.FontSize = size;
            this.Height =20* Math.Log10(Math.Pow(size,3));
        }

        FrameworkElement ControlInterface.getPreview()
        {


            double x = Canvas.GetLeft(this);
            double y = Canvas.GetTop(this);
            var t = new Label { Content = Txt.Text };
            t.FontSize = Txt.FontSize;
            t.Foreground = Txt.Foreground;
            t.Height = Double.NaN;
 
            t.BorderBrush = Txt.BorderBrush;
            Canvas.SetLeft(t, x+20);
            Canvas.SetTop(t, y+20);

            return t;
         
        }

     

      

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Txt.IsEnabled = true;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Txt.IsEnabled = false;
        }

        public void setBorder()
        {
            Txt.BorderBrush = Brushes.Black;
            Txt.BorderThickness = new Thickness(1);
        }
    }
}
