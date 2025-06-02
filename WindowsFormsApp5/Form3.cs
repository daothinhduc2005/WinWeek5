using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            buttonSend.Click += ButtonSend_Click;
            buttonAttach.Click += ButtonAttach_Click;
        }

        private string attachmentPath = "";

        private void ButtonAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                attachmentPath = ofd.FileName;
                labelAttachment.Text = Path.GetFileName(attachmentPath);
            }
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(textBoxFrom.Text.Trim());
                mail.To.Add(textBoxTo.Text.Trim());
                mail.Subject = textBoxSubject.Text.Trim();
                mail.Body = richTextBoxBody.Text.Trim();

                if (!string.IsNullOrEmpty(attachmentPath))
                    mail.Attachments.Add(new Attachment(attachmentPath));

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(textBoxFrom.Text.Trim(), textBoxPassword.Text.Trim());
                smtp.Send(mail);

                MessageBox.Show("Gửi mail thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message);
            }
        }
    }
}
