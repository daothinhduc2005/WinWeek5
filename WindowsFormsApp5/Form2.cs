using System;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new ImapClient())
                {

                    client.ServerCertificateValidationCallback = (s, c, h, sslErrors) => true;
                    client.Connect("127.0.0.1", 143, false); // dùng kết nối không mã hóa


                    client.Authenticate(textBox1.Text.Trim(), textBox2.Text.Trim());

                    if (!client.IsAuthenticated)
                    {
                        MessageBox.Show("Đăng nhập thất bại: Sai tài khoản hoặc mật khẩu.");
                        return;
                    }

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);


                    label4.Text = inbox.Count.ToString();
                    label6.Text = inbox.Recent.ToString();

                    
                    listView1.Items.Clear();
                    listView1.Columns.Clear();
                    listView1.Columns.Add("Email", 200);
                    listView1.Columns.Add("From", 200);
                    listView1.Columns.Add("Thời gian", 150);
                    listView1.View = View.Details;
                    listView1.FullRowSelect = true;
                    listView1.GridLines = true;

                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i);
                        var item = new ListViewItem(message.Subject ?? "(Không có tiêu đề)");
                        item.SubItems.Add(message.From.ToString());
                        item.SubItems.Add(message.Date.DateTime.ToString("dd/MM/yyyy HH:mm"));
                        listView1.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
