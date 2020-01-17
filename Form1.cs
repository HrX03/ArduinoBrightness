using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoBrightness
{
    public partial class Form1 : Form
    {
        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);

        [DllImport("gdi32.dll")]
        private unsafe static extern bool SetDeviceGammaRamp(Int32 hdc, void* ramp);

        private static Int32 hdc;

        public Form1()
        {
            InitializeComponent();
            StreamReader reader = new StreamReader("port.txt");
            serialPort1.PortName = reader.ReadLine();
            serialPort1.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private static void UpdateHDC()
        {
            hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc().ToInt32();
        }

        public static unsafe bool SetBrightness(int brightness)
        {
            UpdateHDC();
            if (brightness > 255)
                brightness = 255;
            if (brightness < 0)
                brightness = 0;
            short* gArray = stackalloc short[3 * 256];
            short* idx = gArray;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 256; i++)
                {
                    int arrayVal = i * (brightness + 128);
                    if (arrayVal > 65535)
                        arrayVal = 65535;
                    *idx = (short)arrayVal;
                    idx++;
                }
            }
            bool retVal = SetDeviceGammaRamp(hdc, gArray);
            return retVal;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    worker.ReportProgress(510);
                    break;
                }
                else
                {
                    int readData = 0;

                    try
                    {
                        readData = int.Parse(serialPort1.ReadLine());
                    }
                    catch (System.FormatException)
                    {}
                    catch (System.IO.IOException)
                    {}
                    catch (System.InvalidOperationException)
                    {}

                    worker.ReportProgress(readData);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double value = Convert.ToInt64(e.ProgressPercentage);
            label1.Text = value.ToString();

            if (value < 1024)
            {
                double lightness = (value / 1024) * 240;
                BackColor = ColorTranslator.FromWin32(ColorHLSToRGB(
                    0,
                    Convert.ToInt32(lightness),
                    20));

                SetBrightness(Convert.ToInt32((lightness / 240) * 255));

                if (lightness >= 120)
                {
                    label1.ForeColor = Color.Black;
                }
                else
                {
                    label1.ForeColor = Color.White;
                }
            }
            else
            {
                BackColor = Color.White;
                label1.ForeColor = Color.Black;
                SetBrightness(255);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
