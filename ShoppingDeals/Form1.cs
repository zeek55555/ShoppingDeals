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
        //Keep track of current user
        String loggedInUser = "";

        //Structure to hold users
        struct User
        {
            public String name;
        }

        //Structure to hold deals
        struct Deal
        {
            public String product;
            public double price;
            public DateTime expirationDate;
            public List<String> likes;
            public List<String> dislikes;
        }

        //Lists to hold users and deals in memory during execution
        List<User> users;
        List<Deal> deals;

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            users = new List<User>();
            deals = new List<Deal>();

            InitializeComponent();

            //TODO: Fix dateTimePicker format in GUI
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MM/d/yyyy";
        }

        /// <summary>
        /// Form load event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try//Try to open the file
            {
                {
                    string line;

                    StreamReader file = File.OpenText("users.dat");
                    while ((line = file.ReadLine()) != null && line != "")//Read line by line
                    {
                        User user;
                        user.name = line;
                        users.Add(user);
                    }

                    file.Close();
                }
            }
            catch (Exception ex)//If there's a problem opening the file
            {
                lblStatusStrip.Text = "Error reading the file";
                Console.WriteLine(ex.Message);
            }

            try//Try opening and reading the file
            {
                {
                    string line;

                    StreamReader file = File.OpenText("deals.dat");
                    while ((line = file.ReadLine()) != null && line != "")
                    {
                        //Split the lines of text in the file into each property of the Deal struct
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

                        deals.Add(deal);//Add the deal to memory
                    }

                    file.Close();//Close the file
                }
            }
            catch (Exception ex)
            {
                lblStatusStrip.Text = "Error reading the file";
                Console.WriteLine(ex.Message);
            }

            //Remove expired deals
            for(int i = 0; i < deals.Count; i++)
            {
                if (deals[i].expirationDate < DateTime.Today)
                {
                    deals.RemoveAt(i);
                    i--;
                }
            }

            writeDealsToFile();
            listDeals();
        }

        /// <summary>
        /// Determine if a username has already been taken
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add a user and check that they met all requirements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            User user;
            user.name = txtUsernameToAdd.Text;

            //If username empty
            if(user.name == "")
            {
                lblStatusStrip.Text = "Username cannot be blank";
                return;
            }
            if (usernameTaken(user.name))
            {
                return;
            }

            users.Add(user);
            lblStatusStrip.Text = "User added successfully";

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

        /// <summary>
        /// Add deals and check that they meet the requirements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDeal_Click(object sender, EventArgs e)
        {
            Deal deal;
            deal.product = txtProductToAdd.Text;

            if (deal.product == "")
            {
                lblStatusStrip.Text = "Product cannot be blank";
                return;
            }
            for (int i = 0; i < deals.Count; i++)
            {
                if(deals[i].product == deal.product)
                {
                    lblStatusStrip.Text = "A deal for " + deal.product + " already exists";
                    return;
                }
            }

            deal.price = double.Parse(txtPrice.Text);
            if (deal.price < 0)
            {
                lblStatusStrip.Text = "Price cannot be negative";
                return;
            }

            deal.expirationDate = dateTimePicker.Value.Date;

            if (deal.expirationDate < DateTime.Today)
            {
                lblStatusStrip.Text = "Expiration date is invalid";
                return;
            }
            
            deal.likes = new List<String>();
            deal.dislikes = new List<String>();
            lstDeals.Items.Add("\r\n" + deal.product + ", " + deal.price.ToString("C") + ", expires on " + deal.expirationDate.ToString("M'/'d'/'yyyy") + " Likes: 0 Dislikes: 0");
            deals.Add(deal);

            writeDealsToFile();
            listDeals();
        }

        /// <summary>
        /// Write the deals in memory to the file
        /// </summary>
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

        //Display the deals in the list box
        public void listDeals()
        {
            lstDeals.Items.Clear();

            for (int i = 0; i < deals.Count; i++)
            {
                lstDeals.Items.Add(deals[i].product + ", " + deals[i].price.ToString("C") + ", expires on " + deals[i].expirationDate.ToString("M'/'d'/'yyyy") + " Likes: " + deals[i].likes.Count + " Dislikes: " + deals[i].dislikes.Count + "\r\n");
            }

            if(deals.Count == 0)
            {
                lstDeals.Items.Add("No deals at this time");
            }
        }

        /// <summary>
        /// Log in the user and check all requirements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String attemptedUsername = txtEnterUsername.Text;

            for(int i = 0; i < users.Count; i++)
            {
                if(attemptedUsername == users[i].name)
                {
                    btnLogin.Enabled = false;
                    btnLogout.Enabled = true;
                    grpLikeDislike.Enabled = true;
                    lblStatusStrip.Text = "Welcome back!";
                    loggedInUser = attemptedUsername;
                    txtEnterUsername.Enabled = false;
                    return;
                }
            }
            lblStatusStrip.Text = "Login failed. \"" + attemptedUsername + "\" not found.";
        }

        /// <summary>
        /// Log the user out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;
            btnLogout.Enabled = false;
            grpLikeDislike.Enabled = false;
            loggedInUser = "";
            lblStatusStrip.Text = "Logged out";
            txtEnterUsername.Enabled = true;
        }

        /// <summary>
        /// Like or dislike the deal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Search for deals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchDeal_Click(object sender, EventArgs e)
        {
            lblStatusStrip.Text = "";
            String search = txtSearchDeal.Text;
            
            for (int i = 0; i < deals.Count; i++)
            {
                if(deals[i].product == search)
                {
                    lstDeals.SelectedIndex = i;
                    return;
                }
            }

            lblStatusStrip.Text = "No product with that name";
        }
        
        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
