using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TimeNow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string SPOTIFY_PROCESS_NAME = "Spotify";

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_OnLoaded;

            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.CanResizeWithGrip;
            this.MouseWheel += OnMouseWheel;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TimeManager.OnUpdated += OnUpdate;
            TimeManager.Initialize();
        }

        private void OnUpdate(object sender, TimeInfo info)
        {
            xTime.Content = info.Time;
            xAPM.Content = info.APM;
            xDate.Content = info.Date;
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                xMainScaleTransform.ScaleX *= 1.1;
                xMainScaleTransform.ScaleY *= 1.1;
            }
            else
            {
                xMainScaleTransform.ScaleX /= 1.1;
                xMainScaleTransform.ScaleY /= 1.1;
            }
        }

        private void xSpotify_Click(object sender, MouseEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName(SPOTIFY_PROCESS_NAME);
            IntPtr spotify = IntPtr.Zero;

            foreach (var process in processes)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    spotify = process.MainWindowHandle;
                    break;
                }
            }

            if (spotify != IntPtr.Zero)
            {
                Win32.SwitchToThisWindow(spotify, true);
            }
        }

        private void xTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

            if (e.OriginalSource is Image x)
            {
                switch (x.Name)
                {
                    case "xMinimize":
                        xMinimize_Click(sender, e);
                        break;

                    case "xMaximize":
                        xMaximize_Click(sender, e);
                        break;

                    case "xClose":
                        xClose_Click(sender, e);
                        break;
                }
            }
        }

        private void xMinimize_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
            {
                return;
            }

            this.WindowState = WindowState.Minimized;
        }

        private void xMaximize_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
            {
                return;
            }

            switch (this.WindowState)
            {
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;

                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;

                default:
                    break;
            }
        }

        private void xClose_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
            {
                return;
            }

            Application.Current.Shutdown();
        }
    }
}
