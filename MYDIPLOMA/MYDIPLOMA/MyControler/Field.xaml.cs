using MYDIPLOMA.Dialog;
using MYDIPLOMA.Helper;
using MYDIPLOMA.Interface;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using System;
using MYDIPLOMA.DataInterpretor;

namespace MYDIPLOMA.MyControler
{
    /// <summary>
    /// Interaction logic for Field.xaml
    /// </summary>
    public partial class Field : UserControl,ControlInterface,SelectorInterface
    {
        public Tuple<string,string> DataBaseData { get; set; }
        public Field()
        {
            InitializeComponent();

            this.ContextMenu = new RightClick(this);
        }

        public virtual XElement GetXml()
        {
            var node = new XElement(XMLCREATOR.FIELD, new XAttribute("VALUE", "None"),new   XElement("DB",new XAttribute("TN",DataBaseData.Item1),new XAttribute("CN",DataBaseData.Item2)), new XAttribute(XMLCREATOR.WIDTH, this.Width), new XAttribute(XMLCREATOR.HEIGHT, this.Height), new XAttribute(XMLCREATOR.TOP, Canvas.GetTop(this)), new XAttribute(XMLCREATOR.LEFT, Canvas.GetLeft(this)));

            return node;
        }

        public void RemoveMySelf()
        {
            ((MainWindow)App.Current.MainWindow).RemoveFromDocument(this);
        }

        public void setColour(Brush c)
        {
            LblName.Foreground = c;
        }

        public void setFont(int size)
        {
            LblName.FontSize = size;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //openDialog and selectData
            FiledSelector dialog = new FiledSelector(this);
            dialog.ShowDialog();
        }

        

      public virtual  FrameworkElement getPreview()
        {
            //mer poszicionin
            double x = Canvas.GetLeft(this);
            double y = Canvas.GetTop(this);

            //mer te dhenat
            var l= new Label {Content=SchemaCreator.CurrentChoise.getFieldValue(DataBaseData) };
            l.Height = Double.NaN;
            l.Width =Double.NaN;
            l.FontSize = LblName.FontSize;
            l.Foreground = LblName.Foreground;
            l.BorderBrush = LblName.BorderBrush;
            l.BorderThickness = LblName.BorderThickness;
            Canvas.SetLeft(l, x-20);
            Canvas.SetTop(l, y+20);

            return l;
        }

        public void setSelection()
        {
            this.BorderThickness = new Thickness(2);
            this.BorderBrush = Brushes.LightBlue;
        }

        public virtual void setValue(Tuple<string,string> t) 
        {
            DataBaseData = t;
            LblName.Content = t.Item2;
        }

        public void setBorder()
        {
           LblName.BorderThickness=new Thickness(1);
            LblName.BorderBrush = Brushes.Black;
        }

        public Tuple<string, string> getValue()
        {
            return DataBaseData;
        }
    }
}
