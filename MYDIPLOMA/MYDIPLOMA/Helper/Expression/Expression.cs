using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MYDIPLOMA.Helper.Expression
{
   public abstract class Expression
    {

        public Expression E1 { get; set; }
        public Expression E2 { get; set; }



        public abstract List<string> getCollectionData();
        public abstract string  getFunctionAsString();
        public abstract XElement getXml();
    }
}
