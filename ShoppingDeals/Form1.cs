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

        String loggedInUser = "";

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

                        String[] splitChars = new string[] {"+"};

                        String[] likes = dealInfo[3].Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                        List<String> likeList = new List<String>();
                        for(int i = 0; i < likes.Length; i++)
                        {
                            likeList.Add(likes[i]);
                        }
                        deal.likes = likeList;

                        String[] dislikes = dealInfo[4].Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
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
                if (deals[i].expirationDate < DateTime.Now)
                {
                    deals.RemoveAt(i);
                    i--;
                }
            }

            writeDealsToFile();
            listDeals();
        }

        private bool usernameTaken(String username)
        {
            bool result = false;

            for (int i = 0; i < users.Count; i++)
            {
                if (username == users[i].name)
                {
                    lblStatusStrip.Text = "Username \"" + username + "\" already taken";
                    txtUsernameToAdd.Text = "";
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            User user;
            user.name = txtUsernameToAdd.Text;

            if (usernameTaken(user.name))
            {
                return;
            }

            users.Add(user);
            lblStatusStrip.Text = "User \"" + user.name + "\" added";

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

            for(int i = 0; i < deals.Count; i++)
            {
                if(deals[i].product == deal.product)
                {
                    lblStatusStrip.Text = "A deal for " + deal.product + " already exists";
                    return;
                }
            }

            deal.price = double.Parse(txtPrice.Text);
            deal.expirationDate = dateTimePicker.Value.Date;

            if (deal.expirationDate < DateTime.Now)
            {
                lblStatusStrip.Text = "Expiration date is invalid";
                return;
            }

            deal.likes = new List<String>();
            deal.dislikes = new List<String>();
            lstDeals.Items.Add("\r\n" + deal.product + "," + deal.price + "," + deal.expirationDate + " Likes: 0 Dislikes: 0");
            deals.Add(deal);

            writeDealsToFile();
        }

        private void writeDealsToFile()
        {
            try
            {
                String output = "";
                Deal tempDeal;

                for (int i = 0; i < deals.Count; i++)
                {
                    tempDeal = deals[i];
                    output += tempDeal.product + "," + tempDeal.price + "," + tempDeal.expirationDate + ",";
                    for (int j = 0; j < tempDeal.likes.Count; j++)
                    {
                        output += tempDeal.likes[j] + "+";
                        Console.WriteLine("Like - " + tempDeal.likes[j]);
                    }
                    output += ",";
                    for (int j = 0; j < tempDeal.dislikes.Count; j++)
                    {
                        output += tempDeal.dislikes[j] + "+";
                        Console.WriteLine("Dislike - " + tempDeal.dislikes[j]);
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

        public void listDeals()
        {
            lstDeals.Items.Clear();

            for (int i = 0; i < deals.Count; i++)
            {
                lstDeals.Items.Add(deals[i].product + ", " + deals[i].price + ", " + deals[i].expirationDate + " Likes: " + deals[i].likes.Count + " Dislikes: " + deals[i].dislikes.Count + "\r\n");
            }
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
                    grpLikeDislike.Enabled = true;
                    lblStatusStrip.Text = "Logged in as: " + attemptedUsername;
                    loggedInUser = attemptedUsername;
                    return;
                }
            }
            lblStatusStrip.Text = "Login failed. \"" + attemptedUsername + "\" not found.";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;
            btnLogout.Enabled = false;
            grpLikeDislike.Enabled = false;
            loggedInUser = "";
            lblStatusStrip.Text = "Logged out";
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int selectedDeal = lstDeals.SelectedIndex;
            if ((selectedDeal >= 0) == false)
            {
                lblStatusStrip.Text = "Please select a deal";
                return;
            }

            Deal tempDeal = deals[selectedDeal];
            int likeCount = tempDeal.likes.Count;
            int dislikeCount = tempDeal.dislikes.Count;

            if (radLikeDeal.Checked)
            {
                for (int i = 0; i < likeCount; i++)
                {
                    if (loggedInUser == tempDeal.likes[i])
                    {
                        lblStatusStrip.Text = "You already like this deal";
                        return;
                    }
                }
                for(int i = 0; i < dislikeCount; i++)
                {
                    if(loggedInUser == tempDeal.dislikes[i])
                    {
                        tempDeal.dislikes.RemoveAt(i);
                        break;
                    }
                }
                Console.WriteLine("CHOSE: " + selectedDeal);
                deals[lstDeals.SelectedIndex].likes.Add(loggedInUser);
                lblStatusStrip.Text = "You now like this deal";
                writeDealsToFile();
            }
            else if (radDislikeDeal.Checked)
            {
                for (int i = 0; i < dislikeCount; i++)
                {
                    if (loggedInUser == tempDeal.dislikes[i])
                    {
                        lblStatusStrip.Text = "You already dislike this deal";
                        return;
                    }
                }
                for (int i = 0; i < likeCount; i++)
                {
                    if (loggedInUser == tempDeal.likes[i])
                    {
                        tempDeal.likes.RemoveAt(i);
                        break;
                    }
                }
                deals[lstDeals.SelectedIndex].dislikes.Add(loggedInUser);
                lblStatusStrip.Text = "You now dislike this deal";
                writeDealsToFile();
            }
            else
            {
                lblStatusStrip.Text = "Please select like or dislike";
            }

            deals[selectedDeal] = tempDeal;

            listDeals();
        }

        private void btnSearchDeal_Click(object sender, EventArgs e)
        {
            String search = txtSearchDeal.Text;
            String output = "";
            Deal tempDeal;

            for (int i = 0; i < deals.Count; i++)
            {
                tempDeal = deals[i];
                if (tempDeal.product == search)
                {
                    output += tempDeal.product + "," + tempDeal.price + "," + tempDeal.expirationDate + ",";
                    for (int j = 0; j < tempDeal.likes.Count; j++)
                    {
                        output += tempDeal.likes[j] + " ";
                    }
                    output += ",";
                    for (int j = 0; j < tempDeal.dislikes.Count; j++)
                    {
                        output += tempDeal.dislikes[j] + " ";
                    }
                    output += "\r\n";
                }
            }

            lstDeals.Text = output;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
