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
    /// Interaction logic for Tabele.xaml
    /// </summary>
    public partial class Tabele : UserControl,ControlInterface
    {
        public Tabele()
        {
            InitializeComponent();
            this.ContextMenu = new RightClick(this);
        }

        public XElement GetXml()
        {
            var node = new XElement(XMLCREATOR.TABELE, new XAttribute("VALUE", "None"), new XAttribute(XMLCREATOR.WIDTH, this.Width), new XAttribute(XMLCREATOR.HEIGHT, this.Height), new XAttribute(XMLCREATOR.TOP, Canvas.GetTop(this)), new XAttribute (XMLCREATOR.LEFT, Canvas.GetLeft(this)));
            var colums = new XElement(XMLCREATOR.COLUMNS);
            foreach ( ControlInterface i in Container.Children)
            {
                colums.Add(i.GetXml());
            }
            node.Add(colums);
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
            throw new NotImplementedException();
        }

        public void setFont(int size)
        {
            throw new NotImplementedException();
        }

        private void AddColumnBtn_Click(object sender, RoutedEventArgs e)
        {


            Kolone k = new Kolone();
            k.Width = 100; ;
            Container.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetColumn(k, Container.ColumnDefinitions.Count-1 );
            Container.Children.Add(k);
          
            k.Width = Double.NaN;
        }

        FrameworkElement ControlInterface.getPreview()
        {
            Grid g = new Grid();
            g.Width = this.Width;
            g.Height = Double.NaN;
            double x = Canvas.GetLeft(this);
            double y = Canvas.GetTop(this);

           
            Canvas.SetLeft(g, x);
            Canvas.SetTop(g, y);
            foreach (ControlInterface item in Container.Children)
            {
                g.ColumnDefinitions.Add(new ColumnDefinition());

                var itemref = item.getPreview();
                Grid.SetColumn(itemref, g.ColumnDefinitions.Count - 1);
                g.Children.Add(itemref);
            }
            return g;
        }

        public void setBorder()
        {
            throw new NotImplementedException();
        }

      
    }
}
