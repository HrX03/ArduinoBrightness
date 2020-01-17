using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoBrightness
{
    public partial class SerialPortForm : Form
    {
        public SerialPortForm()
        {
            InitializeComponent();
        }

        private void SerialPortForm_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            portSelector.Items.Clear();

            for(int i = 0; i < ports.Count(); i++)
            {
                portSelector.Items.Add(ports[i]);
            }

            portSelector.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            //(new Form1(portSelector.SelectedItem.ToString())).Show();
        }
    }
}
