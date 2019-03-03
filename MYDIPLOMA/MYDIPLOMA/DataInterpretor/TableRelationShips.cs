using MYDIPLOMA.Interface;
using MYDIPLOMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace MYDIPLOMA.DataInterpretor
{
    public class TableRelationShips : SelectorInterface, ICloneable
    {

        public string RelationShip { get; set; }
        public string Parent_Table { get; set; }
        public string ParentKey { get; set; }
        public string Child_Table { get; set; }
        public string ChildKey { get; set; }
        public List<TableRelationShips> NextRelationShips = new List<TableRelationShips>();
        public MainKey MAIN_KEY = new MainKey();

        public List<Tuple<string, string>> ParentFields { get; set; }
        public Dictionary<Tuple<string, string>, string> ParentValues { get; set; }
        public Dictionary<Tuple<string, string>, List<string>> ChildValues { get; set; }
        public List<Tuple<string, string>> ChildFields { get; set; }


        //tempListForLoadig

        private Queue<TableRelationShips> tempRelationShips = new Queue<TableRelationShips>();
        public void LoadColums()
        {
            ParentFields = DataService.getTableColumns(Parent_Table);
            ChildFields = DataService.getTableColumns(Child_Table);

            if (NextRelationShips != null)
            {
                foreach (var item in NextRelationShips)
                {
                    var newl = DataService.getTableColumns(item.Parent_Table);
                    foreach (var s in newl)
                    {
                        ChildFields.Add(s);
                    }
                }
            }

        }

        public void LoadData()
        {



            try
            {

                var select = "select ";
                for (int i = 0; i < ParentFields.Count; i++)
                {


                    if ((ParentFields.Count - 1) == i)
                    {
                        select += " " + ParentFields[i].Item2;
                    }
                    else
                    {
                        select += " " + ParentFields[i].Item2 + ",";
                    }


                }



                select += "  from [" + Parent_Table + "] where " + MAIN_KEY.Key + "='" + MAIN_KEY.Value + "'";

                var list = DataService.getParentValue(select, ParentFields.Count);

                ParentValues = new Dictionary<Tuple<string, string>, string>();
                for (int i = 0; i < ParentFields.Count; i++)
                {
                    ParentValues.Add(new Tuple<string, string>(Parent_Table, ParentFields[i].Item2), list[i]);
                }


                LoadData2();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nje gabim ka ndodhur ne krijimin e te dhenave" + ex.Message.ToString());
            }
        }



        public void LoadData2()
        {
            var select = "select ";
            for (int i = 0; i < ChildFields.Count; i++)
            {


                if ((ChildFields.Count - 1) == i)
                {
                    select += "[" + ChildFields[i].Item1 + "].[" + ChildFields[i].Item2+"]";
                }
                else
                {
                    select += "[" + ChildFields[i].Item1 + "].[" + ChildFields[i].Item2 + "],";
                }


            }



            select += "  from [" + Child_Table + "] " + getJoinPart() + " where [" + Child_Table + "]." + ChildKey + "='" + MAIN_KEY.Value + "'";

            var list = DataService.getChildValue(select, ChildFields.Count);

            ChildValues = new Dictionary<Tuple<string, string>, List<string>>();
            for (int i = 0; i < ChildFields.Count; i++)
            {

                ChildValues.Add(new Tuple<string, string>(ChildFields[i].Item1, ChildFields[i].Item2), list[i]);


            }
        }


        public object getFieldValue(Tuple<string, string> filed)
        {

            try
            {
                return ParentValues[Tuple.Create(filed.Item1, filed.Item2)];
            }
            catch
            {
                return "";
            }
        }

        public List<string> getFieldColumn(Tuple<string, string> filed)
        {
            try
            {
                return ChildValues[filed];
            }
            catch(Exception e)
            {
                return new List<string>();
            }
        }

        public void setValue(Tuple<string, string> t)
        {
            MAIN_KEY.Key = t.Item2;
        }

        public List<TableRelationShips> LoadNextParentForChildren()
        {
            var l = SchemaCreator.ALL_RELATIONSHIP.Where(x => x.Child_Table == Child_Table && x.Parent_Table != Parent_Table).ToList();
            foreach (var item in l)
            {
                NextRelationShips.Add(item);
                tempRelationShips.Enqueue(item);
            }
          
            return l;
        }

        public List<TableRelationShips> LoadNextParentFromParent()
        {
            int oldlength = tempRelationShips.Count;
            var returnlist = new List<TableRelationShips>();
            for (int i = 0; i < oldlength; i++)
            {
                var RemovedElement = tempRelationShips.Dequeue();
                var l = SchemaCreator.ALL_RELATIONSHIP.Where(x => x.Child_Table == RemovedElement.Parent_Table && x.Parent_Table != Parent_Table).ToList();
                foreach (var item in l)
                {
                    NextRelationShips.Add(item);
                    returnlist.Add(item);

                }
            }
           
            return returnlist;
        }

        public string getJoinPart()
        {

            string line = "";
            if (NextRelationShips != null)
            {


                foreach (var item in NextRelationShips)
                {
                    line += " join [" + item.Parent_Table + "] on [" + item.Parent_Table + "]." + item.ParentKey + "= [" + item.Child_Table + "]." + item.ChildKey + "";
                }



                return line;
            }

            else
            {
                return "";
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Tuple<string, string> getValue()
        {
            return Tuple.Create(Parent_Table, MAIN_KEY.Key);
        }

        public void reset()
        {
            NextRelationShips.Clear();
            tempRelationShips.Clear();
          
        }

        public XElement getXml()
        {
            var ele = new XElement("SCHEMA", new XAttribute("PT", Parent_Table), new XAttribute("PK", ParentKey), new XAttribute("CT", Child_Table), new XAttribute("CK", ChildKey), new XAttribute("FILTER", MAIN_KEY.Key),new XAttribute("INSTANCE", ((App)App.Current).Server),new XAttribute("DATABASE", ((App)App.Current).DatabaseName));

            var nextel = new XElement("NEXT");
            foreach (var item in NextRelationShips)
            {
                nextel.Add(new XElement("ITEM", new XAttribute("PT", item.Parent_Table), new XAttribute("PK", item.ParentKey), new XAttribute("CT", item.Child_Table), new XAttribute("CK", item.ChildKey)));
            }
            ele.Add(nextel);
            return ele;
        }
    }
}
