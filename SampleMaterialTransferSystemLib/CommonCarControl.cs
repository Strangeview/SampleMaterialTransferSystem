using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class CommonCarControl : Control
    {
        // public CommonCarControl newCar;
        public Storyboard executeAnimation = new Storyboard();
        static CommonCarControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommonCarControl), new FrameworkPropertyMetadata(typeof(CommonCarControl)));
        }
        /// <summary>
        /// Number of Car can be set by CarText in type of string.
        /// </summary>
        public static readonly DependencyProperty CarTextProperty = DependencyProperty.Register("CarText",typeof(string),typeof(CommonCarControl));
        public string CarText
        {
            get
            {
                return (string)GetValue(CarTextProperty);
            }
            set
            {
                SetValue(CarTextProperty,value);
            }
        }
        /// <summary>
        /// Property of InnerBorderBC indicate whether car can access command,you can assign string of color.
        /// </summary>
        public static readonly DependencyProperty InnerBorderBCProperty = DependencyProperty.Register("InnerBorderBC",typeof(string),typeof(CommonCarControl),new PropertyMetadata("Gray",
            new PropertyChangedCallback(InnerBorderBCChangedCallback)));
        public string InnerBorderBC
        {
            get
            {
                return (string)GetValue(InnerBorderBCProperty);
            }
            set
            {
                SetValue(InnerBorderBCProperty,value);
            }
        }
        private static void InnerBorderBCChangedCallback(DependencyObject obj,DependencyPropertyChangedEventArgs args)
        {
            CommonCarControl ccc = (CommonCarControl)obj;
            ccc.PauseAndResumeAnimation();
        }
        /// <summary>
        /// Property of InnerBorderBC1 indicate whether there are product on the car,you can assign  string of color
        /// </summary>
        public static readonly DependencyProperty InnerBorderBC1Property = DependencyProperty.Register("InnerBorderBC1", typeof(string), typeof(CommonCarControl), new PropertyMetadata("Gray"));
        public string InnerBorderBC1
        {
            get
            {
                return (string)GetValue(InnerBorderBC1Property);
            }
            set
            {
                SetValue(InnerBorderBC1Property,value);
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
        private PathGeometry carPathGeometry;
        public PathGeometry CarPathGeometry
        {
            get
            {
                return carPathGeometry;
            }
            set
            {
                carPathGeometry = value;
            }
        }
        public void CarAnimation(PathGeometry pg)
        {
            TranslateTransform translate = new TranslateTransform();
            this.RenderTransform = translate;
            DoubleAnimationUsingPath xAnimation = new DoubleAnimationUsingPath();
            xAnimation.PathGeometry = pg;
            xAnimation.Duration = TimeSpan.FromSeconds(30);
            xAnimation.Source = PathAnimationSource.X;
            Storyboard.SetTarget(xAnimation,this);
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath("RenderTransform.(TranslateTransform.X)")) ;
            DoubleAnimationUsingPath yAnimation = new DoubleAnimationUsingPath();
            yAnimation.PathGeometry = pg;
            yAnimation.Duration = TimeSpan.FromSeconds(30);
            yAnimation.Source = PathAnimationSource.Y;
            Storyboard.SetTarget(yAnimation,this);
            Storyboard.SetTargetProperty(yAnimation,new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
            executeAnimation.Children.Add(xAnimation);
            executeAnimation.Children.Add(yAnimation);
            executeAnimation.RepeatBehavior = RepeatBehavior.Forever;
        }
        public void PauseAndResumeAnimation()
        {
            if (InnerBorderBC == "Yellow")
            {
                executeAnimation.Pause(this);
            }
             if (InnerBorderBC == "Green")
            {
                executeAnimation.Resume(this);
            }
        }
    }
}
