using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atomikiergasia2vathmologoumeni
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        int startingX, endingX, x1, startingY, endingY, y1, MaxSE, timeElapsed = 0, time2Elapsed = 0;   //coordinates για τα σχηματα,δυο αθροιστες για τους timer
        Boolean tree,unipi,trident,smile,freestyle, lines, elipse, circle, rectangle, freedraw = false;     //boolean,οταν παταω τα κουμπια ενεργοποιηται τι σχημα θελω να κανω,και μενεθ μεχρι να το αλλαξω,για συνεχη σχεδια
        String shape;                                                                                   //το ονομα του σχηματος για να το γραψω στο db
        private void linesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lines = true;
            freestyle = false;
            circle = false;                     //ενεργοποιω τις γραμμες και απενεργοποιω τα υπολοιπα
            rectangle = false;
            elipse = false;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circle = true;
            rectangle = false;
            lines = false;              //ενεργοποιω τον κυκλο
            freestyle = false;
            elipse = false;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p.Width = 2;            //μικρη διαμετρος pen,απο τις μεθοδους του pen p
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p.Width = 4;        //μεσαια διαμετρος

        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p.Width = 8;        //μεγαλη διαμετρος

        }

        private void tridentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trident = true;         //τι σχημα να ξεκινησει να κανει οταν πατησω το κουμπι που ξεκινα τον timer
            timeElapsed = 0;        //αρχικοποιω εναν αθροιστη που θα χρειαστω να ειναι μικρα νουμερα για ευκολη κατανοηση και αποφυγη λαθων
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time2Elapsed++;     //ο χρονος που εχει περασει απο το ανοιγμα του παραθυρου μου,για να το γραψω στο db
        }

        private void unipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unipi = true;           //ενα διαφορετικο σχημα
            timeElapsed = 0;
            timer1.Start();     //ξεκινω τον timer που χρειαζομαι
        }

        private void smileyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smile = true;       //τριτο σχημα χαμογελαστης φατσουλας
            timeElapsed = 0;
            timer1.Start();
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)      //καπως προεραιτικο
        {
            p = new Pen(Color.White);       //γομα για να σβηνω τα σχεδια μου
            p.Width = 50;                   //το παχος της δεν αλλαζει,διοτι εξηπηρετει σε ικανοποιητικο επιπεδο την χρηση την οποια θελω να κανει
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeElapsed++;      //ο αρθροιστης μου ξεκινα απο το μηδεν
            if(tree)
            {
                p.Width = 4;            //ενα ικανοποιητικο παχος για να φαινονται τα χρωματα του σχεδιου μου
                if (timeElapsed == 1)           //βαζω ενα time stamp για να αρχιζει να ζωγραφιζει,ο χρονος μεταξυ των χτυπων του timer
                {                               //ειναι αναλογος για την ψευδαισθηση οτι ζωγραφιζεται εκεινη την στιγμη,500 ms στα properties του timer1
                    p.Color = Color.Chocolate;      //αλλαγη του χρωματος του pen μου
                    g.DrawRectangle(p, 158, 306,40,80); //kormos,παραλληλογραμμο χρησιμοποιοντας το pen μου,ξεκινα στο x=158,y=306
                                                        //εχει παχος 40 και υψος 80
                }
                if (timeElapsed == 2)
                {
                    p.Color = Color.Green;
                    g.DrawLine(p, 95, 304, 259, 304); //proto,γραμμη απο σημειο σε σημειο
                }
                if (timeElapsed == 3)
                {                                   //εδω εχει κρατησει το χρωμα και δεν χρειαζεται να το ξαναγραψω
                    g.DrawLine(p, 95, 304, 178, 206); //proto
                    g.DrawLine(p, 178, 206, 259, 304);
                }
                if (timeElapsed == 4)
                {
                    g.DrawLine(p, 116, 242, 242, 242);
                }
                if (timeElapsed == 5)
                {
                    g.DrawLine(p, 116, 242, 184, 178);
                }
                if (timeElapsed == 6)
                {
                    g.DrawLine(p, 184, 178, 242, 242);
                }
                if (timeElapsed == 7)
                {
                    g.DrawLine(p, 145, 192, 217, 192);
                }
                if (timeElapsed == 8)
                {
                    g.DrawLine(p, 145, 192, 185, 140);
                    g.DrawLine(p, 185, 140, 217, 192);
                }
                if (timeElapsed == 9)
                {
                    p.Color = Color.Red;
                    g.DrawEllipse(p, 170, 168, 18, 19);         //καποια χριστουγεννιατικα στολιδια
                }
                if (timeElapsed == 10)
                {
                    g.DrawEllipse(p, 205, 228, 18, 19);
                }
                if (timeElapsed == 11)
                {
                    p.Color = Color.Navy;
                    g.DrawEllipse(p, 161, 224, 18, 19);
                }
                if (timeElapsed == 12)
                {
                    g.DrawEllipse(p, 182, 254, 19, 18);
                }
                if (timeElapsed == 13)
                {
                    p.Color = Color.DeepPink;
                    g.DrawEllipse(p, 204, 275, 18, 19);
                }
                if (timeElapsed == 14)
                {
                    g.DrawEllipse(p, 129, 185, 18, 19);
                }
                if (timeElapsed == 15)
                {
                    p.Color = Color.LightSeaGreen;
                    g.DrawEllipse(p, 155, 280, 18, 19);
                }
                if (timeElapsed == 16)
                {
                    p.Color = Color.Gold;
                    g.DrawLine(p, 159, 145, 182, 96);
                    g.DrawLine(p, 182, 96, 211, 145);
                    g.DrawLine(p, 211, 145, 145, 116);
                    g.DrawLine(p, 145, 116, 217, 116);
                    g.DrawLine(p, 217, 116, 159, 145);  
                    timer1.Enabled = false;                 //σταματω τον timer γιατι δεν χρειαζεται να συνεχισει αλλο,για να μην σπαταλαω resurses
                    tree = false;                   //απενεργοποιω το boolean του σχεδιου για να μην ξαναρχισει με το πατημα ενος αλλου κουμπιου
                }
            }
            if (trident)
            {
                p.Width = 4;
                if (timeElapsed == 1)               //το ιδιο και γι αυτο το σχεδιο
                {
                    p.Color = Color.Navy;
                    g.DrawLine(p,387, 388, 388, 212);
                }
                if (timeElapsed == 2)
                {
                    p.Color = Color.Gold;
                    g.DrawLine(p, 356, 212, 421, 212);
                }
                if (timeElapsed == 3)
                {
                    g.DrawLine(p, 356, 212, 356, 156);
                }
                if (timeElapsed == 4)
                {
                    g.DrawLine(p, 421, 212, 421, 156); //δευτερο καθετο
                }
                if (timeElapsed == 5)
                {
                    g.DrawLine(p, 388, 212, 388, 156);
                }
                if (timeElapsed == 6)
                {
                    g.DrawLine(p, 347, 161, 356, 156);
                }
                if (timeElapsed == 7)
                {
                    g.DrawLine(p, 365, 161, 356, 156);
                }
                if (timeElapsed == 8)
                {
                    g.DrawLine(p, 412, 161, 421, 156);
                }
                if (timeElapsed == 9)
                {
                    g.DrawLine(p, 421, 156, 430, 161);
                }
                if (timeElapsed == 10)
                {
                    g.DrawLine(p, 388, 156, 379, 161);
                }
                if (timeElapsed == 11)
                {
                    g.DrawLine(p, 388, 156, 397, 161);
                }
                if (timeElapsed == 12)
                {
                    p.Color = Color.Navy;
                    g.DrawLine(p, 382, 388, 392, 388);
                    timer1.Stop();
                    trident = false;
                }
            }
            if (smile)
            {
                p.Width = 4;            //το ιδιο και γι αυτο το σχεδιο
                if (timeElapsed == 1)
                {
                    p.Color = Color.Gold;
                    g.DrawEllipse(p, 649, 230, 175, 175);
                }
                if (timeElapsed == 2)
                {
                    g.DrawEllipse(p, 690, 264, 40, 40);
                }
                if (timeElapsed == 3)
                {
                    g.DrawEllipse(p, 755, 264, 40, 40);
                }
                if (timeElapsed == 4)
                {
                    g.DrawLine(p,740, 310, 725, 332);
                }
                if (timeElapsed == 5)
                {
                    g.DrawLine(p, 725, 332, 745, 332);
                }
                if (timeElapsed == 6)
                {
                    g.DrawArc(p, 691, 264, 100, 100, 45, 90);
                }
                if (timeElapsed == 7)
                {
                    p.Color = Color.MediumSeaGreen;
                    g.DrawLine(p, 659, 272, 637, 238);
                }
                if (timeElapsed == 8)
                {
                    g.DrawLine(p, 637, 238, 673, 261);
                }
                if (timeElapsed == 9)
                {
                    g.DrawLine(p, 673, 261, 667, 216);
                }
                if (timeElapsed == 10)
                {
                    g.DrawLine(p, 667, 216, 692, 240);
                }
                if (timeElapsed == 11)
                {
                    g.DrawLine(p, 692, 240, 699, 206);
                }
                if (timeElapsed == 12)
                {
                    g.DrawLine(p, 699, 206, 720, 233);
                }
                if (timeElapsed == 13)
                {
                    g.DrawLine(p, 720, 233, 737, 202);
                }
                if (timeElapsed == 14)
                {
                    g.DrawLine(p, 737, 202, 746, 231);
                }
                if (timeElapsed == 15)
                {
                    g.DrawLine(p, 746, 231, 766, 211);
                    g.DrawLine(p, 766, 211, 782, 240);
                }
                if (timeElapsed == 16)
                {
                    g.DrawLine(p, 782, 240, 803, 228);
                    g.DrawLine(p, 803, 228, 803, 265);
                    timer1.Stop();
                    smile = false;
                }
            }
            if (unipi)
            {
                p.Width = 4;            //το ιδιο και γι αυτο το σχεδιο
                if (timeElapsed == 1)
                {
                    p.Color = Color.Navy;
                    g.DrawLine(p, 60, 635, 60, 555);
                    g.DrawLine(p, 60, 555, 100, 555);   //p
                    g.DrawLine(p, 100, 555, 100, 635);
                }
                if (timeElapsed == 2)
                {
                    g.DrawLine(p, 105, 635, 130, 555);
                    g.DrawLine(p, 130, 555, 155, 635);  //a
                    g.DrawLine(p, 115, 595, 145, 595);
                }
                if (timeElapsed == 3)
                {
                    g.DrawLine(p, 160, 635, 160, 555);  //n
                    g.DrawLine(p, 160, 555, 205, 635);
                    g.DrawLine(p, 205, 635, 205, 555);
                }
                if (timeElapsed == 4)
                {
                    g.DrawLine(p, 215, 635, 215, 555);
                    g.DrawLine(p, 215, 555, 250, 555);
                    g.DrawLine(p, 215, 635, 250, 635);
                    g.DrawLine(p, 215, 595, 250, 595);  //e
                }
                if (timeElapsed == 5)
                {
                    g.DrawLine(p, 260, 635, 260, 555);  //p
                    g.DrawLine(p, 260, 555, 300, 555);
                    g.DrawLine(p, 300, 555, 300, 635);
                }
                if (timeElapsed == 6)
                {
                    g.DrawLine(p, 310, 635, 330, 635);
                    g.DrawLine(p, 320, 635, 320, 555);  //i
                    g.DrawLine(p, 310, 555, 330, 555);
                }
                if (timeElapsed == 7)
                {
                    g.DrawLine(p, 335, 635, 365, 635);
                    g.DrawLine(p, 335, 555, 365, 555);
                    g.DrawLine(p, 335, 635, 350, 595);
                    g.DrawLine(p, 335, 555, 350, 595);  //s
                }
                if (timeElapsed == 8)
                {
                    g.DrawLine(p, 370, 555, 400, 555);
                    g.DrawLine(p, 385, 555, 385, 635); //T
                }
                if (timeElapsed == 9)
                {
                    g.DrawLine(p, 405, 635, 405, 555);
                    g.DrawLine(p, 405, 595, 445, 595);
                    g.DrawLine(p, 445, 555, 445, 635);  //h
                }
                if (timeElapsed == 10)
                {
                    g.DrawLine(p, 450, 555, 450, 635);
                    g.DrawLine(p, 490, 555, 490, 635);
                    g.DrawLine(p, 450, 555, 470, 595);
                    g.DrawLine(p, 490, 555, 470, 595);  //m
                }
                if (timeElapsed == 11)
                {
                    g.DrawLine(p, 495, 555, 515, 555);
                    g.DrawLine(p, 495, 635, 515, 635);
                    g.DrawLine(p, 505, 555, 505, 635);  //i 
                }
                if (timeElapsed == 12)
                {
                    g.DrawEllipse(p, 520, 555, 60, 80); //o
                }
                if (timeElapsed == 13)
                {
                    p.Color = Color.Red;
                    g.DrawLine(p, 60, 760, 60, 690);
                    g.DrawLine(p, 60, 690, 100, 690);
                    g.DrawLine(p, 100, 690, 100, 760);  //p
                }
                if (timeElapsed == 14)
                {
                    g.DrawLine(p, 110, 760, 110, 690);
                    g.DrawLine(p, 110, 690, 145, 690);
                    g.DrawLine(p, 110, 760, 145, 760);
                    g.DrawLine(p, 110, 725, 145, 725);  //e
                }
                if (timeElapsed == 15)
                {
                    g.DrawLine(p, 155, 760, 175, 760);
                    g.DrawLine(p, 155, 690, 175, 690);
                    g.DrawLine(p, 165, 690, 165, 760);  //i
                }
                if (timeElapsed == 16)
                {
                    g.DrawLine(p, 185, 760, 185, 690);
                    g.DrawLine(p, 185, 690, 205, 690);
                    g.DrawLine(p, 205, 690, 205, 715);
                    g.DrawLine(p, 205, 715, 185, 715);  //r
                }
                if (timeElapsed == 17)
                {
                    g.DrawLine(p, 205, 760, 230, 690);
                    g.DrawLine(p, 230, 690,250 ,760 );  //a
                    g.DrawLine(p, 220, 725, 240, 725);
                }
                if (timeElapsed == 18)
                {
                    g.DrawLine(p, 255, 760, 275, 760);
                    g.DrawLine(p, 255, 690, 275, 690);
                    g.DrawLine(p, 265, 690, 265, 760);  //i
                }
                if (timeElapsed == 19)
                {
                    g.DrawLine(p, 285, 760, 310, 690);
                    g.DrawLine(p, 310, 690, 330, 760);  //a
                    g.DrawLine(p, 300, 725, 320, 725);
                    unipi = false;
                    timer1.Stop();
                }
            }
        }

        private void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tree = true;        //ενα αλλο σχεδιο
            timeElapsed = 0;
            timer1.Start();
        }

        private void colourToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)           //εναλλαγη χρωματος του pen μου
                p = new Pen(colorDialog1.Color);
        }

        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elipse = true;
            freestyle = false;
            lines = false;                  
            circle = false;             //ενεργοποιω την ελλιψη
            rectangle = false;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectangle = true;
            freestyle = false;
            lines = false;          //ενεργοποιω το παραλληλογραμμο
            circle = false;
            elipse = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (freedraw == true)               //μεταβλητη για να μπορω να ζωγραφιζω συνεχομενα,χωρις καποιο θεμα,με βαση της προεραιτικης 3
            {
                g.DrawLine(p, x1, y1, e.X, e.Y);            //σχεδιαζει γραμμη,με βαση το τρεχον σημειο,οπως καναμε στο μαθημα
                x1 = e.X;
                y1 = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (rectangle == true)
            {
                startingX = x1;
                endingX = e.X;
                startingY = y1;                 //αν εχω επιλεξει το παραλληλογραμμο
                endingY = e.Y;                  //καποια σημεια θα αλλιωθουν με βαση που πατησα και που
                if (e.X > x1)  {                 //αφησα το ποντικι μου
                    startingX = e.X;
                    endingX = x1;
                }
                if (e.X > y1)
                {
                    startingY = e.Y;
                    endingY = y1;
                }
                shape = "rectangle";            //πιο σχημα ειναι το τρεχον για να το γραψω στην βαση μου
                g.DrawRectangle(p, endingX, endingY, startingX - endingX, startingY - endingY);
            }
            else if (lines == true)
            {
                g.DrawLine(p, x1, y1, e.X, e.Y);
                shape = "lines";            //πιο σχημα ειναι το τρεχον για να το γραψω στην βαση μου
            }
            else if (elipse == true)            //παρομοιο για τα διαφορετικα σχηματα
            {
                startingX = x1;
                endingX = e.X;
                startingY = y1;
                endingY = e.Y;
                if (e.X > x1)
                {
                    startingX = e.X;
                    endingX = x1;
                }
                if (e.X > y1)
                {
                    startingY = e.Y;
                    endingY = y1;
                }
                RectangleF elipticalRectangle = new RectangleF(endingX, endingY, startingX - endingX, startingY - endingY);
                g.DrawEllipse(p, elipticalRectangle);       //απο γνωστη μεθοδο του pen
                shape = "elipse";           //πιο σχημα ειναι το τρεχον για να το γραψω στην βαση μου
            }
            else if (circle == true)
            {
                startingX = x1;
                endingX = e.X;
                startingY = y1;
                endingY = e.Y;      //παρομοιο για τον κυκλο
                if (e.X > x1)
                {
                    startingX = e.X;
                    endingX = x1;
                }
                if (e.X > y1)
                {
                    startingY = e.Y;
                    endingY = y1;
                }
                MaxSE = Math.Max(startingX - endingX, startingY - endingY);     //οπως και στην προεραιτικη,το μονο που θελω στον κυκλο
                RectangleF elipticalRectangle = new RectangleF(endingX, endingY, MaxSE, MaxSE);     //ειναι να ισαπεχουν τα σημεια του,σε αντιθεση με την ελειψη,αρα απλα αφαιρω τις συντεταγμενες
                g.DrawEllipse(p, elipticalRectangle);
                shape = "circle";       //πιο σχημα ειναι το τρεχον για να το γραψω στην βαση μου
            }
            freedraw = false;
            if (freestyle) shape = "freestyle";     //πιο σχημα ειναι το τρεχον για να το γραψω στην βαση μου
            if (shape != null)          //δεν θελω οταν παταω το ποντικι μου να νομιζει και να γραφει στην βαση ενα κενο σχημα με ενα timestamp απο τον timer2
            {
                string connectionstring = "Data Source=drawings.db;Version=3;";     //η συνδεση μου στην βαση,οπως και στο μαθημα,
                SQLiteConnection conn = new SQLiteConnection(connectionstring);     //την προσθεσα στο project μου,και την εχω αποθηκευμενη εδω μεσα
                conn.Open();    
                String insertQuery = "Insert into Drawings(shape,time) values('" + shape + "','" + time2Elapsed + "')"; //στις δυο στηλες 
                SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);                       //που χρειαζομαι,γραφω μεσα τις δυο πληροφοριες που θελω
                cmd.ExecuteNonQuery();
                conn.Close();       //δεν ξεχναω να την κλεινω
            }
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("made by Ιάσων Μποϊδάνης p19217");  //πληροφοριες
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();       //κλεισιμο παραθυρου 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            p = new Pen(Color.DarkBlue);        //φτιαχνω νεο pen και graphics οπως μαθαμε στο μαθημα
        }

        private void freeStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            freestyle = true;
            lines = false;      //ενεργοποιω το freestyle(που μετα θα ενεργοποιηθει το freedraw)
            elipse = false;
            rectangle = false;
            circle = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (freestyle == true) freedraw = true;     //χρειαζομαι μια δευτερη boolean γιατι το freestyle θα 
            x1 = e.X;                                   //ηταν ενεργο απο την αρχη που πατησα το κουμπι και θα 
            y1 = e.Y;                                   //δημιουργοντουσαν σφαλαμτα
        }
    }
}
