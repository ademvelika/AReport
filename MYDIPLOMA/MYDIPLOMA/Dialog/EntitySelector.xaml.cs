using MYDIPLOMA.DataInterpretor;
using MYDIPLOMA.MyControler;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static MYDIPLOMA.Helper.Helper;

namespace MYDIPLOMA.Dialog
{
    /// <summary>
    /// Interaction logic for EntitetySelector.xaml
    /// </summary>
    public partial class EntitySelector : Window
    {
        private bool HasMany { get; set; }

        private TableRelationShips Root;

        private Entity entity { get; set; }

        private EntityControl LastControl;

        public EntitySelector(Entity e)
        {
            InitializeComponent();
         
            entity = e;

            var list = SchemaCreator.ALL_RELATIONSHIP.Where(x => x.Parent_Table == entity.Table_Name).ToList();
            if (list.Count > 1)
            {
                //open dialog to select opstions
                HasMany = true;

                foreach (var item in list)
                {
                    Button b = new Button { Content = item.Child_Table ,Margin=new Thickness(5,2,5,2)};
                    b.Click += (s, ev) =>
                    {
                        Root = item.Clone() as TableRelationShips;
                        Root.reset();
                        SchemaCreator.CurrentChoise = Root;
                        CreateInitialSchema();
                    };
                    ManyEntity.Children.Add(b);
                }

            }
            else
            {
                Root =  list.FirstOrDefault().Clone() as TableRelationShips;
                Root.reset();
                SchemaCreator.CurrentChoise = Root;
            }


          

       
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void GONEXT_Click(object sender, RoutedEventArgs e)
        {

            List<TableRelationShips> templist;
            if (Root.NextRelationShips.Count == 0)
            {
             templist=Root.LoadNextParentForChildren();
            }

            else
            {
              templist=  Root.LoadNextParentFromParent();
            }

            int i = 0;
            foreach (var item in templist)
            {
                
                EntityControl en = new EntityControl(new Entity(item.Parent_Table));
                
               double size= getWidhOfBusyArea();
                double newleft,newtop;
                if(size+400<(Editor.ActualWidth-80))
                {
                    newleft = size + 400;
                    newtop = 30;

                }
                else
                {
                    newtop = 530;
                    newleft = size+i*300;
                    i++;
                }
                Canvas.SetLeft(en, newleft);
                Canvas.SetTop(en, newtop);
                
                Editor.Children.Add(en);
                AddConnection(LastControl, en,RealtionShipType.ManyToOne);

                if(templist.Count==1)
                LastControl = en;

            }
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {

            if(!HasMany)
            CreateInitialSchema();
        }


        private void CreateInitialSchema()
        {
            Editor.Children.Clear();

            EntityControl b = new EntityControl(entity);
            Canvas.SetLeft(b, 20);
            Canvas.SetTop(b, 30);
            Editor.Children.Add(b);

            EntityControl firstchildren = new EntityControl(new Entity(Root.Child_Table));
            var leftpos = Canvas.GetLeft(b) + b.Width + 200;
            Canvas.SetLeft(firstchildren, leftpos);
            Canvas.SetTop(firstchildren, Canvas.GetTop(b));
            Editor.Children.Add(firstchildren);
            AddConnection(b, firstchildren, RealtionShipType.OneToMany);
            LastControl = firstchildren;
        }

        private void AddConnection(EntityControl e1,EntityControl e2,RealtionShipType t)
        {
            System.Windows.Shapes.Line l = new System.Windows.Shapes.Line();
            l.Stroke = new SolidColorBrush(Colors.Black);
            l.StrokeThickness = 2.0;


            l.X1 = Canvas.GetLeft(e1) + e1.Width;
            l.X2 = Canvas.GetLeft(e2);
            l.Y1 = Canvas.GetTop(e1) + e1.Height / 2;
            l.Y2 = Canvas.GetTop(e2) + e2.Height / 2;
            Editor.Children.Add(l);

            Ellipse e = new Ellipse();
            e.Height = 15;
            e.Fill = new SolidColorBrush(Colors.Black);
            e.Width = 15;

            if(t==RealtionShipType.OneToMany)
            {
                Canvas.SetLeft(e, l.X2 - 15 / 2);
                Canvas.SetTop(e, l.Y2 - 15 / 2);
            }
            else
            {
                Canvas.SetLeft(e, l.X1 - 15 / 2);
                Canvas.SetTop(e, l.Y1 - 15 / 2);
            }
            
            Editor.Children.Add(e);
        }

        private double getWidhOfBusyArea()
        {

            double max= 0;
            foreach (FrameworkElement item in Editor.Children)
            {
                var ent = item as EntityControl;
                System.Windows.Shapes.Line LINE;
                if (ent == null)
                {
                    LINE = item as System.Windows.Shapes.Line;
                        if(LINE!=null)
                        if (LINE.X2 > max)
                        {
                            max = LINE.X2;
                        }
                }
                else
                {
                    if (Canvas.GetLeft(ent) > max)
                    {
                        max = Canvas.GetLeft(ent);
                    }
                }

               

            }

            return max;
        }
    }
}
