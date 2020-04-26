using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1
{
    public class DBHandler
    {
        private string connectionString;
        private string error;

        public DBHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool checkIfDBExist()
        {
            MySqlConnection db = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("USE kippens; SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'kippens'", db);
            // checks if database exist
            try
            {
                db.Open();
                var reader = cmd.ExecuteReader();
                db.Close();
            }catch(Exception e)
            {
                return false;
            }
                       
            return true;
        }

        public void createDB()
        {
            MySqlConnection db = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE kippens;", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Role(roleID int AUTO_INCREMENT NOT NULL, Name Varchar(50) NOT NULL, Description Varchar(900), PRIMARY KEY(roleID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();


            cmd = new MySqlCommand("USE kippens; create table User(userID int NOT NULL AUTO_INCREMENT, name varchar(50) NOT NULL, username varchar(50) NOT NULL, email varchar(50) NOT NULL,password varchar(128) NOT NULL,number varchar(15) NULL,roleID int NOT NULL,PRIMARY KEY(userID),FOREIGN KEY(roleID) REFERENCES Role(roleID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Volunteer(volunteerID int AUTO_INCREMENT NOT NULL,userID int NOT NULL,name Varchar(50) NOT NULL,role varchar(900) NOT NULL,PRIMARY KEY(volunteerID),FOREIGN KEY(userID) REFERENCES User(userID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Donation(Name Varchar(50) NOT NULL,description Varchar(900) NOT NULL,userID int NOT NULL,donationID int NOT NULL AUTO_INCREMENT,time DATETIME NOT NULL,roleID int NOT NULL,QUANTITY int NOT NULL,PRIMARY KEY(donationID),FOREIGN KEY(userID) REFERENCES User(userID),FOREIGN KEY(roleID) REFERENCES Role(roleID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Report(filePath Varchar(200) NOT NULL,timeCreated Time NOT NULL,frequency varchar(50) NOT NULL,reportID int NOT NULL,roleID int NOT NULL AUTO_INCREMENT,FOREIGN KEY(roleID) REFERENCES Role(roleID),PRIMARY KEY(reportID)); ", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Transactions(transactionID int NOT NULL AUTO_INCREMENT,time DateTime NOT NULL,roleID int NOT NULL,name Varchar(50) NOT NULL,description Varchar(900) NOT NULL,userID int NOT NULL,QUANTITY int NOT NULL,PRIMARY KEY(transactionID),FOREIGN KEY(userID) REFERENCES User(userID),FOREIGN KEY(roleID) REFERENCES Role(roleID));", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Tutors(tutorID int NOT NULL AUTO_INCREMENT,userID int NOT NULL,subject VARCHAR(50) NOT NULL,PRIMARY KEY(tutorID),FOREIGN KEY(userID) REFERENCES User(userID));", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Counselors(CounselorID int NOT NULL AUTO_INCREMENT,UserID int NOT NULL,PRIMARY KEY(CounselorID),FOREIGN KEY(UserID) REFERENCES User(userID));", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            cmd = new MySqlCommand("USE kippens; create table Students(studentID int NOT NULL AUTO_INCREMENT,name varchar(50) NOT NULL,gender varchar(50) NOT NULL,address varchar(200) NOT NULL,grade varchar(50) NOT NULL,eContact varchar(50) NOT NULL,tutorID int NOT NULL,PRIMARY KEY(studentID),FOREIGN KEY(tutorID) REFERENCES tutors(tutorID));", db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            insertData(db);
        }

        private void insertData(MySqlConnection db)
        {
            string roles = "";
            roles += "INSERT INTO role(Name, description) VALUES ('general user', 'Basic level for an account');";
            roles += "INSERT INTO role(Name, description) VALUES ('Food Pantry', 'Level for the food pantry workers and volenteers');";
            roles += "INSERT INTO role(Name, description) VALUES ('Clothing Closet', 'Level for the clothing closet workers and volenteers');";
            roles += "INSERT INTO role(Name, description) VALUES ('Tutoring', 'Level for the tutors and volenteers');";
            roles += "INSERT INTO role(Name, description) VALUES ('Counselors', 'Level for the Counselors and volenteers');";
            MySqlCommand cmd = new MySqlCommand("USE kippens; " + roles, db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            string admins = "";
            admins += "INSERT INTO user(name, username, email, password, roleID) VALUES ('closet admin', 'cadmin', 'cadmin@kippens.org', 'admin', 3);";
            admins += "INSERT INTO user(name, username, email, password, roleID) VALUES ('pantry admin', 'padmin', 'padmin@kippens.org', 'admin', 2);";
            admins += "INSERT INTO user(name, username, email, password, roleID) VALUES ('tutor admin', 'tadmin', 'tadmin@kippens.org', 'test', 4);";
            admins += "INSERT INTO user(name, username, email, password, roleID) VALUES ('Counselor Admin', 'test', 'couadmin@kippens.org', 'test', 5);";
            admins += "INSERT INTO user(name, username, email, password, roleID) VALUES ('test user', 'test', 'test@kippens.org', 'test', 1);";
            cmd = new MySqlCommand("USE kippens; " + admins, db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            string trans = "";
            trans += "INSERT INTO transactions(time, roleID, name, description, userID, QUANTITY) VALUES ('2018-04-24', '3', 'first', 'first transaction', '1', '10');";
            trans += "INSERT INTO transactions(time, roleID, name, description, userID, QUANTITY) VALUES ('2020-04-24', '3', 'second', 'second transaction', '1', '20');";
            trans += "INSERT INTO transactions(time, roleID, name, description, userID, QUANTITY) VALUES ('2020-03-01', '2', 'third', 'third transaction', '2', '30');";
            trans += "INSERT INTO transactions(time, roleID, name, description, userID, QUANTITY) VALUES ('2000-05-19', '2', 'fourth', 'four transaction', '2', '40');";
            trans += "INSERT INTO transactions(time, roleID, name, description, userID, QUANTITY) VALUES ('1997-09-11', '2', 'fifth', 'five transaction', '2', '50');";

            cmd = new MySqlCommand("USE kippens; " + trans, db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            string don = "";
            don += "INSERT INTO donation(time, roleID, name, description, userID, QUANTITY) VALUES ('2018-04-24', '3', 'first', 'first donation', '1', '10');";
            don += "INSERT INTO donation(time, roleID, name, description, userID, QUANTITY) VALUES ('2020-04-24', '3', 'second', 'second donation', '1', '20');";
            don += "INSERT INTO donation(time, roleID, name, description, userID, QUANTITY) VALUES ('2020-03-01', '2', 'third', 'third donation', '2', '30');";
            don += "INSERT INTO donation(time, roleID, name, description, userID, QUANTITY) VALUES ('2000-05-19', '2', 'fourth', 'four donation', '2', '40');";
            don += "INSERT INTO donation(time, roleID, name, description, userID, QUANTITY) VALUES ('1997-09-11', '2', 'fifth', 'five donation', '2', '50');";

            cmd = new MySqlCommand("USE kippens; " + don, db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            string tut = "";
            tut += "INSERT INTO tutors(userID, subject) VALUES ('3', 'Computer scinece')";

            cmd = new MySqlCommand("USE kippens; " + tut, db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();

            string cou = "";
            cou += "INSERT INTO counselors(userID) VALUES ('4')";

            cmd = new MySqlCommand("USE kippens; " + cou, db);
            db.Open();
            cmd.ExecuteReader();
            db.Close();
        }


        public static string connectionStringBuilder(string user, string pass)
        {
            return "server=localhost; database=kippens; uid=" + user + "; pwd=" + pass+";";
        }

        public string getError()
        {
            return this.error;
        }

        


        // performs query and returns it in a raw form.
        public MySqlDataReader performQuery(string query)
        {
            MySqlConnection db = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, db);
            MySqlDataReader reader = null;
            try
            {
                db.Open();
                reader = cmd.ExecuteReader();
            } catch(Exception e)
            {
                this.error = "Problem query";
                return null;
            }

            return reader;
        } 
    }
}
