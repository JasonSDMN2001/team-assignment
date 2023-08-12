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
    public partial class Form1 : Form
    {
        
      
        
        Regex regex = new Regex(@"[0-9]");
        Regex regex2 = new Regex(@"[a-zA-Z]");
        public Form1()
        {
            InitializeComponent();
        }

        private void εισαγωγήΚρούσματοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void πλήθοςΚρουσμάτωνΑνάΗλικίαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void άνδρεςΓυναίκεςToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Amount myObj = new Amount(); //Δημιουργώ ένα αντικείμενο της εξωτερικής τάξης Amount και μέσω αυτού του αντικειμένου καλώ την
            myObj.connSender("Γυναίκα"); // public μέθοδό της connSender με όρισμα 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void πλήθοςΑνδρώνToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Amount myObj2 = new Amount(); //Δημιουργώ ένα αντικείμενο της εξωτερικής τάξης Amount και μέσω αυτού του αντικειμένου καλώ την
            myObj2.connSender("Άνδρας");  // public μέθοδό της connSender με όρισμα 
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int age = System.Convert.ToInt16(toolStripTextBox1.Text);
                    if (age > 120 || age < 1)
                    {
                        MessageBox.Show("Please,try again!You can only use integers from 1 to 120.");
                    }
                    else
                    {
                        Ilikia myObj3 = new Ilikia(); //Δημιουργώ ένα αντικείμενο της εξωτερικής τάξης Ilikia και μέσω αυτού του αντικειμένου καλώ την
                        myObj3.ageSender(toolStripTextBox1.Text);//public μέθοδό της,ageSender με παράμετρο την εισαχθείσα ηλικία από τον χρήστη

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please,try again!You can only use integers from 1 to 120.");
                }
            }
        }

        private void διαγραφήToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void τροποποίησηΚρούσματοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    MatchCollection match22 = regex.Matches(toolStripTextBox2.Text);
                    int id = System.Convert.ToInt16(toolStripTextBox2.Text);
                    if (id < 1)
                    {
                        MessageBox.Show("Please,try again!You can only use integers greater than or equal to 1.");
                    }
                    else
                    {
                        string connectionstring = "Data Source=DB3.db;Version=3;";
                        SQLiteConnection conn = new SQLiteConnection(connectionstring); //conn η σύνδεση με την βάση
                        conn.Open();
                        String selectQuery = "Select * from krousmata where id=@id";
                        SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
                        cmd.Parameters.AddWithValue("@id", toolStripTextBox2.Text);
                        SQLiteDataReader reader = cmd.ExecuteReader();
                       
                        if (reader.Read())
                        {
                            
                            MessageBox.Show("Surname:"+" "+reader.GetString(1)+Environment.NewLine+"Email:"+" "+reader.GetString(2)+Environment.NewLine+"Contactphone:"+" "+reader.GetInt64(3)+Environment.NewLine+"Sex:"+" "+reader.GetString(4)+Environment.NewLine+"Age:"+" "+reader.GetInt32(5)+Environment.NewLine+"underlyingdisease:"+" "+reader.GetString(6)+Environment.NewLine+"Address:"+" "+reader.GetString(7)+Environment.NewLine+"Date:"+" "+reader.GetString(8));
                            
                        }
                        else
                        {
                            MessageBox.Show("There is no recorded case with this id!");
                        }
                        


                        conn.Close();

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please,try again!You can only use integers greater than or equal to 1.");
                }
            }
        }

        private void toolStripTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                
                  
                    bool mail = regex2.IsMatch(toolStripTextBox3.Text);
                    if (mail)
                    {

                        string connectionstring = "Data Source=DB3.db;Version=3;";
                        SQLiteConnection conn = new SQLiteConnection(connectionstring); //conn η σύνδεση με την βάση
                        conn.Open();
                        String selectQuery = "Select * from krousmata where Email=@email";
                        SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
                        cmd.Parameters.AddWithValue("@email", toolStripTextBox3.Text);
                        SQLiteDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {

                            MessageBox.Show("Surname:" + " " + reader.GetString(1) + Environment.NewLine + "Email:" + " " + reader.GetString(2) + Environment.NewLine + "Contactphone:" + " " + reader.GetInt64(3) + Environment.NewLine + "Sex:" + " " + reader.GetString(4) + Environment.NewLine + "Age:" + " " + reader.GetInt32(5) + Environment.NewLine + "underlyingdisease:" + " " + reader.GetString(6) + Environment.NewLine + "Address:" + " " + reader.GetString(7) + Environment.NewLine + "Date:" + " " + reader.GetString(8));

                        }
                        else
                        {
                            MessageBox.Show("There is no recorded case with this email!");
                        }



                        conn.Close();

                    }
                    else
                    {
                        MessageBox.Show("Invalid input!Please,try again!");
                    }
                
              
               
                    
                
            }
        }

        private void προβολήΚρουσμάτωνToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DB3.db;Version = 3;";
            SQLiteConnection conn = new SQLiteConnection(connectionString);  //conn είναι η συνδεση με τη βαση//
            conn.Open();
            String query1 = "Select * from krousmata";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn); //με αυτόν τον τροπο του στελνουμε το αίτημα μας(query1) μαζι με την σύνδεση(conn)//
            SQLiteDataReader reader = cmd.ExecuteReader(); 
            StringBuilder builder = new StringBuilder();  //Το χρησιμοποιουμε για τη συνενωση των αλφαριθμητικων..εδω το θελουμε προκειμενου στη συνεχεια να εμφανισουμε όλα τα περιεχομενα της βασης μας μαζι και οχι ενα ενα ονομα ξεχωριστα
            while (reader.Read())              //Με το Read() διαβάζει το περιεχόμενο της βάσης σου που εχει εκχωρηθεί στον reader ανα γραμμη//
            {
                builder.Append(reader.GetInt32(0)).Append(".").Append(reader.GetString(1)).Append(" ").Append(reader.GetString(2)).Append(" ").Append(reader.GetInt32(3)).Append(" ").Append(reader.GetString(4)).Append(" ").Append(reader.GetInt32(5)).Append(" ").Append(reader.GetString(6)).Append(" ").Append(reader.GetString(7)).Append(" ").Append(reader.GetString(8)).Append(Environment.NewLine);
            }
            MessageBox.Show(builder.ToString());
            conn.Close();
        }
    }

    public class Amount
    {
        int c;
        public void connSender(string sex)
        {
            string connectionstring = "Data Source=DB3.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring); //conn η σύνδεση με την βάση
            conn.Open();
            String selectQuery = "Select id from krousmata where Sex=@sex";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@sex", sex);
            SQLiteDataReader reader = cmd.ExecuteReader();
            c = 0; //Έτσι ώστε κάθε φορα που πατήσει ο χρήστης τα στατιστικα,η μέτρηση να ξεκινάει απο το 0 και όχι από την τιμή της προηγούμενης μέτρησης
            while (reader.Read())    //ενώ εκτελείται το αίτημα μας,κάθε φορά που κατά την ανάγνωση εντοπίζεται κρούσμα με φύλλο γυναίκας,ο μετρητής θα αυξάνεται κατά ένα!
            {

                c += 1;
            }

            MessageBox.Show(c.ToString());
            conn.Close();



        }



    }

    public class Ilikia
    {
        int i;
        public void ageSender(string age)  //τύπου string επειδή όταν την καλούμε,ως όρισμα έχουμε το toolStripTextBox1.Text
        {
            string connectionstring = "Data Source=DB3.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring); //conn η σύνδεση με την βάση
            conn.Open();
            String selectQuery = "Select id from krousmata where Age=@age";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@age", age);
            SQLiteDataReader reader = cmd.ExecuteReader();
            i = 0;
            while (reader.Read()) //ενώ εκτελείται το αίτημα μας,κάθε φορά που κατά την ανάγνωση, εντοπίζεται κρούσμα με την εισαχθείσα ηλικία,ο μετρητής θα αυξάνεται κατά ένα!
            {
                i += 1;
            }

            MessageBox.Show("Καταγράφονται" + " " + i.ToString() + " " + "κρούσματα αυτής της ηλικίας.");

            conn.Close();
        }
    }
}
