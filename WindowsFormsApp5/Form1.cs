using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmtpClient smtpClient = new SmtpClient("127.0.0.1", 25)) // Hoặc 587 nếu bạn đã đổi cổng
            {
                string mailfrom = textBox1.Text.Trim();
                string mailto = textBox2.Text.Trim();
                string password = textBox3.Text.Trim();

                smtpClient.EnableSsl = false; // Nếu bạn bật SSL trong MDaemon thì đổi thành true
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(mailfrom, password);

                using (MailMessage message = new MailMessage())
                {
                    try
                    {
                        message.From = new MailAddress(mailfrom);
                        message.To.Add(mailto);
                        message.Subject = textBox4.Text.Trim();
                        message.Body = richTextBox1.Text;
                        message.IsBodyHtml = true;

                        smtpClient.Send(message);
                        MessageBox.Show("Gửi mail thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi gửi mail: " + ex.Message);
                    }
                }
            }
        }
    }
}
