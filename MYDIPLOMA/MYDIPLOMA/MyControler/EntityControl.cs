using MYDIPLOMA.DataInterpretor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MYDIPLOMA.MyControler
{
    public class EntityControl:Border
    {

        private TextBlock Header;
        private Entity Data;
        public EntityControl(Entity d)
        {
            Data = d;

            BorderBrush = Brushes.Gray;
            BorderThickness = new System.Windows.Thickness(1);
            Width = 200;
            Height = 200;
            createGUI();
        }

        private void createGUI()
        {
            StackPanel root=new StackPanel();
            Header = new TextBlock
            {
                Text = Data.Table_Name,
                TextAlignment = System.Windows.TextAlignment.Center,
                Background = Brushes.LightBlue,
                Foreground = Brushes.White,
                FontSize = 20
            };
            Separator s = new Separator();
            StackPanel columnspanel = new StackPanel();
            foreach (var item in Data.ColumnList)
            {
                columnspanel.Children.Add(new Label { Content = item,FontSize=11,FontWeight=FontWeights.ExtraBold });
            }
            root.Children.Add(Header);
            root.Children.Add(s);
            root.Children.Add(columnspanel);
         
            Child = root;
        }
    }
}
