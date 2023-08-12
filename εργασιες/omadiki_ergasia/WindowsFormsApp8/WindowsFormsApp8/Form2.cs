using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        string Gender; //Μέσω αυτής της μεταβλητής θα καταχωρείται στην βάση δεδομένων το φύλλο του κρούσματος.Η τιμή που θα πάρει εξαρτάται από το radiobutton που θα πατήσει ο υπάλληλος
        Regex regex = new Regex(@"[0-9]");
        Regex regex2 = new Regex(@"[α-ωΑ-Ω]");
        Regex regex3 = new Regex(@"[a-zA-Z]");

        public Form2()
        {
            InitializeComponent();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                //boolean variables and regular expressions
                //Χρησιμοποιούνται προκειμένου να εντοπίσουν τυχόν λάθη από τον χρήστη
                //π.χ Να εισάγει σε ένα textbox του οποίου το περιεχόμενο είναι string, κάτι που είναι τύπου int ή αντιστρόφως.
                //π.χ Να αφήσει κάποιο πεδίο κενό
                bool numCheck1 = regex2.IsMatch(textBox1.Text);
                bool numCheck2 = regex3.IsMatch(textBox2.Text);
                bool stringCheck1 = regex.IsMatch(textBox3.Text);
                bool stringCheck2 = regex.IsMatch(comboBox2.Text);
                bool numCheck4 = regex2.IsMatch(textBox5.Text);

                if (Gender != null && numCheck1 && numCheck2 && numCheck4 && stringCheck1 && stringCheck2)  //Το πεδίο με το underlying disease εξαιρείται του ελέγχου επειδή δεν είναι υποχρεωτικό.
                                                                                                            //Αν η συνθήκη είναι ψευδής,τότε παρακάτω εμφανίζεται σχετικό μήνυμα "Invalid input!Check the fields again!"
                {
                    string connectionstring = "Data Source=DB3.db;Version=3;";
                    SQLiteConnection conn = new SQLiteConnection(connectionstring); //conn η σύνδεση με την βάση
                    conn.Open();
                    String insertQuery = "Insert into krousmata(surname,Email,Contactphone,Sex,Age,underlyingdisease,Address,Time) values(@surname,@email,@contactphone,@sex,@age,@underlyingdisease,@address,@time)"; //εντολή σε SQL κατά την οποία δρομολογείται η καταχώρηση στη βάση,των στοιχείων που εισάγει ο υπάλληλος
                    SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);     //Στέλνουμε το αίτημα μαζί με την σύνδεση conn
                    cmd.Parameters.AddWithValue("@surname", textBox1.Text);     //κατά την εκτέλεση της εντολής καταχωρούμε στο πεδίο surname της βάσης krousmata το περιεχόμενο του textBox1...Η αντίστοιχη διαδικασία γίνεται και για τα υπόλοιπα πεδία
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@contactphone", textBox3.Text);
                    cmd.Parameters.AddWithValue("@sex", Gender);
                    cmd.Parameters.AddWithValue("@age", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@underlyingdisease", textBox4.Text);
                    cmd.Parameters.AddWithValue("@address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@time", dateTimePicker1.Text);
                    int count = cmd.ExecuteNonQuery();  //αφου εκτελεστεί η εντολή επιστρέφει τον αριθμό των καταγραφών που έγιναν στην βάση
                    MessageBox.Show("+" + count.ToString() + " " + "recorded case of coronavirus!");
                    conn.Close();
                }

                else
                {
                    MessageBox.Show("Invalid input!"+Environment.NewLine+"Check the fields again!");
                }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Αν ο υπάλληλος πατήσει στο radiobutton1 που λέει Άνδρας τότε η μεταβλητή Gender θα πάρει την αντίστοιχη τιμή
        {
            Gender = "Άνδρας";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Ομοίως αν πατήσει στο radiobutton1 που λέει Γυναίκα
        {
            Gender = "Γυναίκα";
        }
    }
}
