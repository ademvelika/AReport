using MYDIPLOMA.Dialog;
using MYDIPLOMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MYDIPLOMA.DataInterpretor
{
    public class SchemaCreator
    {
        public static List<TableRelationShips> ALL_RELATIONSHIP { get; set; }
        public static TableRelationShips CurrentChoise { get; set; }
        public static void CreateTree(StackPanel t, StackPanel realtionPanel)
        {


            var list = DataService.getTableRelationShips();
            ALL_RELATIONSHIP = list;


            foreach (var item in list.Select(x => x.Parent_Table).Distinct())
            {
                ToggleButton root = new ToggleButton { Content = item };
                root.Height = 40;
                root.Margin = new System.Windows.Thickness(4, 0, 0, 4);
                root.Click += (s, e) =>
                {

                    root.Foreground = Brushes.Red;

                    foreach (ToggleButton children in t.Children)
                    {
                        if (children != root)
                        {
                            children.Foreground = Brushes.Black;
                            children.IsChecked = false;
                        }
                    }


                    EntitySelector selector = new EntitySelector(new Entity(item));
                    selector.ShowDialog();
                };



                t.Children.Add(root);
            }



        }
    }
}
