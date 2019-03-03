using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MYDIPLOMA.Helper.Expression
{
    public class AddExpression : Expression
    {


        public AddExpression(Expression e1,Expression e2)
        {
            E1 = e1;
            E2 = e2;
        }
        public override List<string> getCollectionData()
        {
            var shuma = new List<string>();
            var L1 = E1.getCollectionData();
            var L2 = E2.getCollectionData();
            for (int i=0;i<L1.Count;i++ )
            {

                shuma.Add((double.Parse(L1[i]) + double.Parse(L2[i])).ToString());

            }


            return shuma;
        }

        public override string getFunctionAsString()
        {
            return "(" + E1.getFunctionAsString() + "+" + E2.getFunctionAsString() + ")";
        }

        public override XElement getXml()
        {
            var fx = new XElement("FX", E1.getXml(), new XElement("OPERATOR", "+"), E2.getXml());

            return fx;
        }
    }
}
