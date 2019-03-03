using MYDIPLOMA.DataInterpretor;
using MYDIPLOMA.Interface;
using MYDIPLOMA.MyControler;
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
using System.Windows.Shapes;

namespace MYDIPLOMA.Dialog
{
    /// <summary>
    /// Interaction logic for FiledSelector.xaml
    /// </summary>
    public partial class FiledSelector : Window
    {

        private  SelectorInterface  Element { get; set; }
        
        public FiledSelector(SelectorInterface f)
        {
            InitializeComponent();

            Element = f;
        }

        public FiledSelector()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SchemaCreator.CurrentChoise.LoadColums();
            var comparer = Element.getValue();
            foreach (var item in SchemaCreator.CurrentChoise.ParentFields)
            {

                Button b = new Button {Content=item.Item2 };
                b.Click +=(s,ev) =>
                {
                    Element.setValue(item);
                    Close();
                };

              

                    if (item.Equals(comparer))
                    {
                        b.Foreground = Brushes.Red;
                    }
                
                


                Container.Children.Add(b);
            }

       
            foreach (var childcol in SchemaCreator.CurrentChoise.ChildFields)
            {
                Button b = new Button { Content = childcol };
                b.Click += (s, ev) =>
                {
                    Element.setValue(childcol);
                    Close();
                };

             
                    if (childcol.Equals(comparer))
                    {
                        b.Foreground = Brushes.Red;
                    }
                
                
                ChildContainer.Children.Add(b);
            }
        }
    }
}
