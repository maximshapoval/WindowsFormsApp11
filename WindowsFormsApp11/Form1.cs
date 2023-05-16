using System;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        int minutes;
        int seconds;

        public Form1()
        {
            InitializeComponent();
        }



        private void startButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("ПОМИЛКА! ВВЕДІТЬ ЗНАЧЕННЯ!");
                return;
            }
            else
            {
                minutes = int.Parse(textBox1.Text);
                seconds = int.Parse(textBox2.Text);

                if (seconds >= 60)
                {
                    minutes += seconds / 60;
                    seconds %= 60;
                }

                label1.Text = $"{minutes:00}:{seconds:00}";
                timer1.Start();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (seconds > 0)
            {
                seconds--;
            }
            else if (minutes > 0)
            {
                minutes--;
                seconds = 59;
            }

            label1.Text = $"{minutes:00}:{seconds:00}";

            if (minutes == 0 && seconds == 0)
            {
                timer1.Stop();
                MessageBox.Show("Час вичерпано!");
            }
        }
    }
}