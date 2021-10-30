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
    enum FishingMode {
        Emulate,
        Moderate,
        Faster,
        Fastest
    }
    public partial class Form1 : Form {
        const string INITIAL_COUNTER = "1500";
        const int WM_SYSKEYDOWN = 0x0104;
        const int WM_SYSKEYUP = 0x0105;
        const int VK_KEY_5 = 0x35;
        const int VK_KEY_F = 0x46;

        private bool looping = false;
        private Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        private Point samplePoint = new Point(0, 0);
        private Random rnd = new Random();
        private IntPtr windowPointer;
        private bool traceMouseCursor = true;
        private FishingMode fishingModeLevel = FishingMode.Moderate;

        public Form1() {
            InitializeComponent();
            radioButtonEmulate.Tag = FishingMode.Emulate;
            radioButtonModerate.Tag = FishingMode.Moderate;
            radioButtonFaster.Tag = FishingMode.Faster;
            radioButtonFastest.Tag = FishingMode.Fastest;

            radioButtonModerate.Checked = true;

            counterTextBox.Text = INITIAL_COUNTER;
            statusLabel.Text = "done.";
            timer1.Interval = 100;
            timer1.Start();
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
            traceMouseCursor = false;
            // timer1.Stop();

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
                statusTextBox.Text = "BNS Found" + Environment.NewLine;

                int x = Int32.Parse(xTextBox.Text);
                int y = Int32.Parse(yTextBox.Text);

                var c = GetColorAt(this.windowPointer, x, y);

                statusLabel.Text = "color: " + c.ToArgb();

                Thread.Sleep(200);

                samplePoint = new Point(x,y);

                // var color = GetColorAt(zero, Int32.Parse(xTextBox.Text), Int32.Parse(ytextBox.Text));
                var color = GetPixel(samplePoint);
                // currentColor = color.ToArgb();
                fishingBackgroundWorker.RunWorkerAsync(2000);
            } else {
                statusTextBox.Text = "NOT Found" + Environment.NewLine;
                startButton.Enabled = true;
                stopButton.Enabled = false;
                counterTextBox.Text = INITIAL_COUNTER;
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn,
            IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        private void timer1_Tick(object sender, EventArgs e) {
            labelCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");

            if (traceMouseCursor) {
                var pt = new Point();

                GetCursorPos(ref pt);
                xTextBox.Text = pt.X.ToString();
                yTextBox.Text = pt.Y.ToString();
            } else {
                timer1.Interval = 1000;
            }
        }

        static IEnumerable<IntPtr> EnumerateProcessWindowHandles(int processId) {
            var handles = new List<IntPtr>();

            foreach (ProcessThread thread in Process.GetProcessById(processId).Threads)
                EnumThreadWindows(thread.Id,
                    (hWnd, lParam) => { handles.Add(hWnd); return true; }, IntPtr.Zero);

            return handles;
        }

        private void stopButton_Click(object sender, EventArgs e) {
            looping = false;
            stopButton.Enabled = false;
            if (!fishingBackgroundWorker.IsBusy) {
                fishingBackgroundWorker.CancelAsync();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            traceMouseCursor = false;

            if (predefinedComboBox.SelectedIndex == 0) {
                traceMouseCursor = true;
                timer1.Interval = 100;
            } else {
                statusLabel.Text = "Index: " + predefinedComboBox.SelectedIndex + ", value: " + predefinedComboBox.Text;

                var list = predefinedComboBox.Text.Split(",").ToList();

                xTextBox.Text = list[0].Trim();
                yTextBox.Text = list[1].Trim();
            }
        }

        private void PressKey(int key) {
            PostMessage(this.windowPointer, WM_SYSKEYDOWN, key, 0);
            Thread.Sleep(50);
            PostMessage(this.windowPointer, WM_SYSKEYUP, key, 0);
        }
        private void fishingBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            //const int WM_SYSKEYDOWN = 0x0104;
            //const int WM_SYSKEYUP = 0x0105;
            //const int VK_KEY_5 = 0x35;
            //const int VK_KEY_F = 0x46;
            const int RECENT_TIME_SIZE = 20;

            Color color1, color2;
            int counter = Int32.Parse(counterTextBox.Text);

            var windowMode = windowCheckBox.Checked;
            DateTime[] recentTime = new DateTime[RECENT_TIME_SIZE];
            int recentTimeIndex = 0;


            Thread.Sleep(1500);

            do {
                DateTime startedTime = DateTime.Now;
                int total = 0;

                textBoxStartedTime.Text = startedTime.ToString("HH:mm:ss");

                while (looping && counter > 0) {
                    textBoxCounter.Text = total.ToString();
                    PressKey(VK_KEY_5);
                    Thread.Sleep(2000);
                    color1 = windowMode ?
                        GetColorAt(this.windowPointer, samplePoint.X, samplePoint.Y) :
                        GetPixel(samplePoint);

                    pictureBox1.BackColor = color1;

                    do {
                        Thread.Sleep(100);
                        color2 = windowMode ?
                            GetColorAt(this.windowPointer, samplePoint.X, samplePoint.Y) :
                            GetPixel(samplePoint);
                    } while (color1.ToArgb() == color2.ToArgb());

                    pictureBox2.BackColor = color2;
                    Thread.Sleep(rnd.Next(250, 500));

                    PressKey(VK_KEY_F);

                    counter = Int32.Parse(counterTextBox.Text);

                    if (counter > 0) {
                        counter--;
                    }

                    counterTextBox.Text = counter.ToString();
                    total++;

                    var now = DateTime.Now;
                    var elapsedTime = now - startedTime;
                    var diffInSeconds = elapsedTime.TotalSeconds;
                    var avg = diffInSeconds / (double)total;
                    var est = now.AddSeconds(avg * counter);
                    var recentAvg = avg;
                    var recentEst = est;

                    recentTimeIndex = (recentTimeIndex + 1) % RECENT_TIME_SIZE;
                    if (total > RECENT_TIME_SIZE) {
                        recentAvg = (now - recentTime[recentTimeIndex]).TotalSeconds / (double) RECENT_TIME_SIZE;
                        recentEst = now.AddSeconds(recentAvg * counter);
                    }
                    recentTime[recentTimeIndex] = now;

                    var leftTime = TimeSpan.FromSeconds(recentAvg * counter);

                    textBoxEstimateTotal.Text = est.ToString("HH:mm:ss");
                    textBoxEstimateRecent.Text = recentEst.ToString("HH:mm:ss");
                    textBoxAvgTotal.Text = avg.ToString("0.00");
                    textBoxAvgRecent.Text = recentAvg.ToString("0.00");
                    textBoxLeftTime.Text = string.Format("{1:D2}:{2:D2}:{3:D2}",
                        leftTime.Days, leftTime.Hours, leftTime.Minutes, leftTime.Seconds);
                    //textBoxElapsed.Text = (now - startedTime).

                    if (elapsedTime.Days == 0) {
                        textBoxElapsed.Text = string.Format("{1:D2}:{2:D2}:{3:D2}",
                        elapsedTime.Days, elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);
                    } else {
                        textBoxElapsed.Text = string.Format("{0} day(s), {1:D2}:{2:D2}:{3:D2}",
                        elapsedTime.Days, elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);
                    }
                    string.Format("Upload completed, 100, {0:D2}:{1:D2}:{2:D2}:{3:D2}:{4:D3}",
                        elapsedTime.Days, elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds, elapsedTime.Milliseconds);

                    //statusLabel.Text = "Total: " + total + ", Avg: " + avg.ToString("0.00") +
                    //    "/" + recentAvg.ToString("0.00") +
                    //    ", Est: " + est.ToString("HH:mm:ss") + "/" + recentEst.ToString("HH:mm:ss");

                    int sleepTime = 0;

                    switch (fishingModeLevel) {
                        case FishingMode.Emulate:
                            sleepTime  = rnd.Next(5000, 7000);
                            break;
                        case FishingMode.Moderate:
                            sleepTime = rnd.Next(70, 700) + rnd.Next(300, 4800);
                            break;
                        case FishingMode.Faster:
                            sleepTime = rnd.Next(70, 500) + rnd.Next(300, 1000);
                            break;
                        case FishingMode.Fastest:
                            sleepTime = rnd.Next(200, 500);
                            break;
                    }

                    statusLabel.Text = "Mode: " + fishingModeLevel.ToString() + ", Wait: " + sleepTime + " ms.";
                    Thread.Sleep(sleepTime);
                }

                if (looping && counter <= 0) {
                    statusLabel.Text = "Task done.";

                    statusTextBox.Text += "Counter reach 0 at " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine;

                    while (looping) {
                        Thread.Sleep(1000);

                        var now = DateTime.Now;

                        if (now.Hour <= 12 && now.Hour >= 6 && now.Minute > 5) {
                            counter = 1500;
                            counterTextBox.Text = "1500";
                            statusTextBox.Text += "Reset Counter at " + DateTime.Now.ToString("hh:mm:ss") + Environment.NewLine;
                            break;
                        } else {
                            statusLabel.Text = "Current time: " + now.ToString("hh:mm:ss");
                        }
                    }
                }
            } while (looping);
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void fishingBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e) {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Tag is Enum) {
                fishingModeLevel = (FishingMode) radioButton.Tag;
            }
        }

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
}
