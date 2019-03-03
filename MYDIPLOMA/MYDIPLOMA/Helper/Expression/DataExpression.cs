using MYDIPLOMA.DataInterpretor;
using MYDIPLOMA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MYDIPLOMA.Helper.Expression
{
    public class DataExpression : Expression,SelectorInterface
    {

        public Tuple<string,string> ColumnName { get; set; }

   
        public override List<string> getCollectionData()
        {
            return SchemaCreator.CurrentChoise.getFieldColumn(ColumnName);
        }

        public override string getFunctionAsString()
        {
            return ColumnName.Item2;
        }

        public Tuple<string, string> getValue()
        {
            return Tuple.Create("", "");
        }

        public override XElement getXml()
        {
            var f = new XElement("VAR", new XAttribute("TN", ColumnName.Item1), new XAttribute("CN",ColumnName.Item2));
            return f;
        }

        public void setExpression()
        {
            throw new NotImplementedException();
        }

        public void setValue(Tuple<string,string> t)
        {
            ColumnName = t;
        }
    }
}
