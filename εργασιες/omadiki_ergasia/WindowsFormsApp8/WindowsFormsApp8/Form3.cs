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

namespace WindowsFormsApp8
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=DB3.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring); //conn η σύνδεση με την βάση
            conn.Open();
            String deleteQuery = "Delete from krousmata where surname=@surname and Contactphone=@contactphone and Address=@address";
            SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn);
            cmd.Parameters.AddWithValue("@surname", textBox1.Text);
            cmd.Parameters.AddWithValue("@contactphone", textBox2.Text);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            int count = cmd.ExecuteNonQuery(); //κατά την εκτέλεση της εντολής επιστρέφει τον αριθμό των διαγραφών που έγιναν στην βάση
            if (count == 0)                    //Αν ο αριθμός των διαγραφών είναι μηδενικός τότε σημαίνει ότι δεν έγινε κάποια διαγραφή,άρα τα στοιχεία που εισήγαγε ο υπάλληλος δεν υπάρχουν καταχωρημένα και εμφανίζεται σχετικό μήνυμα
            {
                MessageBox.Show("There is no such entry in our database!");
            }
            else
            {
                MessageBox.Show("+" + count.ToString() + " " + "case of coronavirus has been deteled.");//αν ο αριθμός είναι διάφορος του 0,τότε τα στοιχεία που εισήγαγε ο υπάλληλος υπήρχαν καταχωρημένα στη βάση και η διαγραφή του κρούσματος έγινε με επιτυχία.
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
