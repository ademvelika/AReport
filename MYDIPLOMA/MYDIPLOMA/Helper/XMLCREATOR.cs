using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MYDIPLOMA.Helper
{
  public static  class XMLCREATOR
    {
        public static string TEKST = "TEKST";
        public static string FIELD = "FIELD";
        public static string TABELE = "TABELE";


        public static string TOP = "TOP";
        public static string LEFT = "LEFT";

        public static string WIDTH = "WIDTH";
        public static string HEIGHT = "HEIGHT";



        public static string TABLE_COLUMN = "TABLECOLUMN";
        public static string COLUMN_HEADER = "COLUMNHEADER";
        public static string COLUMNS = "COLUMNS";


        public static Object ObjectToXML(string xml, Type objectType)
        {
            StringReader strReader = null;
            XmlSerializer serializer = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            try
            {
                strReader = new StringReader(xml);
                serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                //Handle Exception Code
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }



    }
}
