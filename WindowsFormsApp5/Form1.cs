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
            string mailfrom = textBox1.Text.Trim();
            string mailto = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();
            string subject = textBox4.Text.Trim();
            string body = richTextBox1.Text;

            if (string.IsNullOrEmpty(mailfrom) || string.IsNullOrEmpty(mailto) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ From, To, và Password.");
                return;
            }

            try
            {
                using (SmtpClient smtpClient = new SmtpClient("127.0.0.1", 25))
                {
                    smtpClient.EnableSsl = false; // Đảm bảo MDaemon không yêu cầu SSL
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(mailfrom, password);
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(mailfrom);
                    message.To.Add(mailto);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = false;

                    smtpClient.Send(message);
                    MessageBox.Show("Gửi mail thành công!");
                }
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show("SMTP lỗi: " + smtpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message);
            }
        }
    }
}
