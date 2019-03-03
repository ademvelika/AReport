using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MYDIPLOMA.Preview
{
   public class PreviewScreen:Canvas
    {

        static PreviewScreen()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PreviewScreen), new FrameworkPropertyMetadata(typeof(PreviewScreen)));
        }
        protected override Size MeasureOverride(Size constraint)
        {
            double bottomMost = 0d;
            double rightMost = 0d;

            foreach (object obj in Children)
            {
                FrameworkElement child = obj as FrameworkElement;

                if (child != null)
                {
                    child.Measure(constraint);

                    bottomMost = Math.Max(bottomMost, GetTop(child) + child.DesiredSize.Height);
                    rightMost = Math.Max(rightMost, GetLeft(child) + child.DesiredSize.Width);
                }
            }
            return new Size(rightMost, bottomMost);
        }
      
    }
}
