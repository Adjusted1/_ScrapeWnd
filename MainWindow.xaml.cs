using scape;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Runtime.InteropServices;



namespace scrape
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    
    public class WindowHandle: IWindowHandle
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public string handle { get; set; } = null;

        public void GetHandle(string wndTitle)
        {
            handle = "0x12aaaa";
            IntPtr hWnd = FindWindow(null, wndTitle);
            handle = hWnd.ToString();
        }
    }
    public partial class MainWindow : Window
    {
        public string WndHndl
        {
            get { return (string)GetValue(thisWindowProperty); }
            set { SetValue(thisWindowProperty, value); }
        }
        public static readonly DependencyProperty thisWindowProperty =
            DependencyProperty.Register("thisWindow", typeof(string),
            typeof(MainWindow), new PropertyMetadata(Guid.NewGuid().ToString())
        );
        public MainWindow()
        {
            InitializeComponent();
            wndhndlTxtBox.DataContext = this;
            WindowHandle wh = new WindowHandle();
            wh.GetHandle(@"(A) TELNET (Insyst) - PowerTerm Interconnect/32");
            wndhndlTxtBox.Text = wh.handle;
            
        }
    }
}
