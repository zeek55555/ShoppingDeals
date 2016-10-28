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
            txtDeals.Text += "\n" + deal.product + ", " + deal.price + ", " + deal.expirationDate;
        }
    }
}
