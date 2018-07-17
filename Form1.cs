using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smarthome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            light.ImageLocation = "LightOff.png"; //picture file path
            waveoven.ImageLocation = "WaveovenOff.png";
            heater.ImageLocation = "HeaterOff.png";
            aircondition.ImageLocation = "AirconditionOff.png";

            light.Load();//load picture

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reset picturebox and bontton's text
            string s=button1.Text;
            if (s == "start")
            {
                button1.Text = "stop";

                //voice to text

                //reset image

            }
            else
            {

            }
        }
    }
}
