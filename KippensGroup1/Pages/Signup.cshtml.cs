using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1.Pages
{
    public class SignupModel : PageModel
    {
        public string Error { get; set; }
        private string username;
        private string uid;
        private string pwd;

        public void OnGet()
        {
            Error = "Enter user info: ";
            username = "";
        }


        public IActionResult onPostSignup(string name, string email, string pass, string number)
        {
            
            if (!emailValidation(email))
            {
                return Page();
            }

            createUsername(name);
            getLoginInfo();
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(uid, pwd));
            string query = "INSERT INTO user(name, username, email, password, roleID) VALUES ('"+name+"', '"+username+"', '"+email+"', '"+pass+"', 1);";
            db.performQuery(query);
            query = "CREATE USER '"+username+"'@'localhost' IDENTIFIED BY '"+pass+"'; GRANT SELECT ON kippens TO '"+username+ "'@'localhost'; FLUSH PRIVILEGES;";
            db.performQuery(query);

            return Redirect("/Index");
        }

        private bool emailValidation(string email)
        {
            Error = "Not valid email";
            if(email == null)
            {
                return false;
            }

           bool validEmailCheck = false;
           for(int i = 0; i < email.Length; i++)
            {
                if(email[i] == '@')
                {
                    validEmailCheck = true;
                }
            }

            if (!validEmailCheck)
            {
                return false;
            }

            string query = "SELECT email FROM user WHERE email='"+email+";";
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder("harry", "elbomoneky"));
            MySqlDataReader reader;
            try
            {
                reader = db.performQuery(query);
                if (!reader.HasRows)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Error = "could not query DB";
                return false;
            }


            Error = "Valid email";
            return true;
        }

        private void createUsername(string email)
        {
            username = "";
            for(int i = 0; i < email.Length; i++)
            {
                if (email[i] != '@')
                {
                    username += email[i];
                }
                else
                {
                    break;
                }
            }
        }

        private void getLoginInfo()
        {
            string filename = "mysqlLogin.txt";
            string[] lines = System.IO.File.ReadAllLines(".\\Data files\\" + filename);
            foreach (string line in lines)
            {
                if (line[0] == 'u')
                {
                    this.uid = line.Remove(0, 4);
                }
                else if (line[0] == 'p')
                {
                    this.pwd = line.Remove(0, 4);
                }
            }
        }
    }
}