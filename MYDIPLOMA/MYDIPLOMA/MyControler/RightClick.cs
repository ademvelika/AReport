using MYDIPLOMA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MYDIPLOMA.MyControler
{
  public  class RightClick:ContextMenu
    {

        
        public RightClick(ControlInterface u)
        {

            var menu = new MenuItem { Header = "Delete" };
            menu.Click += (s, e) =>
            {
                //detete event
                u.RemoveMySelf();

            };
            AddChild(menu);
        }

        public void AddOption(MenuItem item)
        {
            AddChild(item);
        }

    }
}
