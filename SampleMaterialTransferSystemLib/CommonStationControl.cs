using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleMaterialTransferSystemLib
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SampleMaterialTransferSystemLib"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SampleMaterialTransferSystemLib;assembly=SampleMaterialTransferSystemLib"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    [TemplatePart(Name ="InnerRectangelElement",Type =typeof(Rectangle))]
    public class CommonStationControl : Control
    {
        static CommonStationControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommonStationControl), new FrameworkPropertyMetadata(typeof(CommonStationControl)));
        }
        /*
        public static readonly DependencyProperty BackgroundProperty;
        public Brush Background
        {
            get;set;
        }*/
        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register("FillColor", typeof(string), typeof(CommonStationControl),new PropertyMetadata("Gray"));
        public String FillColor
        {
            get
            {
                return (string)GetValue(FillColorProperty);
            }
            set
            {
                SetValue(FillColorProperty,value);
            }
        }
        public static readonly DependencyProperty StationTextProperty = DependencyProperty.Register("StationText",typeof(string),typeof(CommonStationControl),new PropertyMetadata("1"));
        public string StationText
        {
            get
            {
                return (string)GetValue(StationTextProperty);
            }
            set
            {
                SetValue(StationTextProperty,value);
            }
        }
        private double topDistance;
        private double leftDistance;
        public double TopDistance
        {
            get
            {
                return topDistance;
            }
            set
            {
                topDistance = value;
            }
        }
        public double LeftDistance
        {
            get
            {
                return leftDistance;
            }
            set
            {
                leftDistance = value;
            }
        }

       
    }
}
