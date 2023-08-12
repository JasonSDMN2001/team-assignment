using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace atomikiergasia1vathmologoumeni
{
    public partial class Form2 : Form
    {
        Random random;
        int randomImage;
        int sum;
        int timer=40;
        int count=20;
        public Form2(String s)
        {
            InitializeComponent();
            label8.Text = s;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            random = new Random();
            label1.Visible = false;
            label2.Visible = false;
            openFileDialog1.InitialDirectory = Application.StartupPath;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            randomImage = random.Next(1, 7);
            pictureBox1.ImageLocation = "dice/" + randomImage.ToString() + ".png";
            int x1, y1;
            x1 = random.Next(panel1.Width - pictureBox1.Width);
            y1 = random.Next(panel1.Height - pictureBox1.Height);
            pictureBox1.Location = new Point(x1, y1);
            timer--;
            label3.Text = timer.ToString();
            if (count <= 0)
            {
                timer1.Enabled = false;
                pictureBox1.Enabled = false;               
                MessageBox.Show("Game over,you run out of shots");
                button1.Visible = true;
            }
            else if (timer == 0)
            {
                timer1.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("Game over,you run out of time");
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = 20;
            timer = 40;
            sum = 0;
            pictureBox1.Enabled = true;
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
            button1.Visible = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            count--;
            label1.Text = count.ToString();
            sum += randomImage;
            label2.Text = sum.ToString();  //total score
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            count--;
            label1.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("lvl1scores.txt", true);
            sw.WriteLine(label2.Text +" "+ label8.Text);
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
