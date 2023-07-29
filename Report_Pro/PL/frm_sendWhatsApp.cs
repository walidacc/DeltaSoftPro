﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace Report_Pro.PL
{
    public partial class frm_sendWhatsApp : Form
    {
        public frm_sendWhatsApp()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
         //   sendWhatsApp(txtToNumber.Text, txtMessage.Text);
            string from = "+966596281813"; //(Enter Your Mobile Number) 
            string to = txtToNumber.Text;
            string msg = txtMessage.Text;
            WhatsApp wa = new WhatsApp(from, "220775", "NickName", false, false);
            //wa.OnConnectSuccess += () =>
            //{
            //    MessageBox.Show("Connected to WhatsApp...");
            //    wa.OnLoginSuccess += (phonenumber, data) =>
            //    {
                    wa.SendMessage(to, msg);
                    MessageBox.Show("Message Sent...");
            //    };
            //    wa.OnLoginFailed += (data) =>
            //    {
            //        MessageBox.Show("Login Failed : {0} : ", data);
            //    };

            //    wa.Login();
            //};
            //wa.OnConnectFailed += (Exception) =>
            //{
            //    MessageBox.Show("Connection Failed...");
            //};
        }


        private void sendWhatsApp(string number , string message)
        {
            try
            {
                if (number == "")
                {
                    MessageBox.Show("no number");
                }

                if (number.Length <= 0)
                {
                    number = "+966" + number;
                }
                number = number.Replace(" ", "");
                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone="+number+ "&text="+message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message) ;
            }

        }
    }

}

