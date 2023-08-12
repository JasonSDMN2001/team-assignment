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
    public partial class Form1 : Form                                   //τα σχολια για τον κωδικα των level γραφτηκαν στην form3,οπου ειναι ιδια για καθε λεβελ,
    {                                                                   //εκτος απο τα νουμερα της δσκολιας και σε πιο αρχειο σωζονται τα στοιχεια των σκορ
        Boolean level1 = false;   //
        Boolean level2 = false;   //level controler
        Boolean level3 = false;   //
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)       //cancel unwanted levels
        {
            level1 = true;
            level2 = false;
            level3 = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            level1 = false;
            level2 = true;
            level3 = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            level1 = false;
            level2 = false;
            level3 = true;
        }

        private void button1_Click(object sender, EventArgs e)       //load choosen levels απο μαθημα 2 ή 3
        {
            if (level1 == true)
            {
                Form2 form2 = new Form2(textBox1.Text);
                form2.Show();
            }
            else if (level2 == true)
            {
                Form3 form3 = new Form3(textBox1.Text);
                form3.Show();
            }
            else if (level3 == true)
            {
                Form4 form4 = new Form4(textBox1.Text);
                form4.Show();
            }
            else
            {
                MessageBox.Show("Choose Gamemode!");          //exception?
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)       //student atributes
        {
            MessageBox.Show("Αυτό το παιχνίδι φτιάχτηκε απο τον φοιτητή Ιάσων" +
                " Μποϊδάνη π19217");
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)       //rules tips
        {
            MessageBox.Show(" Step 1:\n Choose a game mode\n Step 2:\n State" +
                " your username\n Step 3:\n Fail to hit a target and you'll miss a " +
                "mark off your total shots \n");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }             //error
        //string[] lvl1 = File.ReadAllLines("lvl1scores.txt");                  //high score calculator
        
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = new StreamReader("lvl1scores.txt").ReadToEnd();         //reads strings from file(προερετικη εργασια 2)

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = new StreamReader("lvl2scores.txt").ReadToEnd();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = new StreamReader("lvl3scores.txt").ReadToEnd();

        }
    }
}
