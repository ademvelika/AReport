using MYDIPLOMA.DataInterpretor;
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
    /// Interaction logic for FunctionWindowd.xaml
    /// </summary>
    public partial class FunctionWindowd : Window
    {

       public TableField Column { get; set; }
        public FunctionWindowd()
        {
            InitializeComponent();
        }

        public FunctionWindowd(TableField t)
        {
            InitializeComponent();

            Column=t;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {


         
            var op= (string)((ComboBoxItem)Operator.SelectedItem).Content;

            var d1 = new Helper.Expression.DataExpression();
            d1.ColumnName = (Tuple<string,string>)((ComboBoxItem)Parameter1.SelectedItem).Tag;
            var d2 = new Helper.Expression.DataExpression();
            d2.ColumnName = (Tuple<string, string>)((ComboBoxItem)Parameter2.SelectedItem).Tag;
            Helper.Expression.Expression exp=null;
            switch (op)
            {
                case "+":

                    exp = new Helper.Expression.AddExpression(d1, d2);
                    break;
                case "*":
                    exp = new Helper.Expression.MultipleExpression(d1, d2);
                    break;
                case "/":
                    exp = new Helper.Expression.DivideExpression(d1, d2);
                    break;
                case "-":
                    exp = new Helper.Expression.SubstractExpression(d1, d2);
                    break;
                default:
                    break;
              

            }

            Column.SetExpression(exp);
        }

  

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if(SchemaCreator.CurrentChoise.ChildFields.Count==0)
            SchemaCreator.CurrentChoise.LoadColums();

            foreach (var childcol in SchemaCreator.CurrentChoise.ChildFields)
            {

                Parameter1.Items.Add(new ComboBoxItem { Content = childcol,Tag=childcol });
                Parameter2.Items.Add(new ComboBoxItem { Content = childcol,Tag=childcol });

            }
        }
    }
}
