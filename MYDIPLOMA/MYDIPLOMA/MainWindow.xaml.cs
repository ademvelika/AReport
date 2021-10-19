using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using MYDIPLOMA.DataInterpretor;
using MYDIPLOMA.Dialog;
using MYDIPLOMA.Editor;
using MYDIPLOMA.Helper;
using MYDIPLOMA.Helper.Expression;
using MYDIPLOMA.Interface;
using MYDIPLOMA.MyControler;
using System;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace MYDIPLOMA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private EditorScreen EDITOR_SCREEN;
        public MainWindow()
        {
            InitializeComponent();

            EDITOR_SCREEN = new EditorScreen();

            Editor.Content = EDITOR_SCREEN;
        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(reziseCanvas));

        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Text t = new Text();

            t.Width = 100;
            t.Height = 80;
            AddController(t);
        }

       

    

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            for (int i = 12; i <= 60; i++)
            {
                var c = new ComboBoxItem { Tag = i, Content = i };
                FontSize.Items.Add(c);

            }


            NgjyraCombo.ItemsSource = typeof(Brushes).GetProperties().Select(x => new ComboBoxItem { Tag = x.GetValue(null) as Brush, Content = x.Name });

            Thread th = new Thread(LoadAsyncInstances);
            th.Start();
        }

        private void reziseCanvas()
        {
            EDITOR_SCREEN.Width = this.Width - LeftPanel.Width;

            
        }

        private void AddField_Click(object sender, RoutedEventArgs e)
        {

            Field t = new Field();

            t.Width = 150;
            t.Height = 80;
            AddController(t);
        }



        private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                var item = ((ComboBoxItem)FontSize.SelectedItem).Tag;

                var number = (int)item;
                ((ControlInterface)EDITOR_SCREEN.SelectedControl).setFont(number);

            }
            catch
            {

            }
        }

        private void NgjyraCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            var item = ((ComboBoxItem)NgjyraCombo.SelectedItem).Tag;

            if (EDITOR_SCREEN.SelectedControl != null)
                ((ControlInterface)EDITOR_SCREEN.SelectedControl).setColour((Brush)item);

        }

        private void AddTable_Click(object sender, RoutedEventArgs e)
        {
            Tabele t = new Tabele();

            t.Width = 350;
            t.Height = 120;
            AddController(t);
        }
        public void AddController(UserControl c)
        {
            Canvas.SetLeft(c, 10);
            Canvas.SetTop(c, 20);


            EDITOR_SCREEN.Children.Add(c);
        }

       


        public void RemoveFromDocument(UserControl u)
        {
            EDITOR_SCREEN.Children.Remove(u);
        }

        //Load Document
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.DefaultExt = ".xml";
            openfile.Filter = "(.xml)|*xml";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {

                try

                {


                    var path = openfile.FileName;


                    EDITOR_SCREEN.Children.Clear();
                    EDITOR_SCREEN.UpdateLayout();

                    var xmlStr = File.ReadAllText(@path);
                    var str = XElement.Parse(xmlStr);

                    foreach (var item in str.Elements())
                    {
                        if (item.Name.LocalName.ToString() == "DATABASE")
                        {
                            ((App)App.Current).Server = item.Attribute("INSTANCE").Value.ToString();
                            ((App)App.Current).DatabaseName = item.Attribute("DATABAZA").Value.ToString();
                            MyIntances.Items.Add(new ComboBoxItem { Content = ((App)App.Current).DatabaseName });
                        }
                        else

                        if (item.Name.LocalName.ToString() == XMLCREATOR.TEKST)
                        {
                            var txt = new Text();
                            var top = item.Attribute(XMLCREATOR.TOP).Value.ToString();
                            txt.Txt.Text = item.Attribute("VALUE").Value.ToString();
                            Canvas.SetTop(txt, double.Parse(top));
                            Canvas.SetLeft(txt, double.Parse(item.Attribute(XMLCREATOR.LEFT).Value.ToString()));
                            txt.Width = double.Parse(item.Attribute(XMLCREATOR.WIDTH).Value);
                            txt.Height = double.Parse(item.Attribute(XMLCREATOR.HEIGHT).Value.ToString());
                            EDITOR_SCREEN.Children.Add(txt);
                        }

                        else  if (item.Name.LocalName.ToString() == XMLCREATOR.FIELD)
                        {
                            var f = new Field();
                            Canvas.SetTop(f, double.Parse(item.Attribute(XMLCREATOR.TOP).Value.ToString()));
                            Canvas.SetLeft(f, double.Parse(item.Attribute(XMLCREATOR.LEFT).Value.ToString()));
                            f.DataBaseData = new Tuple<string, string>(item.Elements("DB").FirstOrDefault().Attribute("TN").Value.ToString(), item.Elements("DB").FirstOrDefault().Attribute("CN").Value.ToString());
                            f.LblName.Content = f.DataBaseData.Item2;
                            f.Width = double.Parse(item.Attribute(XMLCREATOR.WIDTH).Value);
                            f.Height = double.Parse(item.Attribute(XMLCREATOR.HEIGHT).Value);
                            EDITOR_SCREEN.Children.Add(f);
                        }

                        else if (item.Name.LocalName.ToString() == XMLCREATOR.TABELE)
                        {
                            var t = new Tabele();
                            Canvas.SetTop(t, double.Parse(item.Attribute(XMLCREATOR.TOP).Value.ToString()));
                            Canvas.SetLeft(t, double.Parse(item.Attribute(XMLCREATOR.LEFT).Value.ToString()));
                            t.Width = double.Parse(item.Attribute(XMLCREATOR.WIDTH).Value);
                            t.Height = double.Parse(item.Attribute(XMLCREATOR.HEIGHT).Value);

                            foreach (XElement colums in item.Element(XMLCREATOR.COLUMNS).Elements())
                            {

                                var kol = new Kolone();
                                
                                t.Container.ColumnDefinitions.Add(new ColumnDefinition());
                                Grid.SetColumn(kol, t.Container.ColumnDefinitions.Count - 1);

                                if (colums.Elements("DB").FirstOrDefault() != null)
                                {
                                    kol.FieldColumn.DataBaseData = new Tuple<string, string>(colums.Elements("DB").FirstOrDefault().Attribute("TN").Value.ToString(), colums.Elements("DB").FirstOrDefault().Attribute("CN").Value.ToString());
                                    kol.FieldColumn.LblName.Content = kol.FieldColumn.DataBaseData.Item2;
                                }
                                else
                                {
                                    var rows = colums.Element("FX").Elements().ToList();
                                    var e1 = new DataExpression();
                                    e1.ColumnName = new Tuple<string, string>(rows[0].Attribute("TN").Value, rows[0].Attribute("CN").Value);
                                    var OPERATOR = rows[1].Value;
                                    var e2 = new DataExpression();
                                    e2.ColumnName= new Tuple<string, string>(rows[2].Attribute("TN").Value, rows[2].Attribute("CN").Value);

                                    if (OPERATOR == "+"){
                                         var a = new AddExpression(e1, e2);
                                        kol.FieldColumn.Exp = a;
                                        kol.FieldColumn.LblName.Content = a.getFunctionAsString();
                                    }
                                    else if (OPERATOR == "*")
                                    {
                                        var a = new MultipleExpression(e1, e2);
                                        kol.FieldColumn.Exp = a;
                                        kol.FieldColumn.LblName.Content = a.getFunctionAsString();
                                    }
                                    else if (OPERATOR == "-")
                                    {
                                        var a = new SubstractExpression(e1, e2);
                                        kol.FieldColumn.Exp = a;
                                        kol.FieldColumn.LblName.Content = a.getFunctionAsString();
                                    }
                                    else if (OPERATOR == "/")
                                    {
                                        var a = new MultipleExpression(e1, e2);
                                        kol.FieldColumn.Exp = a;
                                        kol.FieldColumn.LblName.Content = a.getFunctionAsString();

                                    }
                                    

                                }
                             
                                kol.ColHeader.Text = colums.Attribute(XMLCREATOR.COLUMN_HEADER).Value.ToString();
                                if(colums.Attribute("TOT")!=null)
                                if (colums.Attribute("TOT").Value.ToString()== "True")
                                {
                                    kol.HasTotal = true;
                                }
                                t.Container.Children.Add(kol);
                            }
                            EDITOR_SCREEN.Children.Add(t);
                        }

                        //schema DATA
                        else if(item.Name.LocalName== "SCHEMA")
                        {
                            SchemaCreator.CurrentChoise = new TableRelationShips();
                            SchemaCreator.CurrentChoise.Parent_Table = item.Attribute("PT").Value.ToString();
                            SchemaCreator.CurrentChoise.ParentKey= item.Attribute("PK").Value.ToString();
                            SchemaCreator.CurrentChoise.Child_Table= item.Attribute("CT").Value.ToString();
                            SchemaCreator.CurrentChoise.ChildKey= item.Attribute("PK").Value.ToString();
                            SchemaCreator.CurrentChoise.MAIN_KEY.Key= item.Attribute("FILTER").Value.ToString();
                            try
                            {
                                ((App)App.Current).Server = item.Attribute("INSTANCE").Value.ToString();
                                ((App)App.Current).DatabaseName = item.Attribute("DATABASE").Value.ToString();
                            }
                            catch
                            {

                            }
                            var nextlist = item.Element("NEXT").Elements().ToList();

                            foreach (var  item2 in nextlist)
                            {
                               var pt = item2.Attribute("PT").Value.ToString();
                               var pk  = item2.Attribute("PK").Value.ToString();
                               var ct  = item2.Attribute("CT").Value.ToString();
                               var cky  = item2.Attribute("CK").Value.ToString();
                                SchemaCreator.CurrentChoise.NextRelationShips.Add(new TableRelationShips { Parent_Table = pt, ParentKey = pk, Child_Table = ct, ChildKey = cky });
                               
                            }

                            SchemaCreator.CurrentChoise.LoadColums();
                         
                        }
                    }
                }

                catch(Exception xe)
                {
                    MessageBox.Show("Dokumenti nuk mund te hapet, mund te jete korruptuar ose formati nuk eshte i sakte !");
                }
            }
               
        }
        //Save Document
        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savediag = new SaveFileDialog();

            savediag.DefaultExt = ".xml";
            savediag.Filter = "(.xml)|*xml";
            savediag.FileName = "newdocument";
            var savefile = savediag.ShowDialog();

            if (savefile == true)
            {
                
                var str = new XElement("Document");
                str.Add(SchemaCreator.CurrentChoise.getXml());

                foreach (ControlInterface item in EDITOR_SCREEN.Children)
                {
                    str.Add(item.GetXml());
                }


                str.Save(@savediag.FileName);
            }
        }
        //Ceate new Documenet
        private void New_Click(object sender, RoutedEventArgs e)
        {
            EDITOR_SCREEN.Children.Clear();
        }

        private void PreViewButton_Click(object sender, RoutedEventArgs e)
        {

            if (SchemaCreator.CurrentChoise == null)
            {
                MessageBox.Show("Ju lutem zgjidhni skemen !");
                return;
            }

            DocumentPreview doc = new DocumentPreview();
            var dialog= Microsoft.VisualBasic.Interaction.InputBox("Fusni Paramtrat["+SchemaCreator.CurrentChoise.MAIN_KEY.Key+"]?", "Dialog", "");
            SchemaCreator.CurrentChoise.MAIN_KEY.Value = dialog;
            SchemaCreator.CurrentChoise.LoadData();


            foreach (ControlInterface item in EDITOR_SCREEN.Children)
            {


                doc.Document.Children.Add(item.getPreview());
            }
            doc.Document.Height = EDITOR_SCREEN.Height;
            doc.Document.Width = EDITOR_SCREEN.Width;
            doc.ShowDialog();

        }

        private void LineBtn_Click(object sender, RoutedEventArgs e)
        {
            MyControler.Line l = new MyControler.Line();

            l.Height = 60;
            l.Width = 120;
            AddController(l);
        }



        private void  LoadAsyncInstances()
        {

            string myServer = Environment.MachineName;

               DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();


           

            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {



                   

                    for (int i = 0; i < servers.Rows.Count; i++)
                    {
                        if (myServer == servers.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
                        {
                            if ((servers.Rows[i]["InstanceName"] as string) != null)
                                MyIntances.Items.Add(new ComboBoxItem { Content = servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"] });
                            else
                                MyIntances.Items.Add(new ComboBoxItem { Content = servers.Rows[i]["ServerName"] });
                        }
                    }
                }
                );

        }

        private void LoadDatabases_Click(object sender, RoutedEventArgs e)
        {
            var item = (ComboBoxItem)MyIntances.SelectedItem;
            if(item==null)
            {
                MessageBox.Show("Ju lutem zgjidhni instancen");
                return;
            }
              Server server = new Server(item.Content.ToString());

            DatabaseCombo.Items.Clear();
            foreach (Database database in server.Databases)
            {
                DatabaseCombo.Items.Add(new ComboBoxItem { Content=database.Name});
            }
            DatabaseCombo.IsDropDownOpen = true;
        }

        private void NgarkoSkemen_Click(object sender, RoutedEventArgs e)
        {
            var instanca = ((ComboBoxItem)MyIntances.SelectedItem).Content.ToString();
            var databaza= ((ComboBoxItem)DatabaseCombo.SelectedItem).Content.ToString();

            ((App)App.Current).Server = instanca;
            ((App)App.Current).DatabaseName = databaza;
            SchemaCreator.CreateTree(AllEntities,ChildrenEnities);
            SchemaExpander.IsExpanded = true;
        }

        private void FilterData_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                FiledSelector f = new FiledSelector(SchemaCreator.CurrentChoise);
                f.ShowDialog();
                FilterText.Text = SchemaCreator.CurrentChoise.MAIN_KEY.Key;

            }
            catch
            {

            }

        }

        private void BorderClick_Click(object sender, RoutedEventArgs e)
        {
            ((ControlInterface)EDITOR_SCREEN.SelectedControl).setBorder();
        }

        private void ClearSchema_Click(object sender, RoutedEventArgs e)
        {
           AllEntities.Children.Clear();
            SchemaCreator.CurrentChoise = null;
        }

        
    }
}
