using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace MYDIPLOMA.Interface
{
    public interface ControlInterface
    {

        void setFont(int size);
        void setColour(Brush c);
        void setSelection();
        void setBorder();
        void RemoveMySelf();
        FrameworkElement getPreview();
        XElement GetXml();
      
    }
}
