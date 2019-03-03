using MYDIPLOMA.DataInterpretor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYDIPLOMA.Services
{
    public class DataService
    {

        public static List<TableRelationShips> getTableRelationShips()
        {

        

     string sql = @"SELECT
    fk.name as RelationShip,
    tp.name as Child_Table,
    cp.name as ChildKey , 
    tr.name as Parent_Table,
    cr.name as ParentKey 
FROM 
    sys.foreign_keys fk
INNER JOIN 
    sys.tables tp ON fk.parent_object_id = tp.object_id
INNER JOIN 
    sys.tables tr ON fk.referenced_object_id = tr.object_id
INNER JOIN 
    sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
INNER JOIN 
    sys.columns cp ON fkc.parent_column_id = cp.column_id AND fkc.parent_object_id = cp.object_id
INNER JOIN 
    sys.columns cr ON fkc.referenced_column_id = cr.column_id AND fkc.referenced_object_id = cr.object_id
ORDER BY
    tp.name, cp.column_id

    ";
            var list = new List<TableRelationShips>();

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader reader;
            var connetionString = getConnectionString();
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();

                cmd = new SqlCommand(sql, cnn);

                reader = cmd.ExecuteReader();

                while (reader.Read())

                {

                    var t = new TableRelationShips
                    {
                        RelationShip = reader.GetValue(0).ToString(),
                        Child_Table = reader.GetValue(1).ToString(),
                        ParentKey = reader.GetValue(4).ToString(),
                        Parent_Table = reader.GetValue(3).ToString(),
                        ChildKey = reader.GetValue(2).ToString()
                    };
                    list.Add(t);


                }

                reader.Close();

                cmd.Dispose();

                cnn.Close();

                return list;

            }

            catch (Exception ex)

            {

                return new List<TableRelationShips>();

            }

        }



        public static List<Tuple<string,string>> getTableColumns(string TableName)
        {

            string sql = @"SELECT COLUMN_NAME
                   FROM INFORMATION_SCHEMA.COLUMNS
                   WHERE TABLE_NAME = N'" + TableName + "'";


            var list = new List<Tuple<string,string>>();
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader reader;
            var connetionString = getConnectionString();
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();

                cmd = new SqlCommand(sql, cnn);

                reader = cmd.ExecuteReader();

                while (reader.Read())

                {

                  
                        list.Add(new Tuple<string, string>(TableName, reader.GetValue(0).ToString()));
                    

                }

                reader.Close();

                cmd.Dispose();

                cnn.Close();

                return list;

            }

            

            catch (Exception ex)

            {

                return new List<Tuple<string,string>>();

            }
               
            
        }


        public static List<string> getParentValue(string sql,int columnnumber)
        {
            var list = new List<string>();
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader reader;
            var connetionString = getConnectionString();
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();

                cmd = new SqlCommand(sql, cnn);

                reader = cmd.ExecuteReader();

                while (reader.Read())

                {

                    for (int i = 0; i < columnnumber; i++)
                    {
                        list.Add(reader.GetValue(i).ToString());
                    }

                }

                reader.Close();

                cmd.Dispose();

                cnn.Close();

                return list;

            }

            catch (Exception ex)

            {

                return new List<string>();

            }

        }


        public static List<List<string>> getChildValue(string sql, int columnnumber)
        {
            var list = new List<List<string>>();
            for (int i = 0; i < columnnumber; i++)
            {
                list.Add(new List<string>());
            }

             
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader reader;
            var connetionString = getConnectionString();
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();

                cmd = new SqlCommand(sql, cnn);

                


                    reader = cmd.ExecuteReader();

                    var innerlist = new List<string>();
                    while (reader.Read())

                    {

                    for (int i = 0; i < columnnumber; i++)
                    {
                        list[i].Add(reader.GetValue(i).ToString());
                    }
                        

                    }

                    list.Add(innerlist);
                    reader.Close();
                

                cmd.Dispose();

                cnn.Close();

                return list;

            }

            catch (Exception ex)

            {

                return new List<List<string>>();

            }

        }

        public static string getConnectionString()
        {
            return "Data Source=" + ((App)App.Current).Server + ";Initial Catalog=" + ((App)App.Current).DatabaseName + ";integrated security=True";
        }

        public static List<string> getAllEntities()
        
           
        {
            string databasename = ((App)App.Current).DatabaseName;
                string sql = @"SELECT TABLE_NAME FROM "+databasename+".INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";


                var list = new List<string>();
                SqlConnection cnn;
                SqlCommand cmd;
                SqlDataReader reader;
                var connetionString = getConnectionString();
                cnn = new SqlConnection(connetionString);

                try
                {
                    cnn.Open();

                    cmd = new SqlCommand(sql, cnn);

                    reader = cmd.ExecuteReader();

                    while (reader.Read())

                    {


                        list.Add(reader.GetString(0));


                    }

                    reader.Close();

                    cmd.Dispose();

                    cnn.Close();

                    return list;

                }



                catch (Exception ex)

                {

                    return new List<string>();

                }


            }
        

    }
}

