using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analogClock
{
    public partial class Form1 : Form
    {
        private System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();
        private System.Diagnostics.Stopwatch _rapTimer = new System.Diagnostics.Stopwatch();
        DateTime dt = DateTime.Now;


        public Form1()
        {
            InitializeComponent();
            

            timer1.Start();
        }
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (_sw.IsRunning)
            {
                _sw.Stop();
                _rapTimer.Stop();
                btnStartStop.Text = "Start";
                btnRapReset.Text = "Reset";

            }
            else
            {
                _sw.Start();
                _rapTimer.Start();
                btnStartStop.Text = "Stop";
                btnRapReset.Text = "Lap";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = _sw.Elapsed.ToString(@"hh\:mm\:ss\:ff");
            label3.Text = _rapTimer.Elapsed.ToString(@"hh\:mm\:ss\:ff");
        }

        private void btnRapReset_Click(object sender, EventArgs e)
        {
            if (_sw.IsRunning)
            {

                label5.Text = label4.Text;
                label4.Text = label2.Text;
                label2.Text = dt.ToString("yyyy/MM/dd HH:mm     ") + _rapTimer.Elapsed.ToString(@"hh\:mm\:ss\:ff");
                _rapTimer.Reset();
                _rapTimer.Start();
                
            }
            else
            {
                _sw.Reset();
                _rapTimer.Reset();
                label5.Text = "";
                label4.Text = "";
                label2.Text = "";
            }
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}