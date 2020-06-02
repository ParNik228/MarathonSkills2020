﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Marathon_Skills2016
{
   public class SqlConnClass
    {
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
                            ar.Hide();
                            RunnerMenu rm = new RunnerMenu();
                            rm.ShowDialog();
                            ar.Close();
                            
                        }
                        else
                        {
                            if (reader[2].ToString() == "A")
                            {
                                ar.Hide();
                                AdminMenuForm amf = new AdminMenuForm();
                                amf.ShowDialog();
                                ar.Close();
                            }
                            else
                            {
                                if (reader[2].ToString() == "C")
                                {
                                    ar.Hide();
                                    CoordMenuForm cmf = new CoordMenuForm();
                                    cmf.ShowDialog();
                                    ar.Close();
                                }
                            }
                        }
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
            reader.Close();
            conn.Close();
        }
    }
}
