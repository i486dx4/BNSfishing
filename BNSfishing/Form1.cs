using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BNSfishing {
    public partial class Form1 : Form {
        private bool looping = false;
        private Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        private Point samplePoint = new Point(0, 0);
        private Random rnd = new Random();
        private IntPtr windowPointer;

        public Form1() {
            InitializeComponent();
            statusLabel.Text = "done.";
        }

        private IntPtr findProcess() {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection) {
                try {
                    if (p.ProcessName == this.processTextBox.Text) {
                        return EnumerateProcessWindowHandles(p.Id).First();
                    }
                } catch (Exception) {
                }
            }
            return IntPtr.Zero;
        }

        private void startButton_Click(object sender, EventArgs e) {
            startButton.Enabled = false;
            stopButton.Enabled = true;

            // fishingBackgroundWorker.RunWorkerAsync(2000);
            Start();
        }

        private void Start() {
            looping = true;
            this.windowPointer = findProcess();

            /*
            for (int i = 0; (i < 60) && (zero == IntPtr.Zero); i++)
            {
                Thread.Sleep(50);
                zero = FindWindow(null, this.processTextBox.Text);
            }
            */
            if (this.windowPointer != IntPtr.Zero) {
                statusTextBox.Text = "Found";

                int x = Int32.Parse(xTextBox.Text);
                int y = Int32.Parse(yTextBox.Text);

                var c = GetColorAt(this.windowPointer, x, y);

                statusLabel.Text = "color: " + c.ToArgb();

                // SetForegroundWindow(this.windowPointer);
                Thread.Sleep(500);

                samplePoint = new Point(x,y);

                // var color = GetColorAt(zero, Int32.Parse(xTextBox.Text), Int32.Parse(ytextBox.Text));
                var color = GetPixel(samplePoint);
                // currentColor = color.ToArgb();
                fishingBackgroundWorker.RunWorkerAsync(2000);
                /*
                while (looping)
                {
                    SendKeys.SendWait("{5}");
                    Thread.Sleep(20000);
                    SendKeys.SendWait("{f}");
                    Thread.Sleep(1000);
                }
                */
                /*
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{ENTER}");
                SendKeys.Flush();
                */
            } else {
                statusTextBox.Text = "NOT Found";
                startButton.Enabled = true;
                stopButton.Enabled = false;
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        //[DllImport("user32.dll")]
        //public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        //[DllImport("user32.dll")]
        //public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn,
            IntPtr lParam);

        //[DllImport("user32.dll")]
        //static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);


        static IEnumerable<IntPtr> EnumerateProcessWindowHandles(int processId) {
            var handles = new List<IntPtr>();

            foreach (ProcessThread thread in Process.GetProcessById(processId).Threads)
                EnumThreadWindows(thread.Id,
                    (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);

            return handles;
        }


        /*
        public static Bitmap PrintWindow(IntPtr hwnd)
        {
            RECT rc;
            GetWindowRect(hwnd, out rc);


            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }
        */

        private void stopButton_Click(object sender, EventArgs e) {
            looping = false;
            stopButton.Enabled = false;
            if (!fishingBackgroundWorker.IsBusy) {
                fishingBackgroundWorker.CancelAsync();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            statusLabel.Text = "Index: " + predefinedComboBox.SelectedIndex + ", value: " + predefinedComboBox.Text;

            var list = predefinedComboBox.Text.Split(",").ToList();

            xTextBox.Text = list[0].Trim();
            yTextBox.Text = list[1].Trim();

        }

        private void fishingBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            const int WM_SYSKEYDOWN = 0x0104;
            // const int WM_KEYDOWN = 0x0100;
            // const int WM_SYSKEYUP = 0x;
            const int VK_KEY_5 = 0x35;
            const int VK_KEY_F = 0x46;

            int color1, color2;
            int counter = 0;

            var windowMode = windowCheckBox.Checked;

            Thread.Sleep(1500);

            while (looping && counter < 1500) {
                // SendKeys.SendWait("{5}");
                PostMessage(this.windowPointer, WM_SYSKEYDOWN, VK_KEY_5, 0);

                Thread.Sleep(2000);

                color1 = windowMode ?
                    GetColorAt(this.windowPointer, samplePoint.X, samplePoint.Y).ToArgb() :
                    GetPixel(samplePoint).ToArgb();

                do {
                    Thread.Sleep(500);
                    color2 = windowMode ?
                        GetColorAt(this.windowPointer, samplePoint.X, samplePoint.Y).ToArgb() :
                        GetPixel(samplePoint).ToArgb();
                } while (color1 == color2);
                Thread.Sleep(100);
                //SendKeys.SendWait("{f}");
                counter++;
                PostMessage(this.windowPointer, WM_SYSKEYDOWN, VK_KEY_F, 0);
                statusLabel.Text = "Counter: " + counter + ",  from: " + color1 + " to " + color2;
                Thread.Sleep(rnd.Next(50, 300) + rnd.Next(50, 4500));
            }
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void fishingBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        //private void MouseMoveTimer_Tick(object sender, EventArgs e) {
        //    /*
        //    Point cursor = new Point();
        //    GetCursorPos(ref cursor);

        //    var c = GetColorAt(cursor);
        //    this.BackColor = c;

        //    if (c.R == c.G && c.G < 64 && c.B > 128)
        //    {
        //        MessageBox.Show("Blue");
        //    }
        //    */
        //}

        private Color GetPixel(Point position) {
            using (var bitmap = new Bitmap(1, 1)) {
                using (var graphics = Graphics.FromImage(bitmap)) {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }

        public Color GetColorAt(IntPtr hwnd, int x, int y) {
            // statusLabel.Text = "Retrieve color at " + x + " ,  " + y;

            using (Graphics gdest = Graphics.FromImage(screenPixel)) {
                using (Graphics gsrc = Graphics.FromHwnd(hwnd)) {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, x, y, (int)CopyPixelOperation.SourceCopy);


                    // statusLabel.Text = "Return value: " + retval;
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }
    }
/*

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT {
        private int _Left;
        private int _Top;
        private int _Right;
        private int _Bottom;

        public RECT(RECT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom) {
        }
        public RECT(int Left, int Top, int Right, int Bottom) {
            _Left = Left;
            _Top = Top;
            _Right = Right;
            _Bottom = Bottom;
        }

        public int X {
            get { return _Left; }
            set { _Left = value; }
        }
        public int Y {
            get { return _Top; }
            set { _Top = value; }
        }
        public int Left {
            get { return _Left; }
            set { _Left = value; }
        }
        public int Top {
            get { return _Top; }
            set { _Top = value; }
        }
        public int Right {
            get { return _Right; }
            set { _Right = value; }
        }
        public int Bottom {
            get { return _Bottom; }
            set { _Bottom = value; }
        }
        public int Height {
            get { return _Bottom - _Top; }
            set { _Bottom = value + _Top; }
        }
        public int Width {
            get { return _Right - _Left; }
            set { _Right = value + _Left; }
        }
        public Point Location {
            get { return new Point(Left, Top); }
            set {
                _Left = value.X;
                _Top = value.Y;
            }
        }
        public Size Size {
            get { return new Size(Width, Height); }
            set {
                _Right = value.Width + _Left;
                _Bottom = value.Height + _Top;
            }
        }

        public static implicit operator Rectangle(RECT Rectangle) {
            return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
        }
        public static implicit operator RECT(Rectangle Rectangle) {
            return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
        }
        public static bool operator ==(RECT Rectangle1, RECT Rectangle2) {
            return Rectangle1.Equals(Rectangle2);
        }
        public static bool operator !=(RECT Rectangle1, RECT Rectangle2) {
            return !Rectangle1.Equals(Rectangle2);
        }

        public override string ToString() {
            return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public bool Equals(RECT Rectangle) {
            return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
        }

        public override bool Equals(object Object) {
            if (Object is RECT) {
                return Equals((RECT)Object);
            } else if (Object is Rectangle) {
                return Equals(new RECT((Rectangle)Object));
            }

            return false;
        }
    }*/
}
