using MYDIPLOMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYDIPLOMA.DataInterpretor
{
    public  class Entity
    {
        public string Table_Name { get; set; }

        public List<string> ColumnList { get; set; }
        public Entity(string name)
        {

            Table_Name = name;

            ColumnList = new List<string>();
            var l = DataService.getTableColumns(Table_Name);
            foreach (var item in l)
            {
                ColumnList.Add(item.Item2);
            }

        }

    }
}
