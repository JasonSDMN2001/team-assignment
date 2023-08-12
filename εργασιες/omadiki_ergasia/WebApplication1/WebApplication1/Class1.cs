using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1
{
    public class Class1
    {
        int c;
        int d;


        public String SelectCases() {
            
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "bin\\DB3.db;Version=3;");
            conn.Open();
            String query1 = "Select * from krousmata";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn); //με αυτόν τον τροπο του στελνουμε το αίτημα μας(query1) μαζι με την σύνδεση(conn)//
            SQLiteDataReader reader = cmd.ExecuteReader();
            StringBuilder builder = new StringBuilder();  //Το χρησιμοποιουμε για τη συνενωση των αλφαριθμητικων..εδω το θελουμε προκειμενου στη συνεχεια να εμφανισουμε όλα τα περιεχομενα της βασης μας μαζι και οχι ενα ενα ονομα ξεχωριστα
            while (reader.Read())              //Με το Read() διαβάζει το περιεχόμενο της βάσης σου που εχει εκχωρηθεί στον reader ανα γραμμη//
            {
                builder.Append(reader.GetInt32(0) + "  ").Append(reader.GetString(1) + "  ").Append(reader.GetString(2) + "  ").Append(reader.GetInt32(3) + "  ").Append(reader.GetString(4) + "  ").Append(reader.GetInt32(5) + "  ").Append(reader.GetString(6) + "  ").Append(reader.GetString(7) + "  ").Append(reader.GetString(8) + "<br/>");
            }
            conn.Close();
            return builder.ToString();
        }

        public int Andres()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "bin\\DB3.db;Version=3;");
            conn.Open();
            String selectQuery = "Select id from krousmata where Sex=@sex";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@sex", "Άνδρας");
            SQLiteDataReader reader = cmd.ExecuteReader();
            c = 0; //Έτσι ώστε κάθε φορα που πατήσει ο χρήστης τα στατιστικα,η μέτρηση να ξεκινάει απο το 0 και όχι από την τιμή της προηγούμενης μέτρησης
            while (reader.Read())    //ενώ εκτελείται το αίτημα μας,κάθε φορά που κατά την ανάγνωση εντοπίζεται κρούσμα με φύλλο γυναίκας,ο μετρητής θα αυξάνεται κατά ένα!
            {

                c += 1;
            }
            conn.Close();
            return c;
        }

        public int Ginaikes()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "bin\\DB3.db;Version=3;");
            conn.Open();
            String selectQuery = "Select id from krousmata where Sex=@sex";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@sex", "Γυναίκα");
            SQLiteDataReader reader = cmd.ExecuteReader();
            d = 0; //Έτσι ώστε κάθε φορα που πατήσει ο χρήστης τα στατιστικα,η μέτρηση να ξεκινάει απο το 0 και όχι από την τιμή της προηγούμενης μέτρησης
            while (reader.Read())    //ενώ εκτελείται το αίτημα μας,κάθε φορά που κατά την ανάγνωση εντοπίζεται κρούσμα με φύλλο γυναίκας,ο μετρητής θα αυξάνεται κατά ένα!
            {

                d += 1;
            }
            conn.Close();
            return d;
        }







    }
}