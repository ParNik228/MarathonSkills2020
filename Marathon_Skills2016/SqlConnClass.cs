using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Marathon_Skills2016
{
   public class SqlConnClass
    {

        public void UpdMyResForm(MyResForm mrf, int id)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT Gender FROM runner WHERE RunnerId =" + id ;
            MySqlCommand command = new MySqlCommand(sql, conn);
            string gender = command.ExecuteScalar().ToString();
            mrf.label9.Text += " " + gender;
            string sql1 = "SELECT DateOfBirth FROM runner WHERE RunnerId = " + id;
            command = new MySqlCommand(sql1, conn);
            DateTime date = Convert.ToDateTime(command.ExecuteScalar());//.ToString("yyyy.MM.dd hh:mm:ss");

            int dt = DateTime.Now.Year - date.Year;

            if (dt < 18)
            {
                mrf.label4.Text += " от 18";
            }
                if (dt >= 18 && dt <= 29)
                {
                mrf.label4.Text += " от 18 до 29";
                }
            if (dt >= 30 && dt <= 39)
            {
                mrf.label4.Text += " от 30 до 39";
            }
            if (dt >= 40 && dt <= 55)
            {
                mrf.label4.Text += " от 40 до 55";
            }
            if (dt >= 56 && dt <= 70)
            {
                mrf.label4.Text += " от 56 до 70";
            }
            if (dt > 70)
            {
                mrf.label4.Text += " более 70";
            }

            string sql3 = "SELECT RegistrationId FROM registration WHERE RunnerId = "+id;
            command = new MySqlCommand(sql3,conn);

            int regid = Convert.ToInt32(command.ExecuteScalar());

            string sql4 = "SELECT marathon.CityName,marathon.YearHeld,eventtype.EventTypeName,runner.DateOfBirth, `RaceTime`, `BibNumber` FROM registrationevent JOIN event ON registrationevent.EventId = event.EventId JOIN marathon ON event.MarathonId = marathon.MarathonId JOIN eventtype ON event.EventTypeId=eventtype.EventTypeId JOIN registration ON registrationevent.RegistrationId = registration.RegistrationId JOIN runner ON registration.RunnerId=runner.RunnerId WHERE registrationevent.RegistrationId = " + regid;

            command = new MySqlCommand(sql4, conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string mar = reader[1].ToString() + " " + reader[0].ToString();
                string dist = reader[2].ToString();
                int hour = Convert.ToInt32(reader[4])/3600;
                int min = (Convert.ToInt32(reader[4]) - hour * 3600)/60;
                int sec = Convert.ToInt32(reader[4]) - hour*3600 - min*60;

                ListViewItem item = new ListViewItem(new string[] {mar, dist,hour.ToString()+"h "+min.ToString()+"m "+sec.ToString()+"s",reader[5].ToString(),reader[3].ToString()});
                mrf.listView1.Items.Add(item);
            }
            reader.Close();
            conn.Close();
        }
        public void UpdateRecInRunner(string email, int id,int type, string password, string firstname, string lastname,string gender,string dateofbirth,string photo, string country)
        {   
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sqlcount ="SELECT CountryCode FROM country WHERE CountryName ='"+country+"'";
            MySqlCommand command = new MySqlCommand(sqlcount, conn);
            string countCode = command.ExecuteScalar().ToString();

            if (type == 0)
            {
               
                string sql = "UPDATE runner SET Gender = '"+gender+"', DateOfBirth = '"+dateofbirth+"', RunnerPhoto= '"+photo+"', CountryCode = '"+countCode+"'WHERE RunnerId ="+id;
                command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            if(type == 1)
            {
                string sql2 = "UPDATE runner SET Gender = '" + gender + "', DateOfBirth = '" + dateofbirth + "', RunnerPhoto= '" + photo + "', CountryCode = '" + countCode + "'WHERE RunnerId =" + id;
                command = new MySqlCommand(sql2, conn);
                command.ExecuteNonQuery();
                string sql3 = "UPDATE user SET FirstName = '"+firstname+"' WHERE Email = '"+email+"'";
                command = new MySqlCommand(sql3, conn);
                command.ExecuteNonQuery();
            }
            if (type == 2)
            {
                string sql4 = "UPDATE runner SET Gender = '" + gender + "', DateOfBirth = '" + dateofbirth + "', RunnerPhoto= '" + photo + "', CountryCode = '" + countCode + "'WHERE RunnerId =" + id;
                command = new MySqlCommand(sql4, conn);
                command.ExecuteNonQuery();
                string sql5 = "UPDATE user SET FirstName = '" + firstname + "', LastName = '"+lastname+ "' WHERE Email = '" + email + "'";
                command = new MySqlCommand(sql5, conn);
                command.ExecuteNonQuery();
            }
            if(type == 3)
            {
                string sql6 = "UPDATE runner SET Gender = '" + gender + "', DateOfBirth = '" + dateofbirth + "', RunnerPhoto= '" + photo + "', CountryCode = '" + countCode + "'WHERE RunnerId =" + id;
                command = new MySqlCommand(sql6, conn);
                command.ExecuteNonQuery();
                string sql7 = "UPDATE user SET LastName ='" + lastname + "' WHERE Email = '" + email + "'";
                command = new MySqlCommand(sql7, conn);
                command.ExecuteNonQuery();
            }
            if(type == 4)
            {
                string sql8 = "UPDATE runner SET Gender = '" + gender + "', DateOfBirth = '" + dateofbirth + "', RunnerPhoto= '" + photo + "', CountryCode = '" + countCode + "'WHERE RunnerId =" + id;
                command = new MySqlCommand(sql8, conn);
                command.ExecuteNonQuery();
                string sql9 = "UPDATE user SET Password = '"+password+"', FirstName= '" + firstname + "',LastName = '" + lastname + "' WHERE Email = '" + email + "'";
                command = new MySqlCommand(sql9, conn);
                command.ExecuteNonQuery();
            }
            if (type == 5)
            {
                string sql9 = "UPDATE runner SET Gender = '" + gender + "', DateOfBirth = '" + dateofbirth + "', RunnerPhoto= '" + photo + "', CountryCode = '" + countCode + "'WHERE RunnerId =" + id;
                command = new MySqlCommand(sql9, conn);
                command.ExecuteNonQuery();
                string sql10 = "UPDATE user SET Password = '" + password + "' WHERE Email = '" + email + "'";
                command = new MySqlCommand(sql10, conn);
                command.ExecuteNonQuery();
            }
            if (type == 6)
            {
                string sql8 = "UPDATE runner SET Gender = '" + gender + "', DateOfBirth = '" + dateofbirth + "', RunnerPhoto= '" + photo + "', CountryCode = '" + countCode + "'WHERE RunnerId =" + id;
                command = new MySqlCommand(sql8, conn);
                command.ExecuteNonQuery();
                string sql9 = "UPDATE user SET Password = '" + password + "', LastName = '" + lastname + "' WHERE Email = '" + email + "'";
                command = new MySqlCommand(sql9, conn);
                command.ExecuteNonQuery();
            }
            if (type == 7)
            {
                string sql8 = "UPDATE runner SET Gender = '" + gender + "', DateOfBirth = '" + dateofbirth + "', RunnerPhoto= '" + photo + "', CountryCode = '" + countCode + "'WHERE RunnerId =" + id;
                command = new MySqlCommand(sql8, conn);
                command.ExecuteNonQuery();
                string sql9 = "UPDATE user SET Password = '" + password + "', FirstName= '" + firstname + "' WHERE Email = '" + email + "'";
                command = new MySqlCommand(sql9, conn);
                command.ExecuteNonQuery();
            }


           
            conn.Close();
        }
        public void GetEditRunnerProfile(EditProfileForm epf, int id)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT Email FROM runner WHERE RunnerId = "+id;
            MySqlCommand command = new MySqlCommand(sql, conn);
            epf.label14.Text = command.ExecuteScalar().ToString();
            string sql1 = "SELECT DateOfBirth FROM runner WHERE RunnerID = "+id;
            command = new MySqlCommand(sql1, conn);

            DateTime dt = Convert.ToDateTime(command.ExecuteScalar());
            epf.dateTimePicker1.Value = dt;
            string sql2 = "SELECT CountryName FROM country";
            command = new MySqlCommand(sql2, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                epf.comboBox2.Items.Add(reader[0].ToString());


            }
            reader.Close();
            string sql3 = "SELECT RunnerPhoto FROM runner WHERE RunnerId =" + id;
            command = new MySqlCommand(sql3, conn);
            string str = command.ExecuteScalar().ToString();
            //epf.pictureBox1.Load(str);
            epf.textBox7.Text = str;
            string sql5 = "SELECT Gender FROM runner WHERE RunnerId = "+id;
            command = new MySqlCommand(sql5, conn);
            string gender = command.ExecuteScalar().ToString();
            epf.comboBox1.SelectedItem = gender;
            string sql4 = "SELECT CountryName From runner JOIN country ON runner.CountryCode=country.CountryCode WHERE runner.RunnerId ="+id;
            command = new MySqlCommand(sql4, conn);
            string country = command.ExecuteScalar().ToString();
            epf.comboBox2.SelectedItem = country;
            conn.Close();
        }
        public void InsDataFromRegistration(int rnid,string date, string kit, int cost, string charity,int target)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT CharityId FROM charity WHERE CharityName = '" + charity + "'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            string charitCode = command.ExecuteScalar().ToString();
            
            string sql1 = "INSERT INTO registration(RunnerId,RegistrationDateTime,RaceKitOptionId,RegistrationStatusId,Cost,CharityId,SponsorshipTarget) VALUES(" + rnid + ", '" + date + "', '" + kit + "', '"+1+"', '" + cost + "', "+charitCode+", "+target+")";
           
            command = new MySqlCommand(sql1, conn);
            command.ExecuteNonQuery();
            
            conn.Close();
        }
        public int GetRuddenrId(string email) 
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
           
            conn.Open();
            string sql2 = "SELECT RunnerId FROM runner WHERE Email='" + email + "'";
             MySqlCommand command = new MySqlCommand(sql2, conn);
            command = new MySqlCommand(sql2, conn);
            int id = Convert.ToInt32(command.ExecuteScalar());
            return id;
        }

        public int RegEventCalc(string sqlstr)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = sqlstr;
            MySqlCommand command = new MySqlCommand(sql, conn);
            int cost = Convert.ToInt32(command.ExecuteScalar());
            conn.Close();
            return cost;
        }
        public void RegEventLogic(string marathtype,string kit,string charity,string sum)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT CharityName FROM charity";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

               

            }
            reader.Close();
            conn.Close();
        }
        public void RegEventLoad(RegEventForm rf)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT CharityName FROM charity";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                rf.comboBox1.Items.Add(reader[0].ToString());

            }
            reader.Close();
            conn.Close();
        }
        public void RegFormLoad(RegForm rf)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT CountryName FROM country";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                rf.comboBox2.Items.Add(reader[0].ToString());

            }
            reader.Close();
            conn.Close();

        }
        public void RegRunnrAdd(string email, string firstname,string lastname,string password,string gender,string dateBirth, string countryName,string photo)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT CountryCode FROM country WHERE CountryName = '"+countryName+"'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            string countCode = command.ExecuteScalar().ToString();
            // MySqlDataReader reader = command.ExecuteReader();
            string sql1 = "INSERT INTO user(Email,Password,FirstName,LastName,RoleId) VALUES('" + email + "', '" + password + "', '" + firstname + "', '" + lastname + "', 'R')";
            string sql2 = "INSERT INTO runner(Email,Gender,DateOfBirth,RunnerPhoto,CountryCode) VALUES('" + email + "', '" + gender + "', '" + dateBirth + "', '"+photo+"', '" + countCode + "')";
            command = new MySqlCommand(sql1, conn);
            command.ExecuteNonQuery();
            command = new MySqlCommand(sql2, conn);
            command.ExecuteNonQuery();

            // reader.Close();
            conn.Close();
        }
        
        public void SponsorAddRec(SponsorForm sf, string str,string name,string sum)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT RegistrationId FROM registration WHERE RunnerId = "+str;
           
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            string regid = "";

            while (reader.Read())
            {

                regid = reader[0].ToString();

            }
            string sql1 = "INSERT INTO sponsorship(SponsorName,RegistrationId,Amount) VALUES('"+name+"', '"+regid+"', '"+sum+"')";
            reader.Close();
            command = new MySqlCommand(sql1, conn);
            command.ExecuteNonQuery();
            
            conn.Close();
        }
        public string Connection()
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT Date FROM eventdate";
            MySqlCommand command = new MySqlCommand(sql, conn);
            string name = command.ExecuteScalar().ToString();
            conn.Close();
            return name;
           
        }

        public void ConectRunnerFoeSponsor(SponsorForm sf)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT runner.RunnerId, user.FirstName, user.LastName, country.CountryName FROM user JOIN runner ON user.Email = runner.Email JOIN country ON runner.CountryCode = country.CountryCode";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {

                sf.comboBox1.Items.Add(reader[0].ToString()+" "+reader[1].ToString()+" "+reader[2].ToString()+" "+reader[3].ToString());
                
            }
            reader.Close();
                conn.Close();
            
        }

        public void CharityForRunner(SponsorForm sf, string str)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT CharityName FROM registration JOIN charity ON registration.CharityId = Charity.CharityId WHERE registration.RunnerId = "+str;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                sf.label20.Text = reader[0].ToString();

            }
            reader.Close();
            conn.Close();
        }

       
        public void ListOfCharReader(ListOfChar loc)
        {
            
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT CharityLogo, CharityDescription, CharityName FROM charity";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                loc.imgAdd(reader[0].ToString(),reader[2].ToString()+": "+reader[1].ToString());
            }
            reader.Close();
            conn.Close();

        }
        public void auth(string email, string password,AuthorizForm ar)
        {
            string connStr = "server=localhost;user=root;database=pafenov;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            
            conn.Open();
            string sql = "SELECT Password, Email,RoleId FROM user";
            
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            bool pass =false;
            bool em = false;
            bool runner = false;
            bool admn = false;
            bool coord = false;
            while (reader.Read())
            {
                if (reader[1].ToString() == email)
                {
                    em = true;
                    if (reader[0].ToString() == password)
                    {
                        pass = true;
                        if (reader[2].ToString() == "R")
                        {

                            runner = true;

                        }
                        else
                        {
                            if (reader[2].ToString() == "A")
                            {
                                admn = true;
                            }
                            else
                            {
                                if (reader[2].ToString() == "C")
                                {
                                    
                                }
                            }
                        }
                    }
                    
                }
                

            }
            reader.Close();
            if(em == true)
            {
                if(pass == true)
                {
                    if (runner == true)
                    {
                            string sql2 = "SELECT RunnerId FROM runner WHERE Email='"+email+"'";
                            
                           
                            command = new MySqlCommand(sql2, conn);
                            
                            int id = Convert.ToInt32(command.ExecuteScalar());
                            ar.Hide();
                            RunnerMenu rm = new RunnerMenu(id);
                            //conn.Close();
                            rm.ShowDialog();
                           
                            conn.Close();
                            
                            ar.Close();
                    }
                    if (admn == true)
                    {
                        ar.Hide();
                        AdminMenuForm amf = new AdminMenuForm();
                        amf.ShowDialog();
                        //reader.Close();
                        conn.Close();
                        ar.Close();
                    }
                    if (coord == true)
                    {
                                    ar.Hide();
                                    CoordMenuForm cmf = new CoordMenuForm();
                                    cmf.ShowDialog();
                                    //reader.Close();
                                    conn.Close();
                                    ar.Close();
                    }
                }
            }
            if (em == false)
            {
                MessageBox.Show("Неверный email!");
            }
            else
            {
                if (pass == false)
                {
                    MessageBox.Show("Неверный пароль!");
                }
               
            }
           //reader.Close();
            conn.Close();
        }
    }
}
