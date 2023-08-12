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
    public partial class Form4 : Form
    {
        string Gender2;
        Regex regex = new Regex(@"[0-9]");
        Regex regex2 = new Regex(@"[α-ωΑ-Ω]");
        Regex regex3 = new Regex(@"[a-zA-Z]");
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boolean variables and regular expressions
            //Χρησιμοποιούνται προκειμένου να εντοπίσουν τυχόν λάθη από τον χρήστη
            //π.χ Να εισάγει σε ένα textbox του οποίου το περιεχόμενο είναι string, κάτι που είναι τύπου int ή αντιστρόφως.
            //π.χ Να αφήσει κάποιο πεδίο κενό
                bool numCh1 = regex2.IsMatch(textBox1.Text);
                bool stringCh1 = regex.IsMatch(textBox2.Text);
                bool numCh2 = regex2.IsMatch(textBox3.Text);
                bool stringCh2 = regex.IsMatch(textBox5.Text);
                bool numCh3 = regex2.IsMatch(textBox7.Text);
                bool numCh4 = regex3.IsMatch(textBox4.Text);
                bool stringCh3 = regex.IsMatch(comboBox1.Text);

               if (numCh1 && numCh2 && numCh3 && numCh4 && stringCh1 && stringCh2 && stringCh3 && Gender2!= null){


                    string connectionstring = "Data Source=DB3.db;Version=3;";
                    SQLiteConnection conn = new SQLiteConnection(connectionstring); //conn η σύνδεση με την βάση
                    conn.Open();
                    String updateQuery = "Update krousmata Set surname=@surname2,Email=@email,Contactphone=@contactphone2,Sex=@sex,Age=@age,underlyingdisease=@underlyingdisease,Address=@address,Time=@time where surname=@surname and id=@id"; //Τροποποίησε/ενημέρωσε το κρούσμα με το όνομα που θα εισαχθεί στο textBox1 και το id που θα εισαχθεί στο textBox2
                    SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@surname", textBox1.Text);  //Το όνομα του κρούσματος προς τροποποίηση
                    cmd.Parameters.AddWithValue("@id", textBox2.Text);       //Το id του κρούσματος προς τροποποίηση
                    cmd.Parameters.AddWithValue("@surname2", textBox3.Text);  //Το νέο όνομα
                    cmd.Parameters.AddWithValue("@contactphone2", textBox5.Text);  //Το (νέο) τηλέφωνο επικοινωνίας
                    cmd.Parameters.AddWithValue("@address", textBox7.Text);        //Η (νέα) διεύθυνση κατοικίας
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);          //(νέο) email
                    cmd.Parameters.AddWithValue("@sex", Gender2);                  //(νεο) φύλλο 
                    cmd.Parameters.AddWithValue("@age", comboBox1.Text);           //(νέα) ηλικία
                    cmd.Parameters.AddWithValue("@underlyingdisease", textBox6.Text);  //(νέο) υποκείμενα νοσήματα
                    cmd.Parameters.AddWithValue("@time", dateTimePicker1.Text);        //νέα ημερομηνία τροποποίησης
                    int count = cmd.ExecuteNonQuery();  //κατά την εκτέλεση της εντολής επιστρέφει τον αριθμό των τροποποιήσεων που έγιναν στην βάση
                    if (count == 0)                     //Αν ο αριθμός των τροποποιήσεων είναι μηδενικός τότε σημαίνει ότι δεν έγινε κάποια τροποποίηση,άρα τα στοιχεία του κρούσματος προς τροποποίηση που εισήγαγε ο υπάλληλος είναι λανθασμένα και εμφανίζεται σχετικό μήνυμα
                    {
                        MessageBox.Show("Wrong name or id!");
                    }
                    else
                    {
                        MessageBox.Show("+" + count.ToString() + " " + " " + "updated case!!!");
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Invalid input!" + Environment.NewLine + "Check the fields again!");
                }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender2 = "Άνδρας";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender2 = "Γυναίκα";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
