using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock_CountDown
{
    public partial class Form1 : Form
    {

        private int TotalSeconds;

    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button2.Enabled = false;

            for (int i = 0; i < 60; i++)
            {
                this.comboBox1.Items.Add(i.ToString());
                this.comboBox2.Items.Add(i.ToString());
            }
            this.comboBox1.SelectedIndex = 00;
            this.comboBox2.SelectedIndex = 00;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = true;

            int minutes = int.Parse(this.comboBox1.SelectedItem.ToString());
            int seconds = int.Parse(this.comboBox2.SelectedItem.ToString());
            TotalSeconds = (minutes * 60) + seconds;
            this.timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TotalSeconds = 0;
            this.button2.Enabled = false;
            this.button1.Enabled = true;
            this.timer1.Enabled = false;
            int minutes = TotalSeconds / 60;
            int seconds = TotalSeconds - (minutes * 60);
            this.label3.Text = minutes.ToString().PadLeft(2,'0') + ":" + seconds.ToString().PadLeft(2, '0');
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TotalSeconds > 0)
            {
                TotalSeconds--;
                int minutes = TotalSeconds / 60;
                int seconds = TotalSeconds - (minutes * 60);
                this.label3.Text = minutes.ToString().PadLeft(2,'0') + ":" + seconds.ToString().PadLeft(2, '0');
            }
            else 
            {
                this.timer1.Stop();
                MessageBox.Show("Time's up");
                Console.Beep();
            }
        }
    }
}
