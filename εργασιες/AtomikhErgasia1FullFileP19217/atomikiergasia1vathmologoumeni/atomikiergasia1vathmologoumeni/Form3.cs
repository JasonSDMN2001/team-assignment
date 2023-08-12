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
    public partial class Form3 : Form
    {
        Random random;
        int randomImage;                                                            //το χρειαζομαι για να ειναι η τιμη του random με αυτο που βλεπουμε στο picture box
        int sum;
        int timer = 60;                                                             //η δυσκολια του λεβελ
        int count = 30;                                                             //
        public Form3(String s)
        {
            InitializeComponent();
            label8.Text = s;                                                        //με γρηγορο τροπο παιρνω το username απο την φορμα 1,για να το βλεπει ο χρηστης οταν παιζει 
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            random = new Random();                                                  //με την βοηθεια γεννητριων συναρτησεων βρισκω εναν τυχαιο αριθμο(μετα απο 1 εως 6) με την βοηθεια του clock του συστυματος
            label1.Visible = false;                                                 //για να μην δει ο χρηστης τα label πριν παρουν τιμη
            label2.Visible = false;                                                 //
            openFileDialog1.InitialDirectory = Application.StartupPath;             //για να διαβασω ή να γραψω στο αρχειο(προερετικη εργασια 2)
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = true;                                                  //καλο ειναι να μην βλεπει ο χρηστης τις ενεργειες πριν συμβουν
            label2.Visible = true;                                                  //
            randomImage = random.Next(1, 7);                                        //τυχαια επιλογη αριθμου ενα εως εξι για καθεμια απο της πλεβρες,η ευρεση προκυπτει με την βοηθεια της Random(μαθημα 9)
            pictureBox1.ImageLocation = "dice/" + randomImage.ToString() + ".png";  //relative path των εικονων των ζαριων μεσα στο /bin/debug αυτου του προγραμματος
            int x1, y1;                                                             //δηλωση μεταβλητων ακεραιων γιατι οι συντεταγμενες των πιξελ ειναι ακεραιοι αριθμοι
            x1 = random.Next(panel1.Width - pictureBox1.Width);                     //νεο τυχαιο σημειο,συντεταγμενη1
            y1 = random.Next(panel1.Height - pictureBox1.Height);                   //νεο τυχαιο σημειο,συντεταγμενη2
            pictureBox1.Location = new Point(x1, y1);                               //τυχαια μεταβολλη της τοποθεσιας του ζαριου
            timer--;                                                                //ο χρονος κυλα!
            label3.Text = timer.ToString();
            if (count <= 0)                                                         //πρωτη συνθηκη για τερματισμου παιχνιδιου
            {
                timer1.Enabled = false;                                             //προσωρινη παυση του παιχνιδιου
                pictureBox1.Enabled = false;                                        //επιπλεον βολες δεν θα αυξανουν το σκορ
                MessageBox.Show("Game over,you run out of shots");
                button1.Visible = true;                                             //επιλογη για να ξαναπαιξει ο παιχτης
            }
            else if (timer == 0)
            {
                timer1.Enabled = false;                                             //προσωρινη παυση του παιχνιδιου
                pictureBox1.Enabled = false;                                        //επιπλεον βολες δεν θα αυξανουν το σκορ
                MessageBox.Show("Game over,you run out of time");                   //δυο συνθηκες για να τελειωσει το παιχνιδι
                button1.Visible = true;                                             //επιλογη για να ξαναπαιξει ο παιχτης
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = 30;                                                             //νεος παιχωιδι μετα την πρωτη προσπαθεια του παιχτη
            timer = 60;                                                             //δυσκολια επιπεδου 2
            sum = 0;                                                                //αρχικοποιηση του συνολικου σκορ για ν συνεχιση του παιχνιδιου
            pictureBox1.Enabled = true;
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
            button1.Visible = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)         //μαθημα 9
        {
            count--;                                                                //ευστοχια
            label1.Text = count.ToString();                                         //μειωση των βολων
            sum += randomImage;                                                     //προσθεση του ακριβη αριθμου των ζαριων στο συνολικο σκορ
            label2.Text = sum.ToString();                                           //total score
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)             //fail to miss a shot and the total shots will go down!
        {
            count--;
            label1.Text = count.ToString();                                         //ανανεωση του total shots σε περιπτωση που αργησει να βρει στοχο 
        }                                                                           //ο παιχτης

        private void button2_Click(object sender, EventArgs e)                      //write lines on a txt file
        {
            StreamWriter sw = new StreamWriter("lvl2scores.txt", true);             //μαθημα 5 ή 6, προερετικη εργασια 2
            sw.WriteLine(label2.Text + " " + label8.Text);                          //label2 integer και string το ονομα του παιχτη σε προσπαθεια ταξινομισης;
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
