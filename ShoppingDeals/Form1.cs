/*
 * Name: Warren Barnes
 * Date: 10/27/16
 * Project: Project 2
 * Purpose: Learn C#
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ShoppingDeals
{
    public partial class Form1 : Form
    {
        struct User
        {
            public String name;
        }

        struct Deal
        {
            public String product;
            public double price;
            public DateTime expirationDate;
            public List<String> likes;
            public List<String> dislikes;
        }

        List<User> users;
        List<Deal> deals;

        public Form1()
        {
            users = new List<User>();
            deals = new List<Deal>();

            InitializeComponent();

            //TODO: Fix dateTimePicker format in GUI
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MM/dd/yyyy";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                {
                    string line;

                    StreamReader file = File.OpenText("users.dat");
                    while ((line = file.ReadLine()) != null && line != "")
                    {
                        User user;
                        user.name = line;
                        users.Add(user);
                    }

                    file.Close();
                }
            }
            catch (Exception ex)
            {
                lblStatusStrip.Text = "Error reading the file";
                Console.WriteLine(ex.Message);
            }

            try
            {
                {
                    string line;

                    StreamReader file = File.OpenText("deals.dat");
                    while ((line = file.ReadLine()) != null && line != "")
                    {
                        Deal deal;
                        String[] dealInfo = line.Split(',');
                        deal.product = dealInfo[0];
                        deal.price = Double.Parse(dealInfo[1]);
                        deal.expirationDate = Convert.ToDateTime(dealInfo[2]);

                        String[] likes = dealInfo[3].Split(' ');
                        List<String> likeList = new List<String>();
                        for(int i = 0; i < likes.Length; i++)
                        {
                            likeList.Add(likes[i]);
                        }
                        deal.likes = likeList;

                        String[] dislikes = dealInfo[4].Split(' ');
                        List<String> dislikeList = new List<String>();
                        for (int i = 0; i < dislikes.Length; i++)
                        {
                            dislikeList.Add(dislikes[i]);
                        }
                        deal.dislikes = dislikeList;

                        deals.Add(deal);
                    }

                    file.Close();
                }
            }
            catch (Exception ex)
            {
                lblStatusStrip.Text = "Error reading the file";
                Console.WriteLine(ex.Message);
            }
            
            for(int i = 0; i < deals.Count; i++)
            {
                txtDeals.Text += deals[i].product + ", " + deals[i].price + ", " + deals[i].expirationDate + "\n";
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            User user;
            user.name = txtUsernameToAdd.Text;
            users.Add(user);

            try
            {
                String output = "";

                for (int i = 0; i < users.Count; i++)
                {
                    output += users[i].name + "\n";
                }

                StreamWriter file = File.CreateText("users.dat");
                {
                    file.Write(output);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                lblStatusStrip.Text = "Error saving the file";
                Console.WriteLine("ERROR MESSAGE: " + ex.Message);
            }
        }

        private void btnAddDeal_Click(object sender, EventArgs e)
        {
            Deal deal;
            deal.product = txtProductToAdd.Text;
            deal.price = double.Parse(txtPrice.Text);
            deal.expirationDate = dateTimePicker.Value.Date;
            deal.likes = new List<String>();
            deal.dislikes = new List<String>();
            txtDeals.Text += "\n" + deal.product + ", " + deal.price + ", " + deal.expirationDate;
            deals.Add(deal);

            try
            {
                String output = "";
                Deal tempDeal;

                for (int i = 0; i < deals.Count; i++)
                {
                    tempDeal = deals[i];
                    output += deals[i].product + "," + tempDeal.price + "," + tempDeal.expirationDate + ",";
                    for (int j = 0; j < tempDeal.likes.Count; j++)
                    {
                        output += tempDeal.likes[j] + " ";
                    }
                    output += ",";
                    for (int j = 0; j < tempDeal.dislikes.Count; j++)
                    {
                        output += tempDeal.dislikes[j] + " ";
                    }
                    output += "\n";
                }

                StreamWriter file = File.CreateText("deals.dat");
                {
                    file.Write(output);
                    file.Close();
                }
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                lblStatusStrip.Text = "Error saving the file";
                Console.WriteLine("ERROR MESSAGE: " + ex.Message);
            }
        }

        private bool usernameTaken(String username)
        {
            bool result = false;

            for (int i = 0; i < users.Count; i++)
            {
                if(username == users[i].name)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String attemptedUsername = txtEnterUsername.Text;
            txtEnterUsername.Text = "";

            for(int i = 0; i < users.Count; i++)
            {
                if(attemptedUsername == users[i].name)
                {
                    btnLogin.Enabled = false;
                    btnLogout.Enabled = true;
                    lblStatusStrip.Text = "Logged in as: " + attemptedUsername;
                    return;
                }
            }
            lblStatusStrip.Text = "Login failed. \"" + attemptedUsername + "\" not found.";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;
            btnLogout.Enabled = false;
            lblStatusStrip.Text = "Logged out";
        }
    }
}
