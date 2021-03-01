using SampleMaterialTransferSystemLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace SampleMaterialTransferSystemClient
{
    /// <summary>
    /// Interaction logic for CommandCreateWindow.xaml
    /// </summary>
    public partial class CommandCreateWindow : Window
    {
        IList<CommonStationControl> temp = new List<CommonStationControl>();
        IList<CommonCarControl> carTemp = new List<CommonCarControl>();
        Storyboard animationExecute = new Storyboard() ;
        CommonCarControl myCar = null;
        public CommandCreateWindow()
        {
            InitializeComponent();
            //myCanvas.
            
        }

        private void OriginStationLoad_Click(object sender, RoutedEventArgs e)
        {
            //IList<CommonStationControl> temp = new List<CommonStationControl>();
            if (MainWindow.myStationStore.Count==0)
            {
                MessageBox.Show("There are not StationCoin on the Clien,Please Add StationCoin ");
                return;
            }
            else
            {
                temp = MainWindow.myStationStore;
            }
           
            foreach(CommonStationControl csc in temp)
            {
                OriginStationComBox.Items.Add("Station"+csc.StationText);
            }
            
        }

        private void OriginStationComBox_Closed(object sender, EventArgs e)
        {
            //IList<CommonStationControl> temp = new List<CommonStationControl>();
            if (OriginStationComBox.Text == string.Empty)
            {
                return;
            }
            //OriginStationDisplay.Text=OriginStationComBox.Text.Substring(7).Trim();
            foreach(CommonStationControl csc in temp)
            {
                if(csc is null)
                {
                    return;
                }
                if (csc.StationText == OriginStationComBox.Text.Substring(7).Trim())
                {
                    csc.LeftDistance = csc.Margin.Left;
                    csc.TopDistance = csc.Margin.Top;
                    if (csc.LeftDistance == 0 || csc.TopDistance == 0)
                    {
                        MessageBox.Show("Please select 0~~~~13 Station!!!");
                        return;
                    }
                    OriginStationDisplay.Text = "Station" + csc.StationText + "X坐标为：" + csc.LeftDistance + "\n" + "Station" + csc.StationText + "Y坐标为：" + csc.TopDistance;
                }
            }

        }

        private void TargetStationLoad_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.myStationStore.Count == 0)
            {
                MessageBox.Show("There are not Station on the client,Please add station on the Canvas!");
            }
            else
            {
                temp = MainWindow.myStationStore;
            }
            foreach(CommonStationControl csc in temp)
            {
                TargetStationComBox.Items.Add("Station"+csc.StationText);
            }
        }

        private void TargetStationComBox_Closed(object sender, EventArgs e)
        {
            if (TargetStationComBox.Text == string.Empty)
            {
                return;
            }
            foreach(CommonStationControl csc in temp)
            {
                if(csc is null)
                {
                    return;
                }
                if (csc.StationText == TargetStationComBox.Text.Substring(7).Trim())
                {
                    csc.LeftDistance = csc.Margin.Left;
                    csc.TopDistance = csc.Margin.Top;
                    if (csc.LeftDistance == 0 || csc.TopDistance == 0)
                    {
                        MessageBox.Show("Please select 0~~~~24 Station!!!");
                        return;
                    }
                    TargetStationDisplay.Text = "Station" + csc.StationText + "X坐标为：" + csc.LeftDistance + "\n" + "Station" + csc.StationText + "Y坐标为：" + csc.TopDistance;
                }
            }
        }

        private void SelectCarNumber_Close(object sender, EventArgs e)
        {
            if (SelectCarNumber.Text == string.Empty)
            {
                return;
            }
            foreach(CommonCarControl ccc in carTemp)
            {
                if(ccc is null)
                {
                    return;
                }
                if (ccc.CarText == SelectCarNumber.Text.Trim())
                {
                    ccc.TopDistance = Canvas.GetTop(ccc);
                    ccc.LeftDistance = Canvas.GetLeft(ccc);
                    TargetCarDisplay.Text = ccc.CarText + "X坐标为：" + ccc.LeftDistance + "\n" + ccc.CarText + "Y坐标为：" + ccc.TopDistance;
                }
            }
        }

        private void TargetCarLoad_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.myCarStore.Count == 0)
            {
                MessageBox.Show("There are not Car on the clien,Please add Car first!!!");
                return;
            }
            else
            {
                carTemp = MainWindow.myCarStore;
            }
            foreach(CommonCarControl ccc in carTemp)
            {
                SelectCarNumber.Items.Add(ccc.CarText);
            }

        }

        private void ExecuteCommand_Click(object sender, RoutedEventArgs e)
        {
            int originStationIndex,targetStationIndex;
            double originStationX, originStationY,targetStationX,targetStationY;
            Point st, tg;
            PathGeometry pathGeometry = new PathGeometry();
            if (OriginStationComBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                Int32.TryParse(OriginStationComBox.Text.Substring(7).Trim(),out originStationIndex);
                originStationX=temp[originStationIndex].Margin.Left+30;
                originStationY = temp[originStationIndex].Margin.Top-40;
            }
            if (TargetStationComBox.Text == string.Empty)
            {
                return;
            }
            else
            {
                Int32.TryParse(TargetStationComBox.Text.Substring(7),out targetStationIndex);
                targetStationX = temp[targetStationIndex].Margin.Left+30;
                targetStationY = temp[targetStationIndex].Margin.Top-40;
                temp[targetStationIndex].Background = Brushes.Purple;
            }
            st = new Point(originStationX,originStationY);
            tg = new Point(targetStationX,targetStationY);
            pathGeometry = RoadSelect(st,tg);//call RoadSelect Function.
            if (MainWindow.myCanvasStore.Children.Count == 0)
            {
                MessageBox.Show("Canvas is not elemnt");
                return;
            }
            foreach (UIElement pg in MainWindow.myCanvasStore.Children)
            {
                if (pg is CommonCarControl)
                {
                    myCar = pg as CommonCarControl;
                }
            }
            TranslateTransform translate = new TranslateTransform();
            myCar.RenderTransform = translate;
            DoubleAnimationUsingPath xAnimation = new DoubleAnimationUsingPath();
            xAnimation.PathGeometry = pathGeometry;
            xAnimation.Duration = TimeSpan.FromSeconds(20);
            xAnimation.Source = PathAnimationSource.X;
            Storyboard.SetTarget(xAnimation, myCar);
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            DoubleAnimationUsingPath yAnimation = new DoubleAnimationUsingPath();
            yAnimation.PathGeometry = pathGeometry;           
            yAnimation.Duration = TimeSpan.FromSeconds(20);
            yAnimation.Source = PathAnimationSource.Y;
            Storyboard.SetTarget(yAnimation, myCar);
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
            animationExecute.Children.Add(xAnimation);
            animationExecute.Children.Add(yAnimation);
            animationExecute.Begin(myCar,true);        
        }
        /// <summary>
        /// Road select fountion.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private PathGeometry RoadSelect(Point start,Point target)
        {
            IList<PathSegment> segments = new List<PathSegment>();
            ArcSegment leftUp = new ArcSegment(new Point(100,160),new Size(60,60),45,false,SweepDirection.Counterclockwise,false);
            ArcSegment leftDown = new ArcSegment(new Point(160,400),new Size(60,60),45,false,SweepDirection.Counterclockwise,false);
            ArcSegment rightDown = new ArcSegment(new Point(1600,340),new Size(60,60),45,false,SweepDirection.Counterclockwise,false);
            ArcSegment rightUp = new ArcSegment(new Point(1540,100),new Size(60,60),45,false,SweepDirection.Counterclockwise,false);
            if (target.Y == 100)
            {
                if (target.X < start.X)
                {
                    LineSegment lineSegment = new LineSegment(target, false);
                    segments.Add(lineSegment);
                }
                else 
                {
                    LineSegment lineSegment10 = new LineSegment(new Point(160, 100), false);
                    LineSegment lineSegment11 = new LineSegment(new Point(100, 340), false);
                    LineSegment lineSegment12 = new LineSegment(new Point(1540, 400), false);
                    LineSegment lineSegment13 = new LineSegment(new Point(1600, 160), false);
                    LineSegment lineSegment14 = new LineSegment(new Point(target.X,100),false);
                    segments.Add(lineSegment10);
                    segments.Add(leftUp);
                    segments.Add(lineSegment11);
                    segments.Add(leftDown);
                    segments.Add(lineSegment12);
                    segments.Add(rightDown);
                    segments.Add(lineSegment13);
                    segments.Add(rightUp);
                    segments.Add(lineSegment14);
                }
                
            }
            if (target.X == 170)
            {
                LineSegment linSegment1 = new LineSegment(new Point(160,100),false);
                LineSegment lineSegement2 = new LineSegment(new Point(100,target.Y),false);
                segments.Add(linSegment1);
                segments.Add(leftUp);
                segments.Add(lineSegement2);
            }
            if (target.Y == 320)
            {
                LineSegment lineSegment3 = new LineSegment(new Point(160,100),false);
                LineSegment lineSegment4 = new LineSegment(new Point(100,340),false);
                LineSegment lineSegment5 = new LineSegment(new Point(target.X -60, 400), false);
                segments.Add(lineSegment3);
                segments.Add(leftUp);
                segments.Add(lineSegment4);
                segments.Add(leftDown);
                segments.Add(lineSegment5);
            }
            if (target.X == 1590)
            {
                LineSegment lineSegment6 = new LineSegment(new Point(160,100),false);
                LineSegment lineSegment7 = new LineSegment(new Point(100,340),false);
                LineSegment lineSegment8 = new LineSegment(new Point(1540,400),false);
                LineSegment lineSegment9 = new LineSegment(new Point(1600,target.Y+80),false);
                segments.Add(lineSegment6);
                segments.Add(leftUp);
                segments.Add(lineSegment7);
                segments.Add(leftDown);
                segments.Add(lineSegment8);
                segments.Add(rightDown);
                segments.Add(lineSegment9);
            }
            PathFigure pathFigure = new PathFigure(start,segments,false);
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);
            return pathGeometry;
        }

        private void PauseCommand_Click(object sender, RoutedEventArgs e)
        {
            if (myCar == null)
            {
                return;
            }
            animationExecute.Pause(myCar);
            myCar.Background = Brushes.Yellow;
        }

        private void ResumeCommand_Click(object sender, RoutedEventArgs e)
        {
            if (myCar == null)
            {
                return;
            }
            animationExecute.Resume(myCar);
        }

        private void StopCommand_Click(object sender, RoutedEventArgs e)
        {
            if (myCar == null)
            {
                return;
            }
            animationExecute.Stop(myCar);
        }
    }
}
