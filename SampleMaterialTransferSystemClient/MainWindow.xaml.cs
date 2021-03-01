
using DataStore;
using SampleMaterialTransferSystemLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SampleMaterialTransferSystemClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static TransmitCommand transmitCommand = null;
        public static IList<CommonStationControl> myStationStore = new List<CommonStationControl>();
        public static IList<CommonCarControl> myCarStore = new List<CommonCarControl>();
        public static IList<string> railStore = new List<string>();
        public static IList<int> priorityStore = new List<int>();
        public static Canvas myCanvasStore;
        private Storyboard animationExecute = new Storyboard();
        private CommonCarControl myCar = null;
        private PathGeometry carPathGeometry = new PathGeometry();
        public int carCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            myCanvasStore = myCanvas;
            InitializeRail();
            InitializePriority();
            RailSelect.DataContext = railStore;
            PrioritySelect.DataContext = priorityStore;
            using (var commandContext = new DataStoreContext())
            {
                commandContext.TransmitCommands.Load();
                CommandTable.DataContext = commandContext.TransmitCommands.Local;
            }
        }

        private void InitializePriority()
        {
            for (int i = 1; i < 10; i++)
            {
                railStore.Add("Rail" + i.ToString());
            }

        }

        private void InitializeRail()
        {
            int[] priority = new int[] { 30, 60, 90, 9999 };
            for (int i = 0; i < 4; i++)
            {
                priorityStore.Add(priority[i]);
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            myCanvas.Children.Clear();
            /*
            Rect rect = new Rect(100,100,1500,300);
            RectangleGeometry rectangel = new RectangleGeometry(rect, 60, 60);
            Path path = new Path();  
            path.StrokeThickness = 1;
            path.Stroke = Brushes.Black;
            path.Data = rectangel;
            myCanvas.Children.Add(path);
            */
            IList<PathSegment> segments = new List<PathSegment>();
            LineSegment lineSegment = new LineSegment(new Point(160, 100), true);
            ArcSegment arcSegment = new ArcSegment(new Point(100, 160), new Size(60, 60), 45, false, SweepDirection.Counterclockwise, true);
            LineSegment lineSegment1 = new LineSegment(new Point(100, 340), true);
            ArcSegment arcSegment1 = new ArcSegment(new Point(160, 400), new Size(60, 60), 45, false, SweepDirection.Counterclockwise, true);
            LineSegment lineSegment2 = new LineSegment(new Point(1540, 400), true);
            ArcSegment arcSegment2 = new ArcSegment(new Point(1600, 340), new Size(60, 60), 45, false, SweepDirection.Counterclockwise, true);
            LineSegment lineSegment3 = new LineSegment(new Point(1600, 160), true);
            ArcSegment arcSegment3 = new ArcSegment(new Point(1540, 100), new Size(60, 60), 45, false, SweepDirection.Counterclockwise, true);
            segments.Add(lineSegment);
            segments.Add(arcSegment);
            segments.Add(lineSegment1);
            segments.Add(arcSegment1);
            segments.Add(lineSegment2);
            segments.Add(arcSegment2);
            segments.Add(lineSegment3);
            segments.Add(arcSegment3);
            PathFigure pathFigure = new PathFigure(new Point(1540, 100), segments, true);
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);
            Path path = new Path();
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 2;
            path.Data = pathGeometry;
            myCanvas.Children.Add(path);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
            Path path = new Path();
            path.StrokeThickness = 1;
            path.Stroke = Brushes.Black;
            LineSegment lineSegment = new LineSegment(new Point(100, 80), true);
            ArcSegment arcSemgment = new ArcSegment();
            arcSemgment.Point = new Point(140, 40);
            arcSemgment.Size = new Size(40, 40);
            arcSemgment.RotationAngle = 45;
            arcSemgment.SweepDirection = SweepDirection.Clockwise;
            arcSemgment.IsLargeArc = false;
            LineSegment lineSegment1 = new LineSegment(new Point(300, 40), true);
            ArcSegment arcSegment1 = new ArcSegment();
            arcSegment1.Point = new Point(340, 80);
            arcSegment1.Size = new Size(40, 40);
            arcSegment1.RotationAngle = 45;
            arcSegment1.SweepDirection = SweepDirection.Clockwise;
            arcSegment1.IsLargeArc = false;
            LineSegment lineSegment2 = new LineSegment(new Point(340, 200), true);
            ArcSegment arcSegement2 = new ArcSegment();
            arcSegement2.Point = new Point(380, 240);
            arcSegement2.Size = new Size(40, 40);
            arcSegement2.RotationAngle = 45;
            arcSegement2.SweepDirection = SweepDirection.Counterclockwise;
            arcSegement2.IsLargeArc = false;
            LineSegment lineSegment4 = new LineSegment(new Point(1380, 240), true);
            ArcSegment arcSegment3 = new ArcSegment(new Point(1420, 280), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            LineSegment lineSegment5 = new LineSegment(new Point(1420, 420), true);
            ArcSegment arcSegment4 = new ArcSegment(new Point(1380, 460), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            LineSegment lineSegment6 = new LineSegment(new Point(380, 460), true);
            ArcSegment arcSegment5 = new ArcSegment(new Point(340, 500), new Size(40, 40), 45, false, SweepDirection.Counterclockwise, true);
            LineSegment lineSegment7 = new LineSegment(new Point(340, 620), true);
            ArcSegment arcSegment6 = new ArcSegment(new Point(300, 660), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            LineSegment lineSegment8 = new LineSegment(new Point(140, 660), true);
            ArcSegment arcSegment7 = new ArcSegment(new Point(100, 620), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(100, 620);
            pathFigure.Segments.Add(lineSegment);
            pathFigure.Segments.Add(arcSemgment);
            pathFigure.Segments.Add(lineSegment1);
            pathFigure.Segments.Add(arcSegment1);
            pathFigure.Segments.Add(lineSegment2);
            pathFigure.Segments.Add(arcSegement2);
            pathFigure.Segments.Add(lineSegment4);
            pathFigure.Segments.Add(arcSegment3);
            pathFigure.Segments.Add(lineSegment5);
            pathFigure.Segments.Add(arcSegment4);
            pathFigure.Segments.Add(lineSegment6);
            pathFigure.Segments.Add(arcSegment5);
            pathFigure.Segments.Add(lineSegment7);
            pathFigure.Segments.Add(arcSegment6);
            pathFigure.Segments.Add(lineSegment8);
            pathFigure.Segments.Add(arcSegment7);
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;
            myCanvas.Children.Add(path);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //IEnumerable<PathSegment> segments = new List<PathSegment>();
            myCanvas.Children.Clear();
            IList<PathSegment> segments = new List<PathSegment>();
            LineSegment lineSegment = new LineSegment(new Point(100, 100), true);
            ArcSegment arcSegment = new ArcSegment(new Point(140, 60), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            LineSegment lineSegment1 = new LineSegment(new Point(1440, 60), true);
            ArcSegment arcSegment1 = new ArcSegment(new Point(1480, 100), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            LineSegment lineSegment2 = new LineSegment(new Point(1480, 300), true);
            ArcSegment arcSegment2 = new ArcSegment(new Point(1440, 340), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            LineSegment lineSegment3 = new LineSegment(new Point(340, 340), true);
            ArcSegment arcSegment3 = new ArcSegment(new Point(300, 380), new Size(40, 40), 45, false, SweepDirection.Counterclockwise, true);
            LineSegment lineSegment4 = new LineSegment(new Point(300, 600), true);
            ArcSegment arcSegment4 = new ArcSegment(new Point(260, 640), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            LineSegment lineSegment5 = new LineSegment(new Point(140, 640), true);
            ArcSegment arcSegment5 = new ArcSegment(new Point(100, 600), new Size(40, 40), 45, false, SweepDirection.Clockwise, true);
            segments.Add(lineSegment);
            segments.Add(arcSegment);
            segments.Add(lineSegment1);
            segments.Add(arcSegment1);
            segments.Add(lineSegment2);
            segments.Add(arcSegment2);
            segments.Add(lineSegment3);
            segments.Add(arcSegment3);
            segments.Add(lineSegment4);
            segments.Add(arcSegment4);
            segments.Add(lineSegment5);
            segments.Add(arcSegment5);
            PathFigure pathFigure = new PathFigure(new Point(100, 600), segments, true);
            //pathFigure.StartPoint = new Point(100,600);
            //pathFigure.Segments.Add(lineSegment);
            //pathFigure.Segments.Add(arcSegment);
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(pathFigure);
            Path path = new Path();
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 1;
            path.Data = pathGeometry;
            myCanvas.Children.Add(path);

        }

        private void StationBuildMenu_Click(object sender, RoutedEventArgs e)
        {
            int count = 100;
            IList<CommonStationControl> myCSCList = new List<CommonStationControl>();
            for (int i = 0; i < count; i++)
            {
                myCSCList.Add(new CommonStationControl());
            }
            myCSCList[0].Margin = new Thickness(240, 140, 0, 0);
            myCSCList[1].Margin = new Thickness(310, 140, 0, 0);
            myCSCList[2].Margin = new Thickness(380, 140, 0, 0);
            myCSCList[3].Margin = new Thickness(450, 140, 0, 0);
            myCSCList[4].Margin = new Thickness(520, 140, 0, 0);
            myCSCList[5].Margin = new Thickness(980, 140, 0, 0);
            myCSCList[6].Margin = new Thickness(1050, 140, 0, 0);
            myCSCList[7].Margin = new Thickness(1120, 140, 0, 0);
            myCSCList[8].Margin = new Thickness(1190, 140, 0, 0);
            myCSCList[9].Margin = new Thickness(1260, 140, 0, 0);
            myCSCList[10].Margin = new Thickness(1380, 140, 0, 0);
            myCSCList[11].Margin = new Thickness(1450, 140, 0, 0);
            myCSCList[12].Margin = new Thickness(1560, 240, 0, 0);
            myCSCList[12].RenderTransform = new RotateTransform(90);
            myCSCList[13].Margin = new Thickness(1440, 360, 0, 0);
            myCSCList[13].RenderTransform = new RotateTransform(180);
            myCSCList[23].Margin = new Thickness(300, 360, 0, 0);
            myCSCList[23].RenderTransform = new RotateTransform(180);
            myCSCList[22].Margin = new Thickness(370, 360, 0, 0);
            myCSCList[22].RenderTransform = new RotateTransform(180);
            myCSCList[21].Margin = new Thickness(440, 360, 0, 0);
            myCSCList[21].RenderTransform = new RotateTransform(180);
            myCSCList[20].Margin = new Thickness(510, 360, 0, 0);
            myCSCList[20].RenderTransform = new RotateTransform(180);
            myCSCList[19].Margin = new Thickness(580, 360, 0, 0);
            myCSCList[19].RenderTransform = new RotateTransform(180);
            myCSCList[18].Margin = new Thickness(1040, 360, 0, 0);
            myCSCList[18].RenderTransform = new RotateTransform(180);
            myCSCList[17].Margin = new Thickness(1110, 360, 0, 0);
            myCSCList[17].RenderTransform = new RotateTransform(180);
            myCSCList[16].Margin = new Thickness(1180, 360, 0, 0);
            myCSCList[16].RenderTransform = new RotateTransform(180);
            myCSCList[15].Margin = new Thickness(1250, 360, 0, 0);
            myCSCList[15].RenderTransform = new RotateTransform(180);
            myCSCList[14].Margin = new Thickness(1320, 360, 0, 0);
            myCSCList[14].RenderTransform = new RotateTransform(180);
            myCSCList[24].Margin = new Thickness(140, 280, 0, 0);
            myCSCList[24].RenderTransform = new RotateTransform(270);
            //RotateTransform rt = new RotateTransform(60);
            for (int i = 0; i < count; i++)
            {
                //myCSCList[i].SetValue(StationText,$"{i}");
                myCSCList[i].StationText = $"{i}";
                myCSCList[i].Background = Brushes.White;
                myCanvas.Children.Add(myCSCList[i]);
            }
            myStationStore = myCSCList;
            foreach (CommonStationControl csc in myCSCList)
            {
                StartSelect.Items.Add("Station" + csc.StationText);
                TargetSelect.Items.Add("Station" + csc.StationText);
            }
        }
        private void CarBuildMenu_Click(object sender, RoutedEventArgs e)
        {

            int count = 10;
            IList<CommonCarControl> carList = new List<CommonCarControl>();
            for (int i = 0; i < count; i++)
            {
                carList.Add(new CommonCarControl());
            }
            // CommonCarControl car = new CommonCarControl();
            carList[0].CarText = "Car0";
            Canvas.SetTop(carList[0], -20);
            Canvas.SetLeft(carList[0], -30);
            carList[0] = carList[0];
            myCanvas.Children.Add(carList[0]);
            myCarStore = carList;
            foreach (CommonCarControl ccc in carList)
            {
                CarSelect.Items.Add(ccc.CarText);
            }
            //CarAdd();
        }
        private void CommondTest_Click(object sender, RoutedEventArgs e)
        {
            /*
            IList<PathSegment> segments = new List<PathSegment>();
            PathGeometry pathGeometry = new PathGeometry();
            LineSegment lineSegment = new LineSegment(new Point(140,100),true);
            ArcSegment arcSegment = new ArcSegment(new Point(100,140),new Size(40,40),45,false,SweepDirection.Counterclockwise,true);
            LineSegment lineSegment1 = new LineSegment(new Point(100,600),true);
            segments.Add(lineSegment);
            segments.Add(arcSegment);
            segments.Add(lineSegment1);
            PathFigure pathFigure = new PathFigure(new Point(800,100),segments,true);
            pathGeometry.Figures.Add(pathFigure);
            Path path = new Path();
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 2;
            path.Data = pathGeometry;
            myCanvas.Children.Add(path);
            */
            // Button button = new Button();
            // button.Visibility = Visibility.Visible;
            // button.Height = 20;
            // button.Width = 100;
            // myCanvas.Children.Add(button);

            PathGeometry pathGeometry = new PathGeometry();
            //CommonCarControl myCar = null;
            Path path = new Path();
            if (myCanvas.Children.Count == 0)
            {
                MessageBox.Show("Canvas is not elemnt,Please add rail and car!!!!");
                return;
            }
            foreach (UIElement pg in myCanvas.Children)
            {

                if (pg is Path)
                {
                    path = pg as Path;
                    pathGeometry = path.Data as PathGeometry;
                }
                if (pg is CommonCarControl)
                {
                    myCar = pg as CommonCarControl;
                }
            }
            //Canvas.GetLeft(myCar);
            TranslateTransform translate = new TranslateTransform();
            myCar.RenderTransform = translate;
            //this.RegisterName("XYTranslate",translate);
            DoubleAnimationUsingPath xAnimation = new DoubleAnimationUsingPath();
            xAnimation.PathGeometry = pathGeometry;
            xAnimation.Duration = TimeSpan.FromSeconds(40);
            xAnimation.Source = PathAnimationSource.X;
            Storyboard.SetTarget(xAnimation, myCar);
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            DoubleAnimationUsingPath yAnimation = new DoubleAnimationUsingPath();
            yAnimation.PathGeometry = pathGeometry;
            yAnimation.Duration = TimeSpan.FromSeconds(40);
            yAnimation.Source = PathAnimationSource.Y;
            Storyboard.SetTarget(yAnimation, myCar);
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
            //Storyboard animationExecute = new Storyboard();
            animationExecute.RepeatBehavior = RepeatBehavior.Forever;
            animationExecute.Children.Add(xAnimation);
            animationExecute.Children.Add(yAnimation);
            animationExecute.Begin(myCar, true);
            // myCar.TopDistance = Canvas.GetTop(myCar);
            //myCar.LeftDistance = Canvas.GetLeft(myCar);
        }

        private void CreatCommandWindow_Click(object sender, RoutedEventArgs e)
        {
            CommandCreateWindow dt = new CommandCreateWindow();
            dt.ShowActivated = true;
            dt.ShowInTaskbar = true;
            dt.ShowDialog();
            //new CommandCreateWindow().Show();
        }
        private void CarAdd()
        {
            /*int count = carCount;
            IList<CommonCarControl> carlist = new List<CommonCarControl>();
            CommonCarControl car = new CommonCarControl();
            Canvas.SetTop(car, -20);
            Canvas.SetLeft(car, -30);
            car.CarText = $"Car+{myCarStore.Count}";
           // carCount += 1;
            myCarStore.Add(car);
            
            myCanvas.Children.Add(car);
            myCarStore = carlist;
            // myCarStore;
            /*
           for(int i = 0; i < myCarStore.Count; i++)
            {
                myCanvas.Children.Add(myCarStore[i]);

            }
            */
        }

        private void PauseCommand_Click(object sender, RoutedEventArgs e)
        {
            if (myCar == null)
            {
                return;
            }
            animationExecute.Pause(myCar);
            myCar.InnerBorderBC = "Yellow";
        }

        private void ResumeCommand_Click(object sender, RoutedEventArgs e)
        {
            if (myCar == null)
            {
                return;
            }
            myCar.Background = Brushes.White;
            animationExecute.Resume(myCar);
            myCar.InnerBorderBC = "Green";
        }

        private void AddCommand_Click(object sender, RoutedEventArgs e)
        {
            if (StartSelect.Text == string.Empty || TargetSelect.Text == string.Empty || CarSelect.Text == string.Empty || RailSelect.Text == string.Empty || PrioritySelect.Text == string.Empty)
            {
                MessageBox.Show("Please select start station!!!");
                return;
            }
            string carID = CarSelect.Text.Trim();
            string railID = RailSelect.Text.Trim();
            string spa = StartSelect.Text.Trim();
            string sla = null;
            string tpa = TargetSelect.Text.Trim();
            string tla = null;
            int priority;
            Int32.TryParse(PrioritySelect.Text.Trim(), out priority);
            foreach (CommonStationControl csc in myStationStore)
            {
                if (csc == null)
                {
                    MessageBox.Show("Please select 0~~24 Station!!!");
                    return;
                }
                if (csc.StationText == StartSelect.Text.Substring(7).Trim())
                {
                    sla = csc.Margin.Left.ToString() + "," + csc.Margin.Top.ToString();
                }

            }

            foreach (CommonStationControl csc in myStationStore)
            {
                if (csc == null)
                {
                    MessageBox.Show("Please select 0~~24 Station!!!");
                    return;
                }
                if (csc.StationText == TargetSelect.Text.Substring(7).Trim())
                {
                    tla = csc.Margin.Left.ToString() + "," + csc.Margin.Top.ToString();
                }

            }
            using (var commandContext = new DataStoreContext())
            {
                commandContext.TransmitCommands.Load();
                commandContext.TransmitCommands.Add(new TransmitCommand
                {
                    Number = Guid.NewGuid().ToString(),
                    CarID = carID,
                    RailID = railID,
                    StartPhysicalAddress = spa,
                    StartLogicalAddress = sla,
                    TargetPhysicalAddress = tpa,
                    TargetLogicalAddress = tla,
                    Priority = priority,
                    CreateTime = DateTime.Now,
                    CompleteTime = DateTime.Now,
                    IsComplete = false
                });
                commandContext.SaveChanges();
                CommandTable.DataContext = commandContext.TransmitCommands.Local;
            }
        }

        private void DeleteCommand_Click(object sender, RoutedEventArgs e)
        {
            if (CommandTable.SelectedItem == null)
            {
                return;
            }
            TransmitCommand tc = new TransmitCommand();
            tc = CommandTable.SelectedItem as TransmitCommand;
            if (tc == null)
            {
                return;
            }
            int temp = tc.ID;
            Test.Text = temp.ToString();
            using (var commandContext = new DataStoreContext())
            {
                commandContext.TransmitCommands.Load();
                var tempContext = commandContext.TransmitCommands.Local;
                tempContext.Remove(commandContext.TransmitCommands.Find(temp));
                commandContext.SaveChanges();
                CommandTable.DataContext = commandContext.TransmitCommands.Local;
            }
        }

        private void StartSelect_Click(object sender, EventArgs e)
        {

        }

        private void RailSelet_Click(object sender, EventArgs e)
        {

        }

        private void TargetSelect_Click(object sender, EventArgs e)
        {

        }

        private void CarSelect_Click(object sender, EventArgs e)
        {

        }

        private void PrioritySelect_Click(object sender, EventArgs e)
        {

        }

        private void AutoCommand_Click(object sender, RoutedEventArgs e)
        {
            int si, sx, sy, ti, tx, ty;
            SearchCommand(out si,out sx,out sy,out ti,out tx,out ty);
            Test.Text = string.Empty;
            Test.Text = si.ToString() + "," + sx.ToString() + "," + sy.ToString() + ":" + ti.ToString() + "," + tx.ToString() + "," + ty.ToString();
            if (!SearchRailAndCar())
            {
                return;
            }
            myCar.CarAnimation(carPathGeometry);
            myCar.executeAnimation.Begin(myCar, true);
            myCar.InnerBorderBC = "Green";
            //Thread tr = new Thread(CompareNumber(x,y);
        }
        private bool SearchRailAndCar()
        {

            Path path = new Path();
            if (myCanvas.Children.Count == 0)
            {
                MessageBox.Show("Please add Rail and Car !!!!");
                return false;
            }
            foreach (UIElement elemnt in myCanvas.Children)
            {
                if (elemnt is Path)
                {
                    path = elemnt as Path;
                    carPathGeometry = path.Data as PathGeometry;
                }
                if (elemnt is CommonCarControl)
                {
                    myCar = elemnt as CommonCarControl;
                }
            }
            return true;
        }
        private bool SearchCommand(out int startIndex, out int sxDistance, out int syDistantce, out int targetIndex, out int txDistance, out int tyDistance)
        {
            int si = 0;
            int sx = 0;
            int sy = 0;
            int ti = 0;
            int tx = 0;
            int ty = 0;
            using (var commandContext = new DataStoreContext())
            {
                commandContext.TransmitCommands.Load();
                var tempContext = commandContext.TransmitCommands.Local;
                foreach (TransmitCommand tc in tempContext)
                {
                    if (tc.Priority == 9999)
                    {
                        Int32.TryParse(tc.StartPhysicalAddress.Substring(7), out si);
                        int sIndex = tc.StartLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.StartLogicalAddress.Substring(0, sIndex), out sx);
                        Int32.TryParse(tc.StartLogicalAddress.Substring(sIndex + 1), out sy);
                        Int32.TryParse(tc.TargetPhysicalAddress.Substring(7), out ti);
                        int tIndex = tc.TargetLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(0, tIndex), out tx);
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(tIndex + 1), out ty);
                        startIndex = si;
                        sxDistance = sx;
                        syDistantce = sy;
                        targetIndex = ti;
                        txDistance = tx;
                        tyDistance = ty;
                        return true;
                    }
                }
                foreach (TransmitCommand tc in tempContext)
                {
                    if (tc.Priority == 90)
                    {
                        Int32.TryParse(tc.StartPhysicalAddress.Substring(7), out si);
                        int sIndex = tc.StartLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.StartLogicalAddress.Substring(0, sIndex), out sx);
                        Int32.TryParse(tc.StartLogicalAddress.Substring(sIndex + 1), out sy);
                        Int32.TryParse(tc.TargetPhysicalAddress.Substring(7), out ti);
                        int tIndex = tc.TargetLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(0, tIndex), out tx);
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(tIndex + 1), out ty);
                        startIndex = si;
                        sxDistance = sx;
                        syDistantce = sy;
                        targetIndex = ti;
                        txDistance = tx;
                        tyDistance = ty;
                        return true;
                    }
                }
                foreach (TransmitCommand tc in tempContext)
                {
                    if (tc.Priority == 60)
                    {
                        Int32.TryParse(tc.StartPhysicalAddress.Substring(7), out si);
                        int sIndex = tc.StartLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.StartLogicalAddress.Substring(0, sIndex), out sx);
                        Int32.TryParse(tc.StartLogicalAddress.Substring(sIndex + 1), out sy);
                        Int32.TryParse(tc.TargetPhysicalAddress.Substring(7), out ti);
                        int tIndex = tc.TargetLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(0, tIndex), out tx);
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(tIndex + 1), out ty);
                        startIndex = si;
                        sxDistance = sx;
                        syDistantce = sy;
                        targetIndex = ti;
                        txDistance = tx;
                        tyDistance = ty;
                        return true;
                    }
                }
                foreach (TransmitCommand tc in tempContext)
                {
                    if (tc.Priority == 30)
                    {
                        Int32.TryParse(tc.StartPhysicalAddress.Substring(7), out si);
                        int sIndex = tc.StartLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.StartLogicalAddress.Substring(0, sIndex), out sx);
                        Int32.TryParse(tc.StartLogicalAddress.Substring(sIndex + 1), out sy);
                        Int32.TryParse(tc.TargetPhysicalAddress.Substring(7), out ti);
                        int tIndex = tc.TargetLogicalAddress.IndexOf(",");
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(0, tIndex), out tx);
                        Int32.TryParse(tc.TargetLogicalAddress.Substring(tIndex + 1), out ty);
                        startIndex = si;
                        sxDistance = sx;
                        syDistantce = sy;
                        targetIndex = ti;
                        txDistance = tx;
                        tyDistance = ty;
                        return true;
                    }
                }
                startIndex = si;
                sxDistance = sx;
                syDistantce = sy;
                targetIndex = ti;
                txDistance = tx;
                tyDistance = ty;  
                MessageBox.Show("There are not command to execute!!!!");
                return false;
            }   
        }
      
    }
}
